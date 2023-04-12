using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiToDoList.Data;
using WebApiToDoList.Models;


namespace WebApiToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectItemsController : ControllerBase
    {
        private readonly WebApiToDoListContext _context;

        public ProjectItemsController(WebApiToDoListContext context)
        {
            _context = context;
        }

        // GET: api/ProjectItems
        [HttpGet]
        public async Task<ActionResult<ICollection<ProjectItem>>> GetProjectItem()
        {
            if (_context.ProjectItems == null)
            {
                return NotFound();
            }




            //List<TaskItem> taskItems;
            //List<ProjectItem> projectItems;

            //var resultList = new ICollection<ProjectItem, TaskItem>();
            //{
            //    taskItems = _context.TaskItems.ToList();
            //    projectItems = _context.ProjectItems.ToList();
            //}





            //var taskItems = await _context.TaskItems.ToListAsync();
            //var projectItems = await _context.ProjectItems.ToListAsync();

            //var viewModel = new ViewModel { ProjectItemsView = (ActionResult<IEnumerable<ProjectItem>>)projectItems, TaskItemsView = taskItems };





            var projectItems = _context.ProjectItems.Join(_context.TaskItems,
                p => p.Id,
                t => t.ProjectItemId,
                (p, t) => new ProjectItem()
                {
                    Name = p.Name,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ProjectCurrentStatus = p.ProjectCurrentStatus,
                    Priority = p.Priority,
                    TaskItems = new Collection<TaskItem>() 
                    { 
                        new TaskItem 
                        {
                        Name = t.Name,
                        TaskCurrentStatus = t.TaskCurrentStatus,
                        Description = t.Description,
                        Priority = t.Priority,
                        ProjectItemId = p.Id
                        }
                    }
                    
                });

            //var result = await (IEnumerable<ProjectItem>)projectItems.ToListAsync();

            //var result = from projectitem in _context.ProjectItem
            //             join taskitem in _context.TaskItem on projectitem.Id equals taskitem.ProjectItemId
            //             select new
            //             {
            //                 Name = projectitem.Name,
            //                 StartDate = projectitem.StartDate,
            //                 EndDate = projectitem.EndDate,
            //                 ProjectCurrentStatus = projectitem.ProjectCurrentStatus,
            //                 Priority = projectitem.Priority,
            //                 TaskItems = new
            //                 {
            //                     Name = taskitem.Name,
            //                     TaskCurrentStatus = taskitem.TaskCurrentStatus,
            //                     Description = taskitem.Description,
            //                     Priority = taskitem.Priority,
            //                     ProjectItemId = projectitem.Id
            //                 }
            //             };




            return await projectItems.ToListAsync();//_context.ProjectItems.ToListAsync();

            //var projectItem = new ProjectItem();
            
            //var taskItem = new TaskItem();

            //projectItem.TaskItems = taskItem.ProjectItemId
            
            //var projectItems = await _context.ProjectItem.ToListAsync();

            //projectItems.

            //var taskItems = await _context.TaskItem.ToListAsync();


            //var viewModel = new ViewModel { ProjectItems = projectItems, TaskItems = taskItems };


            //return await taskItems.ToListAsync();

            //return await _context.ProjectItem.ToListAsync();





        }

        // GET: api/ProjectItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItem>> GetProjectItem(long id)
        {
          if (_context.ProjectItems == null)
          {
              return NotFound();
          }
            var projectItem = await _context.ProjectItems.FindAsync(id);

            if (projectItem == null)
            {
                return NotFound();
            }

            return projectItem;
        }

        // PUT: api/ProjectItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectItem(long id, ProjectItem projectItem)
        {
            if (id != projectItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectItem>> PostProjectItem(ProjectItem projectItem)
        {
          if (_context.ProjectItems == null)
          {
              return Problem("Entity set 'WebApiToDoListContext.ProjectItem'  is null.");
          }
            _context.ProjectItems.Add(projectItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectItem", new { id = projectItem.Id }, projectItem);
        }

        // DELETE: api/ProjectItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectItem(long id)
        {
            if (_context.ProjectItems == null)
            {
                return NotFound();
            }
            var projectItem = await _context.ProjectItems.FindAsync(id);
            if (projectItem == null)
            {
                return NotFound();
            }

            _context.ProjectItems.Remove(projectItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectItemExists(long id)
        {
            return (_context.ProjectItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    internal class ICollection<T1, T2>
    {
        public ICollection()

        {
            return;
        }
    }
}

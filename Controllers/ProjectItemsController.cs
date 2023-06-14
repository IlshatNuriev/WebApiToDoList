using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApiToDoList.Data;
using WebApiToDoList.Filters;
using WebApiToDoList.Models;



namespace WebApiToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectItemsController : ControllerBase
    {
        private readonly WebApiToDoListContext _context;
        private readonly ISortByNameOrStartDate _sortBy;

        public ProjectItemsController(WebApiToDoListContext context, ISortByNameOrStartDate sortBy)
        {
            _context = context;
            _sortBy = sortBy;
        }

        // GET: api/ProjectItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectItem>>> GetProjectItem(string? sortOrder)
        {
            if (_context.ProjectItems == null)
            {
                return NotFound();
            }

            
            try
            {
                var projectItems = await _context.ProjectItems.Include(t => t.TaskItems).ToListAsync();
                
                var result = _sortBy.SortProjectItems(projectItems, sortOrder);

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

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

using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiToDoList.Data;
using WebApiToDoList.Models;

namespace WebApiToDoList.Filters
{
  
    public class SortByNameOrStartDate : ISortByNameOrStartDate
    {
      
        public ActionResult<IEnumerable<ProjectItem>> SortProjectItems(IEnumerable<ProjectItem> projectItems, string sortOrder)
        {
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        projectItems = projectItems.OrderByDescending(p => p.Name);
                        break;
                    case "date":
                        projectItems = projectItems.OrderBy(p => p.StartDate);
                        break;
                    case "date_desc":
                        projectItems = projectItems.OrderByDescending(p => p.StartDate);
                        break;
                    
                }
                return projectItems.ToList();
            }
            else
            {
                return projectItems.OrderBy(p => p.Name).ToList();
            }
            
        }
    }
}

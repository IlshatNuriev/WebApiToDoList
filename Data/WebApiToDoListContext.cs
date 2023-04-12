using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiToDoList.Models;

namespace WebApiToDoList.Data
{
    public class WebApiToDoListContext : DbContext
    {
        public WebApiToDoListContext (DbContextOptions<WebApiToDoListContext> options)
            : base(options)
        {

        }

        public DbSet<ProjectItem> ProjectItems { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; } 

        
        
    }

}

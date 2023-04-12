using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace WebApiToDoList.Models
{
    public class ViewModel
    { 
        public ICollection<ProjectItem>? ProjectItemsView { get; set; }
                
        public ICollection<TaskItem>? TaskItemsView { get; set; }

    }
}

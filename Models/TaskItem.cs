using System.ComponentModel.DataAnnotations;

namespace WebApiToDoList.Models
{
    public enum TaskCurrentStatus
    {
        ToDo,
        InProgress,
        Done
    }
    public class TaskItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Status")]
        public TaskCurrentStatus TaskCurrentStatus { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public long ProjectItemId { get; }


    }
}

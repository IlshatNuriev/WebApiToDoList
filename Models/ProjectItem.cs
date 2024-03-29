﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApiToDoList.Models
{
    public enum ProjectCurrentStatus
    {
        [Display(Name = "Not started")]
        NotStarted,

        Active,

        Completed
    }
    public class ProjectItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public ProjectCurrentStatus ProjectCurrentStatus { get; set; }
        public int Priority { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }


    }
}

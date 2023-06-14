using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApiToDoList.Data;
using WebApiToDoList.Models;

namespace WebApiToDoList.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApiToDoListContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebApiToDoListContext>>()))
            {
                if (context.ProjectItems.Any())
                {
                    return;
                }

                context.ProjectItems.AddRange(
                    new ProjectItem
                    {
                        Name = "Create models",
                        StartDate = DateTime.Parse("20-3-2023"),
                        EndDate = DateTime.Parse("5-4-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.Active,
                        Priority = 1,
                        TaskItems = new Collection<TaskItem>()             
                        {
                            new TaskItem()
                            {
                                Name = "H",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "J",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "I",
                                TaskCurrentStatus = TaskCurrentStatus.InProgress,
                                Description = "TaskTest3Description",
                                Priority = 3
                            }
                        },
                    },

                    new ProjectItem
                    {
                        Name = "Add controllers",
                        StartDate = DateTime.Parse("16-4-2023"),
                        EndDate = DateTime.Parse("2-5-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.NotStarted,
                        Priority = 2,
                        TaskItems = new Collection<TaskItem>()
                        {
                            new TaskItem()
                            {
                                Name = "D",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "G",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "F",
                                TaskCurrentStatus = TaskCurrentStatus.InProgress,
                                Description = "TaskTest3Description",
                                Priority = 3
                            }
                        }
                    },
                    new ProjectItem
                    {
                        Name = "Services",
                        StartDate = DateTime.Parse("15-5-2023"),
                        EndDate = DateTime.Parse("20-5-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.Completed,
                        Priority = 3,
                        TaskItems = new Collection<TaskItem>()
                        {
                            new TaskItem()
                            {
                                Name = "A",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "C",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "B",
                                TaskCurrentStatus = TaskCurrentStatus.InProgress,
                                Description = "TaskTest3Description",
                                Priority = 3
                            }
                        },
                    }) ;
                context.SaveChanges();
            }
        }
    }
}

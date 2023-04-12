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
                        Name = "ProjectTest1",
                        StartDate = DateTime.Parse("31-3-2023"),
                        EndDate = DateTime.Parse("2-4-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.Active,
                        Priority = 1,
                        TaskItems = new Collection<TaskItem>()             
                        {
                            new TaskItem()
                            {
                                Name = "ProjectTest1TaskTest1",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest1TaskTest2",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest1TaskTest3",
                                TaskCurrentStatus = TaskCurrentStatus.InProgress,
                                Description = "TaskTest3Description",
                                Priority = 3
                            }
                        },
                    },

                    new ProjectItem
                    {
                        Name = "ProjectTest2",
                        StartDate = DateTime.Parse("31-3-2023"),
                        EndDate = DateTime.Parse("2-4-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.NotStarted,
                        Priority = 2,
                        TaskItems = new Collection<TaskItem>()
                        {
                            new TaskItem()
                            {
                                Name = "ProjectTest2TaskTest1",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest2TaskTest2",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest2TaskTest3",
                                TaskCurrentStatus = TaskCurrentStatus.InProgress,
                                Description = "TaskTest3Description",
                                Priority = 3
                            }
                        }
                    },
                    new ProjectItem
                    {
                        Name = "ProjectTest3",
                        StartDate = DateTime.Parse("31-3-2023"),
                        EndDate = DateTime.Parse("2-4-2023"),
                        ProjectCurrentStatus = ProjectCurrentStatus.Completed,
                        Priority = 3,
                        TaskItems = new Collection<TaskItem>()
                        {
                            new TaskItem()
                            {
                                Name = "ProjectTest3TaskTest1",
                                TaskCurrentStatus = TaskCurrentStatus.ToDo,
                                Description = "TaskTest1Description",
                                Priority = 1
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest3TaskTest2",
                                TaskCurrentStatus = TaskCurrentStatus.Done,
                                Description = "TaskTest2Description",
                                Priority = 2
                            },
                            new TaskItem()
                            {
                                Name = "ProjectTest3TaskTest3",
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

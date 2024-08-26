using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace ProjectManagement.Domain.Entities
{
    public class ProjectTask
    {
        public ProjectTask()
        {

        }
        public ProjectTask(Guid projectId, string title, string description, DateTime dueDate, Guid userId, TaskPriorityEnum? priority)
        {
   ;

            Id = Guid.NewGuid();
            ProjectId = projectId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TaskStatusEnum.Pending;
            Priority = priority ?? TaskPriorityEnum.Low;   
        }

        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public string Title { get; protected set; } = string.Empty;

        [Required]
        public string Description { get; protected set; } = string.Empty;
        public DateTime DueDate { get; protected set; }
        public TaskStatusEnum Status { get; protected set; }
        public TaskPriorityEnum Priority { get; protected set; }


        [Required]
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }



        public virtual List<ProjectTaskHistory> TaskHistory { get; set; } = new List<ProjectTaskHistory>();



        public ProjectTaskHistory SetStatus(TaskStatusEnum status, Guid userId)
        {

            var history = new ProjectTaskHistory(this.Id,
                                                    userId,
                                                    "UpdateStatus",
                                                    JsonConvert.SerializeObject(new
                                                    {
                                                        Status = this.Status,
                                                    }),
                                                    JsonConvert.SerializeObject(new
                                                    {
                                                        Status = status,
                                                    }));

            this.Status = status;

            return history;
        }

        public ProjectTaskHistory Alter(Guid userId, string? title = null, string? description = null, DateTime? dueDate = null)
        {
            var history = new ProjectTaskHistory(this.Id,
                                                 userId,
                                                 "Update",
                                                 JsonConvert.SerializeObject(new
                                                 {
                                                     Title = this.Title,
                                                     Description = this.Description,
                                                     DueDate = this.DueDate,                                                     
                                                 }),
                                                JsonConvert.SerializeObject(new
                                                {
                                                    Title = title,
                                                    Description = description,
                                                    DueDate = dueDate
                                                }));
            Title = title ?? this.Title;
            Description = description ?? this.Description;
            DueDate = dueDate ?? this.DueDate;

            return history;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Domain.Entities
{
    public class ProjectTaskHistory
    {
        public ProjectTaskHistory()
        {
            
        }

        public ProjectTaskHistory(Guid taskId, Guid userId, string type, string oldValues, string newValues)
        {
            Id = Guid.NewGuid();
            ProjectTaskId = taskId;
            UserId = userId;
            DateTime = DateTime.Now;
            Type = type;
            OldValues = oldValues ?? string.Empty;
            NewValues = newValues;
        }

        public Guid Id { get; set; }
        public Guid ProjectTaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;



        [Required]
        [ForeignKey(nameof(ProjectTaskId))]
        public ProjectTask ProjectTask { get; set; }
    }
}

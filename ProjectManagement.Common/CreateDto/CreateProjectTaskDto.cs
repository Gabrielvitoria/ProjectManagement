using ProjectManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Common.CreateDto
{
    public class CreateProjectTaskDto
    {
        [Required]
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskPriorityEnum Priority { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Common.CreateDto
{
    public class CreateProjectTaskCommentDto
    {
        [Required]
        public Guid ProjectTaskId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}

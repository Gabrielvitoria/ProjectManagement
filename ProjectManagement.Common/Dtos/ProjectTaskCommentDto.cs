using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Common.Dtos
{
    public class ProjectTaskCommentDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectTaskId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Description { get; protected set; } = string.Empty;

    }
}

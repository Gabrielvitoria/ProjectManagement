using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Domain.Entities
{
    public class ProjectTaskComment
    {
        public ProjectTaskComment( Guid projectTaskId, Guid userId, string description)
        {
            Id = Guid.NewGuid();
            ProjectTaskId = projectTaskId;
            UserId = userId;
            Description = description;
        }
        public ProjectTaskComment()
        {
            
        }

        public Guid Id { get; set; }

        [Required]
        public Guid ProjectTaskId { get; protected set; }

        [Required]
        public Guid UserId { get; protected set; }

        [Required]
        public string Description { get; protected set; } = string.Empty;


        [Required]
        [ForeignKey(nameof(ProjectTaskId))]
        public ProjectTask Project { get; set; }
    }
}

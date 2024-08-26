using ProjectManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Common.AlterDto
{
    public class AlterProjectTaskDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        
        public DateTime DueDate { get; set; }
    }
}

using ProjectManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Common.AlterDto
{
    public class AlterStatusProjectTaskDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public TaskStatusEnum Status { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}

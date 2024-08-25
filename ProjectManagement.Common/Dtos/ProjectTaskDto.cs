using ProjectManagement.Domain;

namespace ProjectManagement.Common.Dtos
{
    public class ProjectTaskDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public DateTime DueDate { get; protected set; }
        public TaskStatusEnum Status { get; protected set; }
        public string StatusDescription => Helper.GetEnumDescription(Status);      

        public TaskPriorityEnum Priority { get; protected set; }
        public string PriorityDescription => Helper.GetEnumDescription(Priority);      
    }
}

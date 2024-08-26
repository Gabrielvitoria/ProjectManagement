namespace ProjectManagement.Common.Dtos
{
    public class ProjectTaskHistoryDto
    {
        public Guid Id { get; set; }
        public Guid ProjectTaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
    }
}

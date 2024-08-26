namespace ProjectManagement.Common.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}

namespace ProjectManagement.Common.CreateDto
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}

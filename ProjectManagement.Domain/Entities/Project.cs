namespace ProjectManagement.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            
        }
        public Project(string name, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public List<ProjectTask> ProjectTask { get; set; } = new List<ProjectTask>();


        public void AddTask(ProjectTask task)
        {
            if (ProjectTask?.Count == 20) 
                throw new ApplicationException($"Erro: Max task in project {Name}");

            ProjectTask?.Add(task);
        }
        public void Remove()
        {
            if (ProjectTask.Any(x => x.Status == TaskStatusEnum.Pending)) 
                throw new ApplicationException("Erro: The Project contain task Pending. Finalize pending tasks before removing a project");
        }
    }
}

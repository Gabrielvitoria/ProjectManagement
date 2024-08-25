using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTaskTest
    {

        [Fact]
        public void AlterTask()
        {
            var task = new ProjectTask(Guid.NewGuid(), "Tarefa ABC", "Executar Hoje", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            var historico = task.Alter("Novo Tarefa", "Executar Amanhã", DateTime.Now, Domain.TaskStatusEnum.Completed, Guid.NewGuid());

            Assert.Equal("Alter", historico.Type);
        }

        [Fact]
        public void AlterStatus()
        {
            var task = new ProjectTask(Guid.NewGuid(), "Tarefa ABC", "Executar Hoje", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            var historico = task.SetStatus(Domain.TaskStatusEnum.Completed, Guid.NewGuid());

            Assert.Equal("SetStatus", historico.Type);
        }
    }
}

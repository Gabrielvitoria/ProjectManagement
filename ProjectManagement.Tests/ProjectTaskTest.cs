using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTaskTest
    {

        [Fact]
        public void AlterTask()
        {
            var task = new ProjectTask(Guid.NewGuid(), "Tarefa ABC", "Executar Hoje", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            var historico = task.Alter(Guid.NewGuid(), "Novo Tarefa", "Executar Amanhã", DateTime.Now);

            Assert.Equal("Update", historico.Type);
        }

        [Fact]
        public void AlterStatus()
        {
            var task = new ProjectTask(Guid.NewGuid(), "Tarefa ABC", "Executar Hoje", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            var historico = task.SetStatus(Domain.TaskStatusEnum.Completed, Guid.NewGuid());

            Assert.Equal("UpdateStatus", historico.Type);
        }
    }
}

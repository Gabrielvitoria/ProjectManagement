using Newtonsoft.Json;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTaskHistoryTest
    {
        [Fact]
        public void CreateHistoryNotNull()
        {
            var history = new ProjectTaskHistory();
            Assert.NotNull(history);
        }
        
        [Fact]
        public void CreateHistory()
        {
            var projectTaskHistory = new ProjectTaskHistory(Guid.NewGuid(),
                                                Guid.NewGuid(),
                                                "Create",
                                                JsonConvert.SerializeObject(new
                                                {
                                                    PropertA = "A",
                                                }),
                                                JsonConvert.SerializeObject(new
                                                {
                                                    PropertA = "B",
                                                }));

            var projectTask = new ProjectTask(Guid.NewGuid(), "Tarefa ABC", "Executar Hoje", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            projectTaskHistory.ProjectTask = projectTask;

            Assert.NotEqual(projectTaskHistory.NewValues, projectTaskHistory.OldValues);
        }

    }
}

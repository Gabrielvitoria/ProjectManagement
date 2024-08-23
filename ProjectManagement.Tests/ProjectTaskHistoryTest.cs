using Newtonsoft.Json;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTaskHistoryTest
    {
        [Fact]
        public void CreateHistory()
        {
            var task = new ProjectTaskHistory(Guid.NewGuid(),
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

            Assert.NotEqual(task.NewValues, task.OldValues);
        }

    }
}

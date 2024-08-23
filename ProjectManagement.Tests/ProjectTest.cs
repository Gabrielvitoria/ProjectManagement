﻿using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTest
    {
        [Fact]
        public void CreateProject()
        {
            var project = new Project("Projeto X", Guid.NewGuid());
            var task = new ProjectTask(project.Id, "Tarefa ABC", "Executar Hoje", DateTime.Now, Domain.TaskStatusEnum.Pending, Guid.NewGuid(), Domain.TaskPriorityEnum.High);

            project.AddTask(task);

            Assert.True(project.ProjectTask.Count == 1);
        }

        [Fact]
        public void CreateProjectMaxTask()
        {
            var project = new Project("Projeto X", Guid.NewGuid());
          
            
            for (int i = 0; i < 20; i++)
            {
                var task = new ProjectTask(project.Id, $"Tarefa ABC {i}", $"Executar Hoje {i}", DateTime.Now, Domain.TaskStatusEnum.Pending, Guid.NewGuid(), Domain.TaskPriorityEnum.High);
                project.AddTask(task);
            }

            try
            {
                var task = new ProjectTask(project.Id, $"Tarefa 666", $"Executar Hoje 666", DateTime.Now, Domain.TaskStatusEnum.Pending, Guid.NewGuid(), Domain.TaskPriorityEnum.High);
                project.AddTask(task);
            }
            catch (ApplicationException ex)
            {
                Assert.True(ex.Message.Equals("Erro: Max task in project"));
            }            
        }
    }
}

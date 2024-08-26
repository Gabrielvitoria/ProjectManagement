using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Tests
{
    public class ProjectTaskCommentTest
    {
        [Fact]
        public void CreateProjectTaskCommentNotNull()
        {
            var comment = new ProjectTaskComment();
            Assert.NotNull(comment);
        }

        [Fact]
        public void CreateProjectTaskComment()
        {
            var comment = new ProjectTaskComment(Guid.NewGuid(), Guid.NewGuid(), "Comentário");
            
            Assert.Equal(comment.Description, "Comentário");
        }

    }
}

using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectDocuments.Commands.UpdateProjectDocument;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.ProjectDocuments.Commands
{
    public class UpdateProjectDocumentCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProjectDocumentCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateProjectDocumentCommandHandler(Context);
            var name = "new_project_document.docx";

            //Act
            await handler.Handle(
                new UpdateProjectDocumentCommand
                {
                    Id = ProjectDashContextFactory.DocumentIdForUpdate,
                    Name = name,
                    ProjectId = ProjectDashContextFactory.ProjectIdForDetails
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.ProjectDocuments.SingleOrDefaultAsync(pd =>
                    pd.Id == ProjectDashContextFactory.DocumentIdForUpdate &&
                    pd.Name == name &&
                    pd.ProjectId == ProjectDashContextFactory.ProjectIdForDetails));
        }

        [Fact]
        public async Task UpdateProjectDocumentCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateProjectDocumentCommandHandler(Context);
            var name = "new_project_document.docx";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProjectDocumentCommand
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        ProjectId = ProjectDashContextFactory.ProjectIdForDetails
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateProjectDocumentCommandHandler_FailOnWrongProjectId()
        {
            //Arrange
            var handler = new UpdateProjectDocumentCommandHandler(Context);
            var name = "new_project_document.docx";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProjectDocumentCommand
                    {
                        Id = ProjectDashContextFactory.DocumentIdForUpdate,
                        Name = name,
                        ProjectId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

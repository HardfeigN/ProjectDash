using Microsoft.EntityFrameworkCore;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectDocuments.Commands.CreateProjectDocument;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.ProjectDocuments.Commands
{
    public class CreateProjectDocumentCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProjectDocumentCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateProjectDocumentCommandHandler(Context);
            var name = "project_document.docx";

            //Act
            var pdId = await handler.Handle(
                new CreateProjectDocumentCommand
                {
                    Name = name,
                    ProjectId = ProjectDashContextFactory.ProjectIdForDetails
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.ProjectDocuments.SingleOrDefaultAsync(pd =>
                    pd.Id == pdId &&
                    pd.Name == name &&
                    pd.ProjectId == ProjectDashContextFactory.ProjectIdForDetails));
        }

        [Fact]
        public async Task CreateProjectDocumentCommandHandler_FailOnWrongProjectId()
        {
            //Arrange
            var handler = new CreateProjectDocumentCommandHandler(Context);
            var name = "project_document.docx";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateProjectDocumentCommand
                    {
                        Name = name,
                        ProjectId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

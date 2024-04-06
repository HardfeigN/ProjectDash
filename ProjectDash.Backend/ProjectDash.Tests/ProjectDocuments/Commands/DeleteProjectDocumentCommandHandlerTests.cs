using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectDocuments.Commands.DeleteProjectDocument;
using ProjectDash.Tests.Common;

namespace ProjectDash.Tests.ProjectDocuments.Commands
{
    public class DeleteProjectDocumentCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProjectDocumentCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteProjectDocumentCommandHandler(Context);

            //Act
            await handler.Handle(new DeleteProjectDocumentCommand
            {
                Id = ProjectDashContextFactory.DocumentIdForDelete,
            },
            CancellationToken.None);

            //Assert
            Assert.Null(Context.ProjectDocument.SingleOrDefault(pd =>
                pd.Id == ProjectDashContextFactory.DocumentIdForDelete));
        }

        [Fact]
        public async Task DeleteProjectDocumentCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteProjectDocumentCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProjectDocumentCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}

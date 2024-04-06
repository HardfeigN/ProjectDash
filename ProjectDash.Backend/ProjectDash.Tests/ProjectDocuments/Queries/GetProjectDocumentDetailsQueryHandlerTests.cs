using AutoMapper;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentDetails;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.ProjectDocuments.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectDocumentDetailsQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectDocumentDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectDocumentDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetProjectDocumentDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetProjectDocumentDetailsQuery
            {
                Id = ProjectDashContextFactory.DocumentIdForDetails
            },
            CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProjectDocumentDetailsVm>();
            result.Name.ShouldBe("Document2");
            result.Extension.ShouldBe(".docx");
            result.ProjectId.ShouldBe(ProjectDashContextFactory.ProjectIdForPDSearch);
        }

        [Fact]
        public async Task GetProjectDocumentDetailsQueryHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new GetProjectDocumentDetailsQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProjectDocumentDetailsQuery
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

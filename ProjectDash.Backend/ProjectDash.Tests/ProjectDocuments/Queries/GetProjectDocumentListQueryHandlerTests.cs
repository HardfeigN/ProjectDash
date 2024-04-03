using AutoMapper;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.ProjectDocuments.Queries.GetProjectDocumentList;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.ProjectDocuments.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectDocumentListQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectDocumentListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectDocumentListQueryHandler_Success()
        {
            //Arrange 
            var handler = new GetProjectDocumentListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetProjectDocumentListQuery
                {
                    ProjectId = ProjectDashContextFactory.ProjectIdForPDSearch
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProjectDocumentListVm>();
            result.ProjectDocuments.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetProjectDocumentListQueryHandler_FailOnWrongProjectId()
        {
            //Arrange 
            var handler = new GetProjectDocumentListQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProjectDocumentListQuery
                    {
                        ProjectId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

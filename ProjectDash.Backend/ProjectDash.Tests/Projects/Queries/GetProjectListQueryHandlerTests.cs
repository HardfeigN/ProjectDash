using AutoMapper;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Projects.Queries.GetProjectList;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.Projects.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectListQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectListQueryHandler_Success()
        {
            //Arrange 
            var handler = new GetProjectListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetProjectListQuery
                {
                    ProjectLeaderId = ProjectDashContextFactory.ProjectLeaderIdForSearch
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProjectListVm>();
            result.Projects.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetProjectListQueryHandler_FailOnWrongProjectLeaderId()
        {
            //Arrange 
            var handler = new GetProjectListQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProjectListQuery
                    {
                        ProjectLeaderId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task GetProjectListQueryHandler_FailOnWrongEmployeeId()
        {
            //Arrange 
            var handler = new GetProjectListQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProjectListQuery
                    {
                        EmployeeId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

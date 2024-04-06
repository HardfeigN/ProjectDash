using AutoMapper;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Projects.Queries.GetProjectDetails;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.Projects.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectDetailsQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetProjectDetailsQueryHandler(Context, Mapper);
            
            //Act
            var result = await handler.Handle(new GetProjectDetailsQuery
            {
                Id = ProjectDashContextFactory.ProjectIdForDetails
            },
            CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProjectDetailsVm>();
            result.Id.ShouldBe(ProjectDashContextFactory.ProjectIdForDetails);
            result.Name.ShouldBe("Project1");
            result.Performer.ShouldBe("Performer1");
            result.Customer.ShouldBe("Customer1");
            result.StartDate.ShouldBe(new DateOnly(2023, 10, 8));
            result.EndDate.ShouldBe(new DateOnly(2023, 12, 5));
            result.Priority.ShouldBe(10);
            result.ProjectLeaderId.ShouldBe(ProjectDashContextFactory.ProjectLeaderIdForUpdate);             
        }

        [Fact]
        public async Task GetProjectDetailsQueryHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new GetProjectDetailsQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProjectDetailsQuery
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

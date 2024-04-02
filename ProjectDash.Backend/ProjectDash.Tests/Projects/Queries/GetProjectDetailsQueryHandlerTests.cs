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
            result.Name.ShouldBe("Project2");
            result.Performer.ShouldBe("Performer2");
            result.Customer.ShouldBe("Customer2");
            result.CreationDate.ShouldBe(new DateTime(2023, 11, 23));
            result.CompletionDate.ShouldBe(DateTime.Today);
            result.Priority.ShouldBe(20);
            result.ProjectLeaderId.ShouldBe(ProjectDashContextFactory.ProjectLeaderIdForSearch);             
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

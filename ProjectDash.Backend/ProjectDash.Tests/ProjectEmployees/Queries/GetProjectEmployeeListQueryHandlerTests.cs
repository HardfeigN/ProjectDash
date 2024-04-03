using AutoMapper;
using ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.ProjectEmployees.Queries
{
    [Collection("QueryCollection")]
    public class GetProjectEmployeeListQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetProjectEmployeeListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProjectEmployeeListQueryHandler_Success()
        {
            //Arrange 
            var handler = new GetProjectEmployeeListQueryHandler(Context, Mapper);

            //search by ProjectId
            //Act
            var result1 = await handler.Handle(
                new GetProjectEmployeeListQuery
                {
                    ProjectId = ProjectDashContextFactory.ProjectIdForPESearch
                },
                CancellationToken.None);

            //Assert
            result1.ShouldBeOfType<ProjectEmployeeListVm>();
            result1.ProjectEmployees.Count().ShouldBe(3);

            //search by Employee
            //Act
            var result2 = await handler.Handle(
                new GetProjectEmployeeListQuery
                {
                    EmployeeId = ProjectDashContextFactory.EmployeeIdForPESearch
                },
                CancellationToken.None);

            //Assert
            result2.ShouldBeOfType<ProjectEmployeeListVm>();
            result2.ProjectEmployees.Count().ShouldBe(3);
        }
    }
}

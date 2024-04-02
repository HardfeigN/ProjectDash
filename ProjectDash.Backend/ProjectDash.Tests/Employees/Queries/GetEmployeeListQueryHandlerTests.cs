using AutoMapper;
using ProjectDash.Application.Employees.Queries.GetEmployeeList;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.Employees.Queries
{
    [Collection("QueryCollection")]
    public class GetEmployeeListQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetEmployeeListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetEmployeeListQueryHandler_Success()
        {
            //Arrange 
            var handler = new GetEmployeeListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetEmployeeListQuery
                {
                    ProjectId = ProjectDashContextFactory.ProjectIdForEmployeeSearch
                },
                CancellationToken.None);
            result.ShouldBeOfType<EmployeeListVm>();
            result.Employees.Count().ShouldBe(3);
        }
    }
}

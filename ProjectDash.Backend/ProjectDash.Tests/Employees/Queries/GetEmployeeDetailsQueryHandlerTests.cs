using AutoMapper;
using ProjectDash.Application.Common.Exceptions;
using ProjectDash.Application.Employees.Queries.GetEmployeeDetails;
using ProjectDash.Persistence;
using ProjectDash.Tests.Common;
using Shouldly;

namespace ProjectDash.Tests.Employees.Queries
{
    [Collection("QueryCollection")]
    public class GetEmployeeDetailsQueryHandlerTests
    {
        private readonly ProjectDashDbContext Context;
        private readonly IMapper Mapper;

        public GetEmployeeDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetEmployeeDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetEmployeeDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetEmployeeDetailsQuery
            {
                Id = ProjectDashContextFactory.EmployeeIdForDetails
            },
            CancellationToken.None);

            //Assert
            result.ShouldBeOfType<EmployeeDetailsVm>();
            result.Name.ShouldBe("Name3");
            result.Surname.ShouldBe("Surname3");
            result.Patronymic.ShouldBe("Patronymic3");
            result.Email.ShouldBe("email3@email.com");
        }

        [Fact]
        public async Task GetEmployeeDetailsQueryHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new GetEmployeeDetailsQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetEmployeeDetailsQuery
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}

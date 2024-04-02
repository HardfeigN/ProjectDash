using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain.Interfaces;
using ProjectDash.Persistence;

namespace ProjectDash.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ProjectDashDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public QueryTestFixture() 
        {
            Context = ProjectDashContextFactory.Create();
            var configurationBuilder = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IProjectDashDbContext).Assembly));
            });
            Mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose()
        {
            ProjectDashContextFactory.Destroy(Context);
        }

    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

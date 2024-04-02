
using ProjectDash.Persistence;

namespace ProjectDash.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ProjectDashDbContext Context;

        public TestCommandBase()
        {
            Context = ProjectDashContextFactory.Create();
        }

        public void Dispose()
        {
            ProjectDashContextFactory.Destroy(Context);
        }
    }
}

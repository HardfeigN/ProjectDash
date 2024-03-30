
namespace ProjectDash.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ProjectDashDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

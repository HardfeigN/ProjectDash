
namespace ProjectDash.Domain
{
    public class ProjectDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}

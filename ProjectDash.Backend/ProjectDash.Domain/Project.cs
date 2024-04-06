
namespace ProjectDash.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }
        public ICollection<ProjectEmployee> Employees { get; set; }
        public ICollection<ProjectDocument> ProjectDocuments { get; set; }
    }
}

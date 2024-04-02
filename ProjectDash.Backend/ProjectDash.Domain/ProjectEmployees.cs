namespace ProjectDash.Domain
{
    public  class ProjectEmployees // many to many relationship
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

using System;

namespace ProjectDash.Domain
{
    public  class ProjectEmployees // many to many relationship
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}

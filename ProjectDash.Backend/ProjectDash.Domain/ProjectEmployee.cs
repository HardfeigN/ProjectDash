﻿namespace ProjectDash.Domain
{
    public  class ProjectEmployee // many to many relationship between Project and Employee
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

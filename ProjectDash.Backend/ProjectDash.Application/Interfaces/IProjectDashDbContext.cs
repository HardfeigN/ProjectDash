﻿using Microsoft.EntityFrameworkCore;

namespace ProjectDash.Domain.Interfaces
{
    public interface IProjectDashDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectEmployees> ProjectEmployees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDash.Domain;
using System;

namespace ProjectDash.Persistence.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.Property(employee => employee.Name).HasMaxLength(30).IsRequired();
            builder.Property(employee => employee.Surname).HasMaxLength(30).IsRequired();
            builder.Property(employee => employee.Patronymic).HasMaxLength(30).IsRequired();
            builder.Property(employee => employee.Email).HasMaxLength(50).IsRequired();
        }
    }
}

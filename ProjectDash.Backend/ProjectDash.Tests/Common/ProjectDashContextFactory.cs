using Microsoft.EntityFrameworkCore;
using ProjectDash.Domain;
using ProjectDash.Persistence;

namespace ProjectDash.Tests.Common
{
    public class ProjectDashContextFactory
    {
        public static Guid EmployeeIdForDelete = Guid.Parse("038B3805-5E56-4C1A-A675-92B353A423BD");
        public static Guid EmployeeIdForUpdate = Guid.Parse("D71C755E-1DD3-4DB3-BA69-593EE6C1050B");
        public static Guid EmployeeIdForDetails = Guid.Parse("F51C45CB-6A14-4025-88F7-43711C04DED7");

        public static Guid ProjectIdForEmployeeSearch = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6");

        public static ProjectDashDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectDashDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ProjectDashDbContext(options);
            context.Database.EnsureCreated();
            context.Employees.AddRange(
                new Employee
                {
                    Id = Guid.Parse("038B3805-5E56-4C1A-A675-92B353A423BD"),
                    Name = "Name1",
                    Surname = "Surname1",
                    Patronymic = "Patronymic1",
                    Email = "email1@email.com"
                },
                new Employee
                {
                    Id = Guid.Parse("D71C755E-1DD3-4DB3-BA69-593EE6C1050B"),
                    Name = "Name2",
                    Surname = "Surname2",
                    Patronymic = "Patronymic2",
                    Email = "email2@email.com"
                },
                new Employee
                {
                    Id = Guid.Parse("F51C45CB-6A14-4025-88F7-43711C04DED7"),
                    Name = "Name3",
                    Surname = "Surname3",
                    Patronymic = "Patronymic3",
                    Email = "email3@email.com"
                },
                new Employee
                {
                    Id = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E"),
                    Name = "Name4",
                    Surname = "Surname4",
                    Patronymic = "Patronymic4",
                    Email = "email4@email.com"
                },
                new Employee
                {
                    Id = Guid.Parse("AA7A7A8D-16CE-40A6-9494-5BBED71EFCA7"),
                    Name = "Name5",
                    Surname = "Surname5",
                    Patronymic = "Patronymic5",
                    Email = "email5@email.com"
                },
                new Employee
                {
                    Id = Guid.Parse("562F2BD0-9715-4439-9043-60C3D1C9B4DC"),
                    Name = "Name6",
                    Surname = "Surname6",
                    Patronymic = "Patronymic6",
                    Email = "email6@email.com"
                }
                );

            context.Projects.AddRange(
                new Project
                {
                    Id = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6"),
                    Name = "Project1",
                    Performer = "Performer1",
                    Customer = "Customer1",
                    CreationDate = new DateTime(2023, 10, 8),
                    CompletionDate = new DateTime(2023, 12, 5),
                    Priority = 10,
                    ProjectLeaderId = Guid.Parse("562F2BD0-9715-4439-9043-60C3D1C9B4DC")
                },
                new Project
                {
                    Id = Guid.Parse("A1520153-3AD8-4942-B6CD-E77116460E55"),
                    Name = "Project2",
                    Performer = "Performer2",
                    Customer = "Customer2",
                    CreationDate = new DateTime(2023, 11, 23),
                    CompletionDate = DateTime.Today,
                    Priority = 20,
                    ProjectLeaderId = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E"),
                },
                new Project
                {
                    Id = Guid.Parse("EED35383-1715-474E-B982-9A85C04E0F83"),
                    Name = "Project3",
                    Performer = "Performer3",
                    Customer = "Customer3",
                    CreationDate = new DateTime(2024, 1, 19),
                    CompletionDate = new DateTime(2024, 4, 1),
                    Priority = 40,
                    ProjectLeaderId = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E")
                }
                );

            context.ProjectEmployees.AddRange(
                    new ProjectEmployees() { EmployeeId = Guid.Parse("562F2BD0-9715-4439-9043-60C3D1C9B4DC"), ProjectId = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E"), ProjectId = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("AA7A7A8D-16CE-40A6-9494-5BBED71EFCA7"), ProjectId = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E"), ProjectId = Guid.Parse("A1520153-3AD8-4942-B6CD-E77116460E55") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("F51C45CB-6A14-4025-88F7-43711C04DED7"), ProjectId = Guid.Parse("A1520153-3AD8-4942-B6CD-E77116460E55") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("43C48CAB-5895-427B-8E17-F4FA0206315E"), ProjectId = Guid.Parse("EED35383-1715-474E-B982-9A85C04E0F83") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("D71C755E-1DD3-4DB3-BA69-593EE6C1050B"), ProjectId = Guid.Parse("EED35383-1715-474E-B982-9A85C04E0F83") },
                    new ProjectEmployees() { EmployeeId = Guid.Parse("AA7A7A8D-16CE-40A6-9494-5BBED71EFCA7"), ProjectId = Guid.Parse("EED35383-1715-474E-B982-9A85C04E0F83") }
                );

            context.ProjectDocuments.AddRange(
                    new ProjectDocument()
                    {
                        Id = Guid.Parse("9E11868B-3288-45BD-BFF6-C66A1F467AFE"),
                        Name = "Document1",
                        ProjectId = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6")
                    },
                    new ProjectDocument()
                    {
                        Id = Guid.Parse("6A455EB6-F119-473A-9F59-A08A4C8D0EDA"),
                        Name = "Document2",
                        ProjectId = Guid.Parse("73055044-A362-4616-91A0-FDE24BDDCDC6")
                    },
                    new ProjectDocument()
                    {
                        Id = Guid.Parse("2DF8961D-0596-4CC7-AC38-3CD97380B59C"),
                        Name = "Document3",
                        ProjectId = Guid.Parse("EED35383-1715-474E-B982-9A85C04E0F83")
                    },
                    new ProjectDocument()
                    {
                        Id = Guid.Parse("79D1DA33-1682-4B35-BDD9-C4F972621237"),
                        Name = "Document4",
                        ProjectId = Guid.Parse("A1520153-3AD8-4942-B6CD-E77116460E55")
                    }
                );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(ProjectDashDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

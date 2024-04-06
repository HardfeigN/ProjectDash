using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeDetailsVm => employeeDetailsVm.Id,
                    opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeDetailsVm => employeeDetailsVm.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeDetailsVm => employeeDetailsVm.Surname,
                    opt => opt.MapFrom(employee => employee.Surname))
                .ForMember(employeeDetailsVm => employeeDetailsVm.Patronymic,
                    opt => opt.MapFrom(employee => employee.Patronymic))
                .ForMember(employeeDetailsVm => employeeDetailsVm.Email,
                    opt => opt.MapFrom(employee => employee.Email));
        }
    }
}

using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList
{
    public class ProjectEmployeeLookupDto : IMapWith<ProjectEmployee>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectEmployee, ProjectEmployeeLookupDto>()
                .ForMember(projectEmployeeDto => projectEmployeeDto.ProjectId,
                    opt => opt.MapFrom(projectEmployee => projectEmployee.ProjectId))
                .ForMember(projectEmployeeDto => projectEmployeeDto.EmployeeId,
                    opt => opt.MapFrom(projectEmployee => projectEmployee.EmployeeId));
        }
    }
}

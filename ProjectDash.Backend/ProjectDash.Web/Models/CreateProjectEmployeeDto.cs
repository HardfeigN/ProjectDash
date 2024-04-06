using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.ProjectEmployees.Commands.CreateProjectEmployee;

namespace ProjectDash.Web.Models
{
    public class CreateProjectEmployeeDto : IMapWith<CreateProjectEmployeeCommand>
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<CreateProjectEmployeeDto, CreateProjectEmployeeCommand>()
                .ForMember(createPECommand => createPECommand.ProjectId,
                    opt => opt.MapFrom(createPEDto => createPEDto.ProjectId))
                .ForMember(createPECommand => createPECommand.EmployeeId,
                    opt => opt.MapFrom(createPEDto => createPEDto.EmployeeId));
        }
    }
}

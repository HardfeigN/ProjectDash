using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Projects.Commands.CreateProject;

namespace ProjectDash.WebAPI.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(createProjectCommand => createProjectCommand.Name,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.Name))
                .ForMember(createProjectCommand => createProjectCommand.Performer,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.Performer))
                .ForMember(createProjectCommand => createProjectCommand.Customer,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.Customer))
                .ForMember(createProjectCommand => createProjectCommand.StartDate,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.StartDate))
                .ForMember(createProjectCommand => createProjectCommand.EndDate,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.EndDate))
                .ForMember(createProjectCommand => createProjectCommand.Priority,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.Priority))
                .ForMember(createProjectCommand => createProjectCommand.ProjectLeaderId,
                    opt => opt.MapFrom(createProjectDto => createProjectDto.ProjectLeaderId));
        }
    }
}

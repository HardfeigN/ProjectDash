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
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectDto => projectDto.Name))
                .ForMember(projectCommand => projectCommand.Performer,
                    opt => opt.MapFrom(projectDto => projectDto.Performer))
                .ForMember(projectCommand => projectCommand.Customer,
                    opt => opt.MapFrom(projectDto => projectDto.Customer))
                .ForMember(projectCommand => projectCommand.CreationDate,
                    opt => opt.MapFrom(projectDto => projectDto.CreationDate))
                .ForMember(projectCommand => projectCommand.CreationDate,
                    opt => opt.MapFrom(projectDto => projectDto.CreationDate))
                .ForMember(projectCommand => projectCommand.Priority,
                    opt => opt.MapFrom(projectDto => projectDto.Priority))
                .ForMember(projectCommand => projectCommand.ProjectLeaderId,
                    opt => opt.MapFrom(projectDto => projectDto.ProjectLeaderId));
        }
    }
}

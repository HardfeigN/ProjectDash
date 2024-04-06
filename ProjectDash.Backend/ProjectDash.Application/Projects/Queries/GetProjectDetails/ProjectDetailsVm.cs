using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Domain;

namespace ProjectDash.Application.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsVm : IMapWith<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Customer { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectLeaderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>()
                .ForMember(projectVm => projectVm.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectVm => projectVm.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectVm => projectVm.Performer,
                    opt => opt.MapFrom(project => project.Performer))
                .ForMember(projectVm => projectVm.Customer,
                    opt => opt.MapFrom(project => project.Customer))
                .ForMember(projectVm => projectVm.StartDate,
                    opt => opt.MapFrom(project => project.StartDate))
                .ForMember(projectVm => projectVm.EndDate,
                    opt => opt.MapFrom(project => project.EndDate))
                .ForMember(projectVm => projectVm.Priority,
                    opt => opt.MapFrom(project => project.Priority))
                .ForMember(projectVm => projectVm.ProjectLeaderId,
                    opt => opt.MapFrom(project => project.ProjectLeaderId));
        }
    }
}

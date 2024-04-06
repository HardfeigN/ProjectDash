using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.Projects.Queries.GetProjectList;

namespace ProjectDash.Web.Models
{
    public class GetProjectListDto : IMapWith<GetProjectListQuery>
    {
        public string? Name { get; set; }
        public string? Performer { get; set; }
        public string? Customer { get; set; }
        public DateOnly? StartDateLeft { get; set; }
        public DateOnly? StartDateRight { get; set; }
        public DateOnly? EndDateLeft { get; set; }
        public DateOnly? EndDateRight { get; set; }
        public int? Priority { get; set; }
        public Guid? ProjectLeaderId { get; set; }
        public Guid? EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetProjectListDto, GetProjectListQuery>()
                .ForMember(getProjectListQuery => getProjectListQuery.Name,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.Name))
                .ForMember(getProjectListQuery => getProjectListQuery.Performer,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.Performer))
                .ForMember(getProjectListQuery => getProjectListQuery.Customer,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.Customer))
                .ForMember(getProjectListQuery => getProjectListQuery.StartDateLeft,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.StartDateLeft))
                .ForMember(getProjectListQuery => getProjectListQuery.StartDateRight,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.StartDateRight))
                .ForMember(getProjectListQuery => getProjectListQuery.EndDateLeft,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.EndDateLeft))
                .ForMember(getProjectListQuery => getProjectListQuery.EndDateRight,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.EndDateRight))
                .ForMember(getProjectListQuery => getProjectListQuery.Priority,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.Priority))
                .ForMember(getProjectListQuery => getProjectListQuery.ProjectLeaderId,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.ProjectLeaderId));
        }
    }
}

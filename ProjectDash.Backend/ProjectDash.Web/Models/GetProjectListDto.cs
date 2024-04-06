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
        public DateTime? CreationDateStart { get; set; }
        public DateTime? CreationDateEnd { get; set; }
        public DateTime? CompletionDateStart { get; set; }
        public DateTime? CompletionDateEnd { get; set; }
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
                .ForMember(getProjectListQuery => getProjectListQuery.CreationDateStart,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.CreationDateStart))
                .ForMember(getProjectListQuery => getProjectListQuery.CreationDateEnd,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.CreationDateEnd))
                .ForMember(getProjectListQuery => getProjectListQuery.CompletionDateStart,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.CompletionDateStart))
                .ForMember(getProjectListQuery => getProjectListQuery.CompletionDateEnd,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.CompletionDateEnd))
                .ForMember(getProjectListQuery => getProjectListQuery.Priority,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.Priority))
                .ForMember(getProjectListQuery => getProjectListQuery.ProjectLeaderId,
                    opt => opt.MapFrom(getProjectListDto => getProjectListDto.ProjectLeaderId));
        }
    }
}

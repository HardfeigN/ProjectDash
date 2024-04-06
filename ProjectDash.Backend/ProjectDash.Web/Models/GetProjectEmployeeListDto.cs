using AutoMapper;
using ProjectDash.Application.Common.Mappings;
using ProjectDash.Application.ProjectEmployees.Queries.GetProjectEmployeeList;

namespace ProjectDash.Web.Models
{
    public class GetProjectEmployeeListDto : IMapWith<GetProjectEmployeeListQuery>
    {
        public Guid? ProjectId { get; set; }
        public Guid? EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetProjectEmployeeListDto, GetProjectEmployeeListQuery>()
                .ForMember(getPEListQuery => getPEListQuery.ProjectId,
                    opt => opt.MapFrom(getPEListDto => getPEListDto.ProjectId))
                .ForMember(getPEListQuery => getPEListQuery.EmployeeId,
                    opt => opt.MapFrom(getPEListDto => getPEListDto.EmployeeId));
        }
    }
}

using AutoMapper;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using System.Diagnostics.CodeAnalysis;


namespace ProjectManagement.Services
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Project           
            CreateMap<Domain.Entities.Project, ProjectDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateProjectDto, Domain.Entities.Project>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            #endregion

            #region ProjectTask
            CreateMap<ProjectTask, ProjectTaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));

            CreateMap<CreateProjectTaskDto, ProjectTask>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
            #endregion

            #region ProjectTaskCommentDto
            CreateMap<ProjectTaskComment, ProjectTaskCommentDto > ()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProjectTaskId, opt => opt.MapFrom(src => src.ProjectTaskId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            #endregion

            #region ProjectTaskHistory
            CreateMap<ProjectTaskHistory, ProjectTaskHistoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProjectTaskId, opt => opt.MapFrom(src => src.ProjectTaskId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.OldValues, opt => opt.MapFrom(src => src.OldValues))
                .ForMember(dest => dest.NewValues, opt => opt.MapFrom(src => src.NewValues));
            #endregion
        }
    }
}

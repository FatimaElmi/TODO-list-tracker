using AutoMapper;
using TODO_list_tracker.DTOs;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Note
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<CreateNoteDto, Note>();
            CreateMap<UpdateNoteDto, Note>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // TaskItem
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<CreateTaskItemDto, TaskItem>();
            CreateMap<UpdateTaskItemDto, TaskItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
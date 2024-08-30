namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudent;

public partial class UpdateStudentCommand : IRequest<Response<StudentQueryDTO>>
{
    public int Id { get; set; }
    public UpdateStudentDTO StudentData { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateStudentCommand, Student>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentData.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.StudentData.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.StudentData.Phone))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.StudentData.DepartmentId));
        }
    }
}
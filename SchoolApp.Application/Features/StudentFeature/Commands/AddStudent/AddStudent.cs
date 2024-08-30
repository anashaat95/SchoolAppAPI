namespace SchoolApp.Application.Features.StudentFeature.Commands.AddStudent;

public class AddStudentCommand : IRequest<Response<StudentDTO>>
{
    public string Name { get; set; }
    public string Phone {get; set;}
    public string Address {get; set;}
    public int DepartmentId {get; set;}

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddStudentCommand, Student>();
            CreateMap<AddStudentCommand, StudentDTO>();
        }
    }
}

public class AddStudentCommandHandler : ResponseHandler,
    IRequestHandler<AddStudentCommand, Response<StudentDTO>>
{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public AddStudentCommandHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<StudentDTO>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        if (await _service.IsNameExistAsync(request.Name))
            return UnprocessableEntity<StudentDTO>("This student added before");

        var mappedStudent = _mapper.Map<Student>(request);
        var addedStudent = await _service.AddAsync(mappedStudent);

        if (addedStudent != null) return Created(_mapper.Map<StudentDTO>(addedStudent));
        else return BadRequest<StudentDTO>();
    }
    #endregion
}

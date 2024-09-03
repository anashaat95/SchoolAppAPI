namespace SchoolApp.Application.Features.StudentFeatrue.Commands.AddStudent;

public class AddStudentCommandHandler : ResponseHandler,
    IRequestHandler<AddStudentCommand, Response<object>>
{
    #region Field(s)
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public AddStudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<object>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        int StudentId = await _studentService.AddAsync(_mapper.Map<Student>(request));

        if (StudentId != 0) return Created<object>(new { Id = StudentId });
        else return BadRequest<object>();
    }
    #endregion
}

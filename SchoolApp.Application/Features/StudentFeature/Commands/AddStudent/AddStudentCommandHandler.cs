namespace SchoolApp.Application.Features.StudentFeature.Commands.AddStudent;

public class AddStudentCommandHandler : ResponseHandler,
    IRequestHandler<AddStudentCommand, Response<object>>
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
    public async Task<Response<object>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        int StudentId = await _service.AddAsync(_mapper.Map<Student>(request));

        if (StudentId != 0) return Created<object>(new { Id = StudentId });
        else return BadRequest<object>();
    }
    #endregion
}

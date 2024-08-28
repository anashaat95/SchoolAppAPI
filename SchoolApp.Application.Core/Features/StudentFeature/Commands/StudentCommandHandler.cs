namespace SchoolApp.Application.Core.Features.StudentFeature.Commands;

public class StudentCommandHandler : ResponseHandler,
    IRequestHandler<AddStudentCommandRequest, Response<string>>,
    IRequestHandler<EditStudentCommandRequest, Response<string>>,
    IRequestHandler<DeleteStudentCommandRequest, Response<string>>
{
    #region Field(s)
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(AddStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var newStudent = _mapper.Map<Student>(request);
        var result = await _studentService.AddAsync(newStudent);
        if (result == "Exist")
            return UnprocessableEntity<string>("This student added before");

        else if (result == "Success") return Created($"New student added successfully");
        else return BadRequest<string>("");
    }

    public async Task<Response<string>> Handle(EditStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
        if (student == null)
            return NotFound<string>("No student found with the provided name");

        var editedStudent = _mapper.Map(request, student);
        var result = await _studentService.EditAsync(editedStudent);

        if (result == "Success") return Created(result);
        else return BadRequest<string>();
    }

    public async Task<Response<string>> Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
        if (student == null) return NotFound<string>($"No student found with Id={request.Id}");

        var result = await _studentService.DeleteAsync(student);
        
        return result == "Success" ?  Deleted<string>(result) : BadRequest<string>("Failed") ;
    }
    #endregion
}

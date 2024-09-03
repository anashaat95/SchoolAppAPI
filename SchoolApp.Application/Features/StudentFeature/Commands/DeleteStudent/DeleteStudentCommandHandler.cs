namespace SchoolApp.Application.Features.StudentFeatrue.Commands.DeleteStudentCommand;

public class DeleteStudentCommandHandler : ResponseHandler,
    IRequestHandler<DeleteStudentCommand, Response<string>>
{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public DeleteStudentCommandHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _service.GetStudentById(request.Id).FirstOrDefaultAsync();
        if (student == null) return NotFound<string>($"No student found with Id={request.Id}");

        bool isDeleted = await _service.DeleteAsync(student);

        return isDeleted ? Deleted<string>("Deleted successfully") : BadRequest<string>("Failed to delete");
    }
    #endregion
}

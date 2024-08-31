namespace SchoolApp.Application.Features.StudentFeature.Queries.GetStudentById;

public record GetStudentByIdQuery : IRequest<Response<StudentQueryDTO>>
{
    public GetStudentByIdQuery(int Id)
    {
        this.Id = Id;
    }
    [Required]
    public int Id { get; set; }
}


public class GetStudentByIdQueryHandler : ResponseHandler,
      IRequestHandler<GetStudentByIdQuery, Response<StudentQueryDTO>>

{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public GetStudentByIdQueryHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<StudentQueryDTO>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _service.GetStudentById(request.Id)
                                    .Select(s => new StudentQueryDTO(s.Id, s.Name, s.Address, s.Department.Name))
                                    //.ProjectTo<StudentQueryDTO>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();
        if (student == null) return NotFound<StudentQueryDTO>($"Student with {request.Id} is not found!");
        return Success(student);
    }
    #endregion
}

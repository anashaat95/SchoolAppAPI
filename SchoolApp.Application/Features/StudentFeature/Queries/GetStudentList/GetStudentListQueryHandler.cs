namespace SchoolApp.Application.Features.StudentFeature.Queries.StudentListQuery;

public class GetStudentListQueryHandler : ResponseHandler,
      IRequestHandler<GetStudentListQuery, Response<IList<StudentQueryDTO>>>

{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public GetStudentListQueryHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<IList<StudentQueryDTO>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        var students = await _service.GetAllStudents()
                                     .Select(s => new StudentQueryDTO(s.Id, s.Name, s.Address, s.Department.Name))
                                    //.ProjectTo<StudentQueryDTO>(_mapper.ConfigurationProvider)
                                    .ToListAsync();
        return new Response<IList<StudentQueryDTO>> { Data = students, Meta = new { Count = students.Count() } };
    }
    #endregion
}

namespace SchoolApp.Application.Core.Features.StudentFeature.Queries;

public class StudentQueryHandler : ResponseHandler,
      IRequestHandler<GetStudentListQueryRequest, Response<IList<GetStudentListQueryResponse>>>,
      IRequestHandler<GetSignleStudentByIdQueryRequest, Response<GetSingleStudentByIdQueryResponse>>,
      IRequestHandler<GetStudentPaginatedListQueryRequest, PaginatedResult<GetStudentPaginatedListQueryResponse>>

{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #region Field(s)
    #endregion

    #region Constructor(s)
    public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<IList<GetStudentListQueryResponse>>> Handle(GetStudentListQueryRequest request, CancellationToken cancellationToken)
    {
        var students = await _studentService.GetAllStudentsAsync();
        var result = _mapper.Map<IList<GetStudentListQueryResponse>>(students);
        return Success(result);
    }

    public async Task<Response<GetSingleStudentByIdQueryResponse>> Handle(GetSignleStudentByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
        if (student == null) return NotFound<GetSingleStudentByIdQueryResponse>($"Student with {request.Id} is not found!");
        var result = _mapper.Map<GetSingleStudentByIdQueryResponse>(student);
        return Success(result);
    }

    public async Task<PaginatedResult<GetStudentPaginatedListQueryResponse>> Handle(GetStudentPaginatedListQueryRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Student, GetStudentPaginatedListQueryResponse>> expression = s => new GetStudentPaginatedListQueryResponse(s.Id, s.Name, s.Address, s.Department.Name);
        var queryable = _studentService.FilterStudentPaginatedQueryable(request.OrderBy!, request.Search!);
        var paginatedList = await queryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }

    #endregion
}

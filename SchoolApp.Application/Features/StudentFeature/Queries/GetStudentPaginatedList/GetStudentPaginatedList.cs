namespace SchoolApp.Application.Features.StudentFeature.Queries.GetStudentPaginatedList;

public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<StudentQueryDTO>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrderingEnum[]? OrderBy { get; set; }
    public string? Search { get; set; }
}

public class GetStudentPaginatedListQueryHandler : ResponseHandler,
      IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<StudentQueryDTO>>

{
    #region Field(s)
    private readonly IStudentService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public GetStudentPaginatedListQueryHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<PaginatedResult<StudentQueryDTO>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Student, StudentQueryDTO>> expression = s => new StudentQueryDTO { Id = s.Id, Name = s.Name, Address = s.Address, DepartmentName = s.Department.Name };
        return await _service
                                .FilterStudentAndPaginate(request.OrderBy!, request.Search!)
                                //.Select(s => new StudentQueryDTO(s.Id, s.Name, s.Address, s.Department.Name))
                                .ProjectTo<StudentQueryDTO>(_mapper.ConfigurationProvider)
                                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
    #endregion
}
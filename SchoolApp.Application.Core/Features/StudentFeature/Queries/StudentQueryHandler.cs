namespace SchoolApp.Application.Core.Features.StudentFeature.Queries;

public class StudentQueryHandler : ResponseHandler,
      IRequestHandler<GetStudentListQueryRequest, Response<IList<GetStudentListQueryResponse>>>,
      IRequestHandler<GetSignleStudentByIdQueryRequest, Response<GetSingleStudentByIdQueryResponse>>

{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #region Field(s)
    #endregion

    #region Constructor(s)
    public StudentQueryHandler(IStudentService studentService, IMapper mapper)
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
        if (student == null) NotFound<GetSingleStudentByIdQueryResponse>($"Student with {request.Id} is not found!");
        var result = _mapper.Map<GetSingleStudentByIdQueryResponse>(student);
        return Success(result);
    }

    #endregion
}

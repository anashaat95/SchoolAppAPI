namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int DepartmentId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateStudentCommand, Student>();
        }
    }


    public class UpdateStudentCommandHandler : ResponseHandler,
        IRequestHandler<UpdateStudentCommand, Response<string>>
    {
        #region Field(s)
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public UpdateStudentCommandHandler(IStudentService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _service = service;
            _mapper = mapper;
        }
        #endregion

        #region Handler(s)

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentById(request.Id).FirstOrDefaultAsync();
            if (student == null)
                return NotFound<string>("No student found with the provided name");

            var mappedStudent = _mapper.Map<Student>(request);
            bool isUpdated = await _service.UpdateAsync(mappedStudent);

            if (isUpdated) return Created<string>("Updated successfully");
            else return BadRequest<string>();
        }
        #endregion
    }
}
namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudent;

public partial class UpdateStudentCommand
{
    public class UpdateStudentCommandHandler : ResponseHandler,
        IRequestHandler<UpdateStudentCommand, Response<StudentQueryDTO>>
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

        public async Task<Response<StudentQueryDTO>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentById(request.Id).FirstOrDefaultAsync();
            if (student == null)
                return NotFound<StudentQueryDTO>("No student found with the provided name");

            
            var mappedStudent = _mapper.Map(request, student);
            bool isUpdated = await _service.UpdateAsync(mappedStudent);

            if (isUpdated) return Created<StudentQueryDTO>(_mapper.Map<StudentQueryDTO>(mappedStudent));
            else return BadRequest<StudentQueryDTO>();
        }
        #endregion
    }
}
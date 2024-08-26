using AutoMapper;
using MediatR;
using SchoolApp.Application.Core.Bases;
using SchoolApp.Application.Service.ServiceInterfaces;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands;

public class AddStudentCommandHandler : ResponseHandler,
    IRequestHandler<AddStudentCommandRequest, Response<string>>
{
    #region Field(s)
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public AddStudentCommandHandler(IStudentService studentService, IMapper mapper)
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
    #endregion
}

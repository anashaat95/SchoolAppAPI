using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.UserFeature.Commands.DeleteUserById;

public class DeleteUserByIdCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteUserByIdCommand(int id)
    {
        Id = id;
    }
}

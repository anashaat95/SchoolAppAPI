namespace SchoolApp.Application.Features.UserFeatrue.Commands.ChangeUserPasswordById;

public class ChangeUserPasswordByIdDTO
{
    public required string CrurentPassword { get; set; }
    public required string NewPassword { get; set; }
    public required string ConfirmNewPassword { get; set; }
}

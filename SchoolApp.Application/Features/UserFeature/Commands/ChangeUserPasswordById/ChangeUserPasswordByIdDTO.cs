namespace SchoolApp.Application.Features.UserFeature.Commands.ChangeUserPasswordById;

public class ChangeUserPasswordByIdDTO
{
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
    public required string ConfirmNewPassword { get; set; }
}

namespace SchoolApp.Application.Common;

public static class Helpers
{
    public static string ErrorsToString(this IdentityResult Result)
    {
        string Value = "";
        foreach (var error in Result.Errors)
        {
            Value += error.Description + "\n";
        }
        return Value;
    }
}

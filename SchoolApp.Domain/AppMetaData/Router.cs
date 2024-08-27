namespace SchoolApp.Domain.AppMetaData;

public static class Router
{
    public const string SingleRoute = "/{id}";
    public const string root = "api";
    public const string version = "v1";
    // api/v1
    public const string Rule = root + "/" + version;

    public static class StudentRoute
    {
        // api/v1/Student
        public const string Prefix = Rule + "/Student";
        // api/v1/Student/list
        public const string List = Prefix + "/list";
        // api/v1/Student/{id}
        public const string GetById = Prefix + SingleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
    }
}

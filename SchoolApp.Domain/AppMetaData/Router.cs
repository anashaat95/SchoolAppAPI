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
        public const string BASE = Rule + "/Student";
        // api/v1/Student/query? key=value
        public const string Paginated = BASE + "/query";
        // api/v1/Student/{id}
        public const string ById = BASE + SingleRoute;
    }
}

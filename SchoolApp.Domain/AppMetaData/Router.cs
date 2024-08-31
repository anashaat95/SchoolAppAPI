namespace SchoolApp.Domain.AppMetaData;

public static class Router
{
    private const string _root = "api";
    private const string _version = "v1";
    
    // api/v1
    private const string _Rule = _root + "/" + _version;

    // sub routes
    // api/v1/Student/{Id}
    private const string _ById = "/{Id}";
    // api/v1/<Controller>/query? key=value & key=value
    private const string _Query = "/query";

    public class StudentRouter()
    {
        public const string BASE = _Rule + "/Student";
        public const string ById = BASE + _ById;
        public const string Query = BASE + _Query;
    }

    public class UserRouter()
    {
        public const string BASE = _Rule + "/User";
        public const string ById = BASE + _ById;
        public const string Query = BASE + _Query;
    }
}

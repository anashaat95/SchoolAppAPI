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
        public const string BASE = _Rule + "/student";
        public const string ById = BASE + _ById;
        public const string Query = BASE + _Query;
    }

    public class UserRouter()
    {
        public const string BASE = _Rule + "/user";
        public const string ById = BASE + _ById;
        public const string Query = BASE + _Query;
        public const string ChangePassword = BASE + _ById + "/change-password";
    }
    public class AuthenticationRouter()
    {
        public const string BASE = _Rule + "/authentication";
        public const string SignIn = BASE + "/signin";
        public const string RefreshToken = BASE + "/refresh-token";
        public const string ValidateRefreshToken = BASE + "/validate-refresh-token/{token}";
        public const string Logout = BASE + "logout";
    }

    public class AuthorizationRouter()
    {
        public const string BASE = _Rule + "/authorization";
        public const string ById = BASE + _ById;
        public const string Query = BASE + _Query;

        public class RoleRouter()
        {
            public const string BASE = AuthorizationRouter.BASE + "/role";
            public const string ById = BASE + _ById;
            public const string Query = BASE + _Query;
        }
    }
}

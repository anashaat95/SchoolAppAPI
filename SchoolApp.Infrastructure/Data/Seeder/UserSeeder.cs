namespace SchoolApp.Infrastructrue.Data.Seeder;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration cfg)
    {
        var userCount = await userManager.Users.CountAsync();
        if (userCount < 2)
        {
            string APP_ADMIN_USER = cfg["APP_ADMIN_USER"];
            string APP_ADMIN_PASSWORD = cfg["APP_ADMIN_PASSWORD"];

            string APP_TEST_USER = cfg["APP_TEST_USER"];
            string APP_TEST_PASSWORD = cfg["APP_TEST_PASSWORD"];

            if (string.IsNullOrWhiteSpace(APP_ADMIN_USER)) APP_ADMIN_USER = "admin";
            if (string.IsNullOrWhiteSpace(APP_ADMIN_PASSWORD)) APP_ADMIN_PASSWORD = "AA!!aa123456";
            if (string.IsNullOrWhiteSpace(APP_TEST_USER)) APP_TEST_USER = "tester";
            if (string.IsNullOrWhiteSpace(APP_TEST_PASSWORD)) APP_TEST_PASSWORD = "UU!!uu123456";

            var admin = new User
            {
                UserName = APP_ADMIN_USER,
                Email = "anashaat95@gmail.com",
                EmailConfirmed = true,
                FirstName = "Ahmed",
                LastName = "Nashaat",
                Address = "Alraydania",
                Country = "Egypt",
                PhoneNumber = "01069427021",
                PhoneNumberConfirmed = true,
            };

            var user = new User
            {
                UserName = APP_TEST_USER,
                Email = "anashaat95@mans.edu.eg",
                EmailConfirmed = true,
                FirstName = "Ahmed",
                LastName = "Nashaat",
                Address = "Alraydania",
                Country = "Egypt",
                PhoneNumber = "01069427021",
                PhoneNumberConfirmed = true,
            };

            IdentityResult result = new IdentityResult();
            var adminRole = await roleManager.Roles.Where(r => r.Name == "ADMIN").FirstOrDefaultAsync();
            var userRole = await roleManager.Roles.Where(r => r.Name == "USER").FirstOrDefaultAsync();

            if (adminRole == null)
                throw new NullReferenceException("Failed to fetch ADMIN role");

            if (userRole == null)
                throw new NullReferenceException("Failed to fetch USER role");

            admin.UserRoles!.Add(new UserRole { Role = adminRole });
            admin.UserRoles!.Add(new UserRole { Role = userRole });

            result = await userManager.CreateAsync(admin, APP_ADMIN_PASSWORD);
            result = await userManager.CreateAsync(user, APP_TEST_PASSWORD);

            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.FirstOrDefault()!.Description);
        }
    }
}

namespace SchoolApp.Infrastructrue.Data.Seeder;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<User> userManager, IConfiguration cfg)
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
                Roles = new List<Role> { new Role { Name = "ADMIN", NormalizedName="ADMIN" } }
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
                Roles = new List<Role> { new Role {Name ="USER", NormalizedName = "USER" } }
            };

           await userManager.CreateAsync(admin, APP_ADMIN_PASSWORD);
            await userManager.CreateAsync(user, APP_TEST_PASSWORD);
        }
    }
}

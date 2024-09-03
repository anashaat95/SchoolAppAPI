namespace SchoolApp.Infrastructure.Data.Seeder;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        var userCount = await userManager.Users.CountAsync();
        if (userCount < 2)
        {
            var admin = new User
            {
                UserName = "admin",
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
                UserName = "user1",
                Email = "anashaat95@mans.edu.eg",
                EmailConfirmed = true,
                FirstName = "Ahmed",
                LastName = "Nashaat",
                Address = "Alraydania",
                Country = "Egypt",
                PhoneNumber = "01069427021",
                PhoneNumberConfirmed = true,
            };

            await userManager.CreateAsync(admin, "A!a123456");
            await userManager.CreateAsync(user, "A!a123456");
            await userManager.AddToRoleAsync(admin, "ADMIN" );
            await userManager.AddToRoleAsync(user, "USER" );
        }
    }
}

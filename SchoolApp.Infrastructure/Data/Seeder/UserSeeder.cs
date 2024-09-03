namespace SchoolApp.Infrastructrue.Data.Seeder;

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
                Roles = new List<Role> { new Role { Name = "ADMIN", NormalizedName="ADMIN" } }
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
                Roles = new List<Role> { new Role {Name ="USER", NormalizedName = "USER" } }
            };

            await userManager.CreateAsync(admin, "A!a123456");
            await userManager.CreateAsync(user, "A!a123456");
        }
    }
}

namespace SchoolApp.Infrastructrue.Data.Seeder;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {
        var userCount = await roleManager.Roles.CountAsync();
        if (userCount < 2)
        {
            await roleManager.CreateAsync(new Role { Name = "ADMIN", NormalizedName = "ADMIN" });
            await roleManager.CreateAsync(new Role { Name = "USER", NormalizedName = "USER"   });
        }

    }
}

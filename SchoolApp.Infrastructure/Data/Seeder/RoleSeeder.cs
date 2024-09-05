namespace SchoolApp.Infrastructrue.Data.Seeder;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {
        var userCount = await roleManager.Roles.CountAsync();
        if (userCount < 2)
        {
            IdentityResult result = new IdentityResult();
            result = await roleManager.CreateAsync(new Role { Name = "ADMIN", NormalizedName = "ADMIN" });
            result = await roleManager.CreateAsync(new Role { Name = "USER", NormalizedName = "USER"   });

            if (!result.Succeeded)
                throw new InvalidOperationException(result.Errors.FirstOrDefault().Description);
        }

    }
}

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebAppIdentityCore.Models
{
    public class UserRepository
    {
        UserManager<IdentityUser> manager;
        public UserRepository(UserManager<IdentityUser> userManager)
        {
            this.manager = userManager;
        }

        public async Task<IdentityResult> Add(RegisterModel model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            return await manager.CreateAsync(user, model.Password);
        }

        public async Task<IdentityUser?> Login(LoginModel obj)
        {
            var user = await manager.FindByNameAsync(obj.U);
            if (user != null)
            {
                var result = await manager.CheckPasswordAsync(user, obj.P);
                if (result)
                {
                    return user;
                }
            }
            return null;
        }

        public List<IdentityUser> GetUsers()
        {
            return manager.Users.ToList();
        }
    }
}

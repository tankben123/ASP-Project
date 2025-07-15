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

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await manager.FindByEmailAsync(email);
            if (user != null)
            {
                return await manager.GenerateEmailConfirmationTokenAsync(user);
            }
            return null;
        }

        public async Task<IdentityResult?> ConfirmEmailAsync(string email, string token)
        {
            var user = await manager.FindByEmailAsync(email);
            if (user != null)
            {
                return await manager.ConfirmEmailAsync(user, token);
            }
            return null;
        }

        public async Task<string?> GeneratePasswordResetToken(string email)
        {
            var user = await manager.FindByEmailAsync(email);
            if (user != null)
            {
                return await manager.GeneratePasswordResetTokenAsync(user);
            }
            return null;
        }

        public async Task<IdentityUser?> GetUser(string id)
        {
            return await manager.FindByIdAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace WebAppIdentityCore.Models
{
    public class UserRepository
    {
        UserManager<IdentityUser> manager;
        readonly RoleManager<IdentityRole> roleManager;
        public UserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.manager = userManager;
            this.roleManager = roleManager;
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

        public async Task<IList<string>?> GetRolesByUser(string id)
        {
            var user = await manager.FindByIdAsync(id);
            if(user!= null)
                return await manager.GetRolesAsync(user);

            return null;
        }

        public async Task<IdentityResult?> Add(IdentityUserRole<string> obj)
        {
            var user = await manager.FindByIdAsync(obj.UserId);
            var role = await roleManager.FindByIdAsync(obj.RoleId);
            if (user != null && role != null && role.Name != null)
            {
                var roles = await manager.GetRolesAsync(user);
                if (roles != null && roles.Any(p => p.Equals(role.Name)))
                {
                     return await manager.RemoveFromRoleAsync(user, role.Name);
                }   

                return await manager.AddToRoleAsync(user, role.Name);
            }   

            return null;
        }
    }
}

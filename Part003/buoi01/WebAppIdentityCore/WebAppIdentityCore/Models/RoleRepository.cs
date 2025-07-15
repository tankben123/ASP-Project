using Microsoft.AspNetCore.Identity;

namespace WebAppIdentityCore.Models
{
    public class RoleRepository
    {
        readonly RoleManager<IdentityRole> manager;

        public RoleRepository(RoleManager<IdentityRole> manager)
        {
            this.manager = manager;
        }

        public List<IdentityRole> GetRoles()
        {
            return manager.Roles.ToList();
        }

        public async Task<IdentityResult> Add(IdentityRole obj)
        {
            return await manager.CreateAsync(obj);
        }

        public async Task<IdentityResult?> Delete(string id)
        {
            var role = await GetRoleById(id);
            if (role != null)
                return await manager.DeleteAsync(role);
            return null;
        }

        public async Task<IdentityResult?> Edit(IdentityRole obj)
        {
            return await manager.UpdateAsync(obj);
        }

        public async Task<IdentityRole?> GetRoleById(string id)
        {
            return await manager.FindByIdAsync(id);
        }
    }
}

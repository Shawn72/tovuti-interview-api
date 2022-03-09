using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TovutiAPI.DBContexts;
using TovutiAPI.Interface;
using TovutiAPI.Models;

namespace TovutiAPI.Repository
{
    public class RolesRepository : IRoles
    {
        RoleManager<IdentityRole> _roleManager;
        public UserManager<UserModel> _userManager;
        public readonly DatabaseContext _context;

        public RolesRepository(RoleManager<IdentityRole> roleManager, UserManager<UserModel> userMrg, DatabaseContext context)
        {
            _roleManager = roleManager;
            _userManager = userMrg;
            _context = context;
        }
        public async Task CreateRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteRole(IdentityRole role)
        {
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public IdentityRole GetRole(string id) =>
            _roleManager.Roles.FirstOrDefault(p => p.Id.Equals(id));

        public async Task UpdateRole(IdentityRole role, IdentityRole dBrole)
        {
            dBrole.Name = role.Name;
            dBrole.NormalizedName = role.NormalizedName;
            await _roleManager.UpdateAsync(dBrole);
        }

        public async Task RemoveUserRole(RoleModification roleModel)
        {
            var userId = roleModel.Id;
            UserModel user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, roleModel.RoleName);
            }
        }

        public async Task AddUserRole(RoleModification roleModel)
        {
            try
            {
                var userId = roleModel.UserId;
                UserModel user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, roleModel.RoleName);
                }
            }
            catch (Exception ex)
            { /* ex.Message;*/ }
        }

        public UserModel GetUser(string id) =>
            _context.aspnetusers.FirstOrDefault(p => p.Id.Equals(id));

        public async Task DeleteAUser(UserModel userModel)
        {
            _context.Remove(userModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _context.aspnetusers.ToListAsync();
        }
    }
}

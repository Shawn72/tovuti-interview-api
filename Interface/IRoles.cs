using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TovutiAPI.Models;

namespace TovutiAPI.Interface
{
    public interface IRoles
    {
        Task CreateRole(IdentityRole role);
        IdentityRole GetRole(string id);
        Task<IEnumerable<IdentityRole>> GetAllRoles();
        Task UpdateRole(IdentityRole role, IdentityRole dBrole);
        Task DeleteRole(IdentityRole role);

        //user role management
        Task<IEnumerable<UserModel>> GetAllUsers();
        UserModel GetUser(string id);
        Task AddUserRole(RoleModification roleModel);
        Task RemoveUserRole(RoleModification roleModel);
        Task DeleteAUser(UserModel userModel);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TovutiAPI.Auths;
using TovutiAPI.Interface;
using TovutiAPI.Models;

namespace TovutiAPI.Controllers
{
    [BasicAuthentication]
    [ApiController]
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private readonly IRoles _repo;

        public RolesController(IRoles repo) //create constructor
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            try
            {
                return Ok(await _repo.GetAllRoles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("allusers")]
        public async Task<IActionResult> GetAllmyUsers()
        {
            try
            {
                return Ok(await _repo.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody] IdentityRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            role.NormalizedName = role.Name.ToUpper();
            if (role == null)
                return BadRequest();

            await _repo.CreateRole(role);

            return Created("", role);
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(string id)
        {
            var role = _repo.GetRole(id);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] IdentityRole role)
        {
            // additional product and model validation checks
            var dbRole = _repo.GetRole(id);
            if (dbRole == null)
                return NotFound();
            await _repo.UpdateRole(role, dbRole);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = _repo.GetRole(id);
            if (role == null)
                return NotFound();
            await _repo.DeleteRole(role);
            return Ok();
        }

        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var dbUser = _repo.GetUser(id);
            if (dbUser == null)
                return NotFound();
            await _repo.DeleteAUser(dbUser);
            return Ok();
        }

        [HttpPost("addusertorole")]
        public async Task<IActionResult> AddUserToRole([FromBody] RoleModification role)
        {
            if (role == null)
                return BadRequest();
            await _repo.AddUserRole(role);
            return Ok();
        }

        [HttpPost("removeuserrole")]
        public async Task<IActionResult> RemoveUserfromRole([FromBody] RoleModification role)
        {
            if (role == null)
                return BadRequest();
            await _repo.RemoveUserRole(role);
            return Ok();
        }
    }
}


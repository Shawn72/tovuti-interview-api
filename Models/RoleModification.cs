using System.ComponentModel.DataAnnotations;

namespace TovutiAPI.Models
{
    public class RoleModification
    {
        [Key]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}

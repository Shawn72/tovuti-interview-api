using System.ComponentModel.DataAnnotations;

namespace TovutiAPI.Models
{
    public class RoleModel
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}

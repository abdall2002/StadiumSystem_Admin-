using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StatiumSystem.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

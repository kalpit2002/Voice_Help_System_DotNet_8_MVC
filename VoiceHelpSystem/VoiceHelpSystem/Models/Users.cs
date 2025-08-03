using Microsoft.AspNetCore.Identity;

namespace VoiceHelpSystem.Models
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set; }
    }
}

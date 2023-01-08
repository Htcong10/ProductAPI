using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ProductAPI.DTo
{
    public class UserDto
    {
        public string Username { get; set; }    

        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public List<Claim> ClaimUser { get; set; }
        public UserDto(string username, string email, List<string> roles, List<Claim> claimuser)
        {

            Email = email;
            Username = username;
            Roles = roles;
            ClaimUser = claimuser;  
        }
    }
}

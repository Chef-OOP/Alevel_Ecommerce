using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ECommerce_JWT.Extensions
{
    public static class ClaimExtension
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(type: JwtRegisteredClaimNames.Email, value: email));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(type: ClaimTypes.Name, value: name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(type: ClaimTypes.NameIdentifier, value: nameIdentifier));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(type: ClaimTypes.Role, value: role)));
        }
    }
}

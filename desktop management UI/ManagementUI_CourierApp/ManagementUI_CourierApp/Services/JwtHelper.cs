using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUI_CourierApp.Services
{
    public static class JwtHelper
    {
        public static string GetRoleFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "roles");
                return roleClaim?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting role from token: " + ex.Message);
                return null;
            }
        }
    }
    
}

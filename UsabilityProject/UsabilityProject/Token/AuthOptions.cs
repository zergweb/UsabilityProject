using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace UsabilityProject.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "http://localhost:8080/"; 
        const string KEY = "dn38dh47dfg5tfgfh345i67yty33256676834";   
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

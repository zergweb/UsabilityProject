using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsabilityProject.Services.UserManager;
using UsabilityProject.Token;

namespace UsabilityProject.Controllers
{
    public class AccountController : Controller
    {
        MyUserManager userManager;
        public AccountController(MyUserManager _userManager)
         {
            userManager = _userManager;
         }
        [HttpGet("/createfakeusers")]
        public void CreateFakeUsers()
        {
            userManager.CreateFakeUsers();
        }


        [HttpPost("/token")]
        public async Task Token()
        {
            
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var identity = userManager.GetIdentity(username, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);          
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                role = identity.Claims
                 .Where(c => c.Type == ClaimTypes.Role)
                 .Select(c => c.Value)
        };
            Response.ContentType = "application/json";
            Response.StatusCode = 200;
            await HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

        }
    }
}

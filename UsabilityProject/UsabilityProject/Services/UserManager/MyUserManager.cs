using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UsabilityProject.Model;

namespace UsabilityProject.Services.UserManager
{
    public class MyUserManager
    {
        public MyUserManager()
        {

        }
        public void CreateFakeUsers()
        {
            List<AppUser> users = new List<AppUser>();
            DateTime Start = new DateTime(1986, 1, 1);
            DateTime Stop = new DateTime(2000, 12, 28);
            Random rand = new Random();
            for (int i=0;i<100;i++)
            {
                users.Add(new AppUser
                {
                    RoleId = 3,
                    Login = "fake_user" + i.ToString(),
                    Password = CreatePassword(5),
                    Date = RandomDay(Start, Stop),
                    Name = "fake_name" + i.ToString(),
                    DepartmentId = rand.Next(1, 5)
                });
            }
            using(AppDbContext db= new AppDbContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }
        public AppUser RegisterNewUser(String name)
        {
            using (AppDbContext db = new AppDbContext())
            {
                AppUser pers = db.Users.Include(p => p.Role).FirstOrDefault(x => x.Login == name);
                if (pers == null)
                {
                    AppUser newUser = new AppUser
                    {
                        Name = name,
                        Date = DateTime.Now,
                        Login = name,
                        Password = CreatePassword(20),
                        RoleId = 2
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return newUser;
                }
                else
                {
                    return pers;
                }
            }          
        }
        public ClaimsIdentity GetIdentity(string username, string password)
        {
            using(AppDbContext db = new AppDbContext())
            {
                AppUser person = db.Users.Include(p => p.Role).FirstOrDefault(x => x.Login == username && x.Password == password);
                if (person != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.RoleName),

                };
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
                return null;
            }           
        }
        private string CreatePassword(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                int numb = Convert.ToInt32(Math.Floor(52 * random.NextDouble()));
                numb += (numb < 27) ? 65 : 70;
                ch = Convert.ToChar(numb);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        private DateTime RandomDay(DateTime start, DateTime stop)
        {
            Random rnd = new Random();
            return start.AddDays(rnd.Next(0, new TimeSpan(stop.Ticks - start.Ticks).Days));
        }
    }
}

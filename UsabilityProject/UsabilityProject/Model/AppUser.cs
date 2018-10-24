using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsabilityProject.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public int? RoleId { get; set; }
        public AppRole Role { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public int? DepartmentId{ get; set; }
        public Department Department { get; set; }
    }
}

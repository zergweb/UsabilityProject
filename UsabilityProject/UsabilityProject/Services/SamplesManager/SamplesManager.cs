using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsabilityProject.Model;

namespace UsabilityProject.Services.SamplesManager
{
    public class SamplesManager : ISamplesManager
    {
        AppDbContext db;
        public SamplesManager(AppDbContext _db)
        {
            db = _db;
        }
        public void CreateFakeSamples()
        {
            List<AppUser> workers = db.Users.Where(w=>w.RoleId==3).ToList();
            List<Sample> samples = new List<Sample>();
            Random rand = new Random();
            DateTime date = DateTime.Now;
            foreach (AppUser worker in workers)
            {
                samples.Add(new Sample {
                    Date = date,Pulse = rand.Next(50, 100),
                    AppUserId =worker.Id,
                    Temperature =36.6f,
                    StressFactor =rand.Next(0,100)
                });
            }
           db.Samples.AddRange(samples);
           db.SaveChanges();
        }

        public List<SampleToJson> getSamplesList()
        {
            
            List<SampleToJson> samples = db.Samples.Include(d=>d.User)
            .ThenInclude(x=>x.Role)
            .Select(p => new SampleToJson
            {
                Id = p.Id,
                StressFactor = p.StressFactor,
                Pulse = p.Pulse,
                Temperature = p.Temperature,
                User = p.User,
                Date = p.Date.ToString("dd/MM/yyyy")
            })
            .ToList();
            return samples;
        }
    }
}

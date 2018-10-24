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
           db.SampleDates.Add(new SampleDate { Date = date });
           db.SaveChanges();
        }

        public async Task<List<SampleToJson>> getSamplesList()
        {
            SampleDate lastSampleDate = db.SampleDates.LastOrDefault();
            IQueryable<Sample> samples = db.Samples
            .Include(d => d.User)
                .ThenInclude(x => x.Role)
            .Include(d => d.User)
                .ThenInclude(x => x.Department);
            if (lastSampleDate != null)
            {
              samples=samples.Where(a => a.Date == lastSampleDate.Date);
            }           
          // IQueryable<SampleToJson> sampleToJsons= samples.Select(p => new SampleToJson
           // {
             //   Id = p.Id,
             //   StressFactor = p.StressFactor,
             //   Pulse = p.Pulse,
              //  Temperature = p.Temperature,
              //  User = p.User,
              //  Date = p.Date.ToString("dd/MM/yyyy")
          //  }).OrderBy(x=>x.StressFactor);
            List<Sample> lSamples= await samples.AsNoTracking().ToListAsync();            
            return SampleToJson(lSamples);
        }
        public async Task<List<SampleToJson>> getCustomSamplesList(SamplesSelectionModel sm)
        {
            IQueryable<Sample> query = db.Samples.Include(d => d.User).ThenInclude(x => x.Role);
            query = new QueryBuilder(sm, query).getQuery();
           // await samples.AsNoTracking().ToListAsync(); ;
            // IQueryable<Sample> samples = db.Samples
            //    .Include(d => d.User)
            //   .ThenInclude(x => x.Role)
            //   .Where(a => a.Pulse > 90 );
            // samples = samples.Where(a => a.Id > 80);

            return SampleToJson(await query.AsNoTracking().ToListAsync());
               
        }
        private List<SampleToJson> SampleToJson(List<Sample> samples)
        {
            List<SampleToJson> sjt = new List<SampleToJson>();
            foreach (Sample p in samples)
            {
                sjt.Add(new SampleToJson
                {
                    Id = p.Id,
                    StressFactor = p.StressFactor,
                    Pulse = p.Pulse,
                    Temperature = p.Temperature,
                    User = p.User,
                    Date = p.Date.ToString("hh:mm - dd/MM/yyyy")
                });
            }
            return sjt;
        }
    }
}

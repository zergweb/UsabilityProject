using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsabilityProject.Model;
using UsabilityProject.Services.SamplesManager;
using Xunit;

namespace UsabilityProject.Tests
{
    public class SamplesManagerTest
    {
        [Fact]
        public void GetSamplesList()
        {
            using(AppDbContext db = new AppDbContext())
            {
            // Arrange          
            var sm = new SamplesManager(db);
            // Act
            var result = sm.getSamplesList();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<List<SampleToJson>>>(result);
            }           
        }
        [Fact]
        public void GetCustomSamplesList()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Arrange          
                var sm = new SamplesManager(db);
                var selection = new SamplesSelectionModel { StartPulse = 60, EndPulse = 90 };
                // Act
                var result = sm.getCustomSamplesList(selection);
                // Assert
                Assert.NotNull(result);
                Assert.IsType<Task<List<SampleToJson>>>(result);
            }
        }
    }
}

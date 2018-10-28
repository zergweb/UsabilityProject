using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsabilityProject.Controllers;
using UsabilityProject.Model;
using UsabilityProject.Services.SamplesManager;
using Xunit;

namespace UsabilityProject.Tests
{
    
    public class SamplesControllerTests
    {
        [Fact]
        public void GetSamplesReturnData()
        {
            // Arrange
            var mock = new Mock<ISamplesManager>();           
            mock.Setup(sm => sm.getSamplesList()).Returns(Task.FromResult(getFakeSamples()));
            var controller = new SamplesController(mock.Object);
            // Act
            var result = controller.GetSamples();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<JsonResult>>(result);                    
        }
        [Fact]
        public void GetCustomSamplesReturnData()
        {
            // Arrange
            var mock = new Mock<ISamplesManager>();
            var selection = new SamplesSelectionModel { };
            mock.Setup(sm => sm.getCustomSamplesList(selection)).Returns(Task.FromResult(getFakeSamples()));
            var controller = new SamplesController(mock.Object);
            // Act
            var result = controller.GetSamples();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<JsonResult>>(result);
        }
        private List<SampleToJson> getFakeSamples()
        {          
            //return await Task.Run(()=>{
                List<SampleToJson> samples = new List<SampleToJson> {
                new SampleToJson{ Id=1}, new SampleToJson{ Id=2}, new SampleToJson{ Id=3}
            };
                return samples;
           // });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UsabilityProject.Controllers;
using Xunit;

namespace UsabilityProject.Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetResultNotNull()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            // Act
            IEnumerable<string> result = controller.Get() as IEnumerable<string>;
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IEnumerable<string> result = controller.Get() as IEnumerable<string>;

            // Assert
            Assert.Equal(new string[]{ "value1", "value2" }, result);
        }

    }
}

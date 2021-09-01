using BTTest.Server.Controllers;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace BTTest.Server.Tests.Controllers
{
    public class CardsControllerTests
    {
        [Theory]
        [InlineData("2S", 8)]
        [InlineData("4S", 16)]
        [InlineData("JR", 0)]

        public void CardsController_Get_ValidResults(string handRep, int expectedValue)
        {
            var controller = new CardsController();

            OkObjectResult result = (OkObjectResult)controller.GetValue(handRep);
            Assert.Equal(expectedValue, (int)result.Value);
        }


        [Theory]
        [InlineData("*", "Invalid input string")]
        [InlineData("***", "Invalid input string")]
        [InlineData("1D", "Card not recognised")]
        [InlineData("Ts", "Card not recognised")]

        public void CardsController_Get_InvalidResults(string handRep, string errorMessage)
        {
            var controller = new CardsController();

            BadRequestObjectResult result = (BadRequestObjectResult)controller.GetValue(handRep);
            Assert.Equal(errorMessage, (string)result.Value);
        }
    }
}

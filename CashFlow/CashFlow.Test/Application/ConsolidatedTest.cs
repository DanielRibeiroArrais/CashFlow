using CashFlow.Application.DTO.DTO;
using CashFlow.Application.Interfaces;
using CashFlow.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CashFlow.Test.Application
{
    public class ConsolidatedTest
    {
        private readonly Mock<ILogger<ConsolidatedController>> _loggerMock;
        private readonly Mock<IApplicationServiceConsolidated> _applicationServiceConsolidatedMock;

        public ConsolidatedTest()
        {
            _applicationServiceConsolidatedMock = new Mock<IApplicationServiceConsolidated>();
            _loggerMock = new Mock<ILogger<ConsolidatedController>>();
        }

        [Fact]
        public async Task Get_Consolidated_Success()
        {
            //Arrange
            int fakeId = 1;
            decimal fakeTotal = 1000;
            int fakeOperationYear = 2023;
            int fakeOperationMonth = 3;

            var fakeConsolidatedDTO = GetCustomerBasketFake(fakeId, fakeTotal, fakeOperationYear, fakeOperationMonth);

            _applicationServiceConsolidatedMock
                .Setup(x => x.GetByMonthYearAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(fakeConsolidatedDTO));


            //Act
            var consolidatedController = 
                new ConsolidatedController(_loggerMock.Object, _applicationServiceConsolidatedMock.Object);

            var actionResult = await consolidatedController.GetByMonthYearAsync(fakeOperationMonth, fakeOperationYear);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as ConsolidatedDTO).Id, fakeId);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as ConsolidatedDTO).Total, fakeTotal);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as ConsolidatedDTO).OperationYear, fakeOperationYear);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as ConsolidatedDTO).OperationMonth, fakeOperationMonth);
        }

        private ConsolidatedDTO GetCustomerBasketFake(int fakeId, decimal fakeTotal, int fakeOperationYear, int fakeOperationMonth)
        {
            return new ConsolidatedDTO
            {
                Id = fakeId,
                Total = fakeTotal,
                OperationYear = fakeOperationYear,
                OperationMonth = fakeOperationMonth
            };
        }
    }
}

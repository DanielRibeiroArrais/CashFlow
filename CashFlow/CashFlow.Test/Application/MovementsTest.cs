using CashFlow.Application.DTO.DTO;
using CashFlow.Application.DTO.Enum;
using CashFlow.Application.Interfaces;
using CashFlow.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CashFlow.Test.Application
{
    public class MovementsTest
    {
        private readonly Mock<ILogger<MovementsController>> _loggerMock;
        private readonly Mock<IApplicationServiceMovements> _applicationServiceMovementsMock;

        public MovementsTest()
        {
            _loggerMock = new Mock<ILogger<MovementsController>>();
            _applicationServiceMovementsMock = new Mock<IApplicationServiceMovements>();
        }

        [Fact]
        public async Task Get_Movements_Success()
        {
            //Arrange
            int fakeId = 1;
            EnumMovementType fakeMovementType = EnumMovementType.Credit;
            string fakeDescription = "description";
            string? fakeObservation = null;
            decimal fakeValue = 100;
            DateTime fakeOperationDate = DateTime.UtcNow;

            var fakeMovementsDTO = MovementsDTOFake(fakeId, fakeMovementType, fakeDescription, fakeObservation, fakeValue, fakeOperationDate);

            _applicationServiceMovementsMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(fakeMovementsDTO));

            //Act
            var movementsController =
                new MovementsController(_loggerMock.Object, _applicationServiceMovementsMock.Object);

            var actionResult = await movementsController.GetByIdAsync(fakeId);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Id, fakeId);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).MovementType, EnumMovementType.Credit);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Description, fakeDescription);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Observation, fakeObservation);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Value, fakeValue);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).OperationDate, fakeOperationDate);
        }

        [Fact]
        public async Task Post_Movements_Success()
        {
            //Arrange
            int fakeId = 1;
            EnumMovementType fakeMovementType = EnumMovementType.Credit;
            string fakeDescription = "description";
            string? fakeObservation = null;
            decimal fakeValue = 100;
            DateTime fakeOperationDate = DateTime.UtcNow;

            var fakeMovementsDTO = MovementsDTOFake(fakeId, fakeMovementType, fakeDescription, fakeObservation, fakeValue, fakeOperationDate);

            _applicationServiceMovementsMock
                .Setup(x => x.CreateAsync(It.IsAny<MovementsDTO>()))
                .Returns(Task.FromResult(fakeMovementsDTO));

            //Act
            var movementsController =
                new MovementsController(_loggerMock.Object, _applicationServiceMovementsMock.Object);

            var actionResult = await movementsController.CreateAsync(fakeMovementsDTO);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Id, fakeId);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).MovementType, EnumMovementType.Credit);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Description, fakeDescription);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Observation, fakeObservation);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Value, fakeValue);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).OperationDate, fakeOperationDate);
        }

        [Fact]
        public async Task Put_Movements_Success()
        {
            //Arrange
            int fakeId = 1;
            EnumMovementType fakeMovementType = EnumMovementType.Credit;
            string fakeDescription = "description";
            string? fakeObservation = null;
            decimal fakeValue = 100;
            DateTime fakeOperationDate = DateTime.UtcNow;

            var fakeMovementsDTO = MovementsDTOFake(fakeId, fakeMovementType, fakeDescription, fakeObservation, fakeValue, fakeOperationDate);

            _applicationServiceMovementsMock
                .Setup(x => x.UpdateAsync(It.IsAny<MovementsDTO>()))
                .Returns(Task.FromResult(fakeMovementsDTO));

            //Act
            var movementsController =
                new MovementsController(_loggerMock.Object, _applicationServiceMovementsMock.Object);

            var actionResult = await movementsController.UpdateAsync(fakeMovementsDTO.Id, fakeMovementsDTO);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Id, fakeId);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).MovementType, EnumMovementType.Credit);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Description, fakeDescription);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Observation, fakeObservation);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).Value, fakeValue);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as MovementsDTO).OperationDate, fakeOperationDate);
        }

        private MovementsDTO MovementsDTOFake(int fakeId, EnumMovementType fakeMovementType, string fakeDescription, string? fakeObservation, decimal fakeValue, DateTime fakeOperationDate)
        {
            return new MovementsDTO
            {
                Id = fakeId,
                MovementType = fakeMovementType,
                Description = fakeDescription,
                Observation = fakeObservation,
                Value = fakeValue,
                OperationDate = fakeOperationDate
            };
        }
    }
}

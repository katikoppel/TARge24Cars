using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace CarTest
{
    public class CarTest : Cars.CarTest.TestBase
    {
        [Fact]
        public async Task Should_AddCar_WhenDataIsValid()
        {
            //Arrange
            CarsDto dto = MockCarDto();

            //Act
            var result = await Svc<ICarServices>().Create(dto);

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {
            //Arrange and act
            CarsDto dto = MockCarDto();
            var createCar = await Svc<ICarServices>().Create(dto);

            CarsDto updatedDto = MockUpdateCarDto();
            var updateCar = await Svc<ICarServices>().Update(updatedDto);

            //Assert
            Assert.DoesNotMatch(updateCar.Brand, createCar.Brand);
            Assert.NotEqual(createCar.ReleaseYear, updateCar.ReleaseYear);
        }

        [Fact]
        public async Task Should_AddValidCar_WhenDataTypeIsValid()
        {
            //Arrange
            var dto = new CarsDto
            {
                Brand = "Toyota",
                Model = "Corolla",
                ReleaseYear = 2010,
                Price = 5900,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            //Act
            var car = await Svc<ICarServices>().Create(dto);

            //Assert
            Assert.IsType<int>(car.Price);
            Assert.IsNotType<string>(car.ReleaseYear);
            Assert.IsType<DateTime>(car.CreatedAt);
        }

        [Fact]
        public async Task ShouldUpdateModifiedAt_WhenUpdateData()
        {
            //Arrange
            CarsDto dto = MockCarDto();
            var createcar = await Svc<ICarServices>().Create(dto);

            //Act
            CarsDto update = MockUpdateCarDto();
            var updatecar = await Svc<ICarServices>().Update(update);

            //Assert
            Assert.NotEqual(createcar.ModifiedAt, updatecar.ModifiedAt);
        }

        private CarsDto MockCarDto()
        {
            return new CarsDto
            {
                Brand = "BMW",
                Model = "320i",
                ReleaseYear = 2017,
                Price = 15900,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
        }

        private CarsDto MockUpdateCarDto()
        {
            return new CarsDto
            {
                Brand = "Ford",
                Model = "Focus",
                ReleaseYear = 2015,
                Price = 8000,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
        }
    }
}

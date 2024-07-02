using CarManagement.Dtos;
using CarManagement.RequestsResponses;

namespace CarManagement.Services
{
    public interface ICarService
    {
        // 4. Admin və user edə bilər: GetCars(), GetCarDetailByİd(), GetCarsByFilter()
        // 5. Ancag admin edə bilər: DeleteCar(), UpdateCar(), DeactiveCar()

        public Task<List<CarDto>> GetCars();
        public Task<CarDto> GetCarDetailById(int id);
        public Task<List<CarDto>> GetCarsByFilter(CarRequest request);

        public Task DeleteCar(int id);
        public Task UpdateCar(int id, CarRequest request);
        public Task DeactivateCar(int id);
    }
}

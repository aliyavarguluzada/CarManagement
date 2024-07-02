using CarManagement.Dtos;
using CarManagement.RequestsResponses;
using CarManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarContoller : ControllerBase
    {
        private readonly ICarService _carService;

        public CarContoller(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getCars")]
        public async Task<List<CarDto>> GetCars() => await _carService.GetCars();

        [HttpGet("getCarsByFilter")]
        public async Task<List<CarDto>> GetCarsByFilter(CarRequest request) => await _carService.GetCarsByFilter(request);


        [HttpGet("GetCarDetailById")]
        public async Task<CarDto> GetCarDetailById(int id) => await _carService.GetCarDetailById(id);

        [HttpPut("DeactivateCar"), Authorize(Roles = "Admin")]
        public async Task DeactivateCar(int id) => await _carService.DeactivateCar(id);


        [HttpDelete("DeleteCar"), Authorize(Roles = "Admin")]
        public async Task DeleteCar(int id) => await _carService.DeleteCar(id);


        [HttpPut("UpdateCar"), Authorize(Roles = "Admin")]
        public async Task UpdateCar(int id, CarRequest request) => await _carService.UpdateCar(id, request);

    }
}

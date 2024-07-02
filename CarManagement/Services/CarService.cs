using CarManagement.Data;
using CarManagement.Dtos;
using CarManagement.Enums;
using CarManagement.RequestsResponses;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CarDto> GetCarDetailById(int id)
        {
            var car = await _context
                .Cars
                .Where(c => c.Id == id)
                .Include(c => c.TransmissionType)
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Model)
                .Select(c => new CarDto()
                {
                    Name = c.Name,
                    BrandId = c.BrandID,
                    ModelId = c.ModelId,
                    ColorId = c.ColorId,
                    TransmissionTypeId = c.TransmissionTypeId,
                    Mileage = c.Mileage,
                    CarAvailabilityId = c.CarAvailabilityId,
                })
                .FirstAsync();

            return car;
        }

        public async Task<List<CarDto>> GetCars()
        {
            var cars = await _context
                             .Cars
                             .Include(c => c.TransmissionType)
                             .Include(c => c.Brand)
                             .Include(c => c.Color)
                             .Include(c => c.Model)
                             .Select(c => new CarDto()
                             {
                                 Name = c.Name,
                                 BrandId = c.BrandID,
                                 ModelId = c.ModelId,
                                 ColorId = c.ColorId,
                                 TransmissionTypeId = c.TransmissionTypeId,
                                 Mileage = c.Mileage,
                                 CarAvailabilityId = c.CarAvailabilityId,
                             })
                             .ToListAsync();

            return cars;

        }

        public async Task<List<CarDto>> GetCarsByFilter(CarRequest request)
        {
            var cars = await _context
                             .Cars
                             .Select(c => new CarDto()
                             {
                                 Name = c.Name,
                                 BrandId = c.BrandID,
                                 ModelId = c.ModelId,
                                 ColorId = c.ColorId,
                                 TransmissionTypeId = c.TransmissionTypeId,
                                 Mileage = c.Mileage,
                                 CarAvailabilityId = c.CarAvailabilityId

                             })
                             .Where(c => c.BrandId == request.BrandId
                             &&
                             c.ModelId == request.ModelId
                             &&
                             c.TransmissionTypeId == request.TransmissionTypeId
                             &&
                             c.ColorId == request.ColorId
                             )
                             .ToListAsync();
            return cars;
        }

        public async Task UpdateCar(int id, CarRequest request)
        {
            var car = await _context
                .Cars
                .Where(c => c.Id == id)
                 .Include(c => c.TransmissionType)
                             .Include(c => c.Brand)
                             .Include(c => c.Color)
                             .Include(c => c.Model)
                             .FirstAsync();

            car.TransmissionTypeId = request.TransmissionTypeId;
            car.ColorId = request.ColorId;
            car.ModelId = request.ModelId;
            car.BrandID = request.BrandId;
            car.CarAvailabilityId = request.AvailabilityId;

            _context.Update(car);

            await _context.SaveChangesAsync();

        }

        public async Task DeactivateCar(int id)
        {
            var car = await _context
                            .Cars
                            .Where(c => c.Id == id)
                            .FirstAsync();

            car.CarAvailabilityId = (int)CarAvailabilityEnum.Unavailable;

            _context.Update(car);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteCar(int id)
        {
            var car = await _context
            .Cars
            .Where(c => c.Id == id)
            .FirstAsync();

            _context.Remove(car);

            await _context.SaveChangesAsync();
        }

    }
}

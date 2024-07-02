namespace CarManagement.Dtos
{
    public class CarDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TransmissionTypeId { get; set; }
        public double Mileage { get; set; }
        public int CarAvailabilityId { get; set; }
    };

}

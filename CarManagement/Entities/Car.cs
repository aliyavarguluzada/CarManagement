namespace CarManagement.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TransmissionTypeId { get; set; }
        public int CarAvailabilityId { get; set; }
        public DateTime ProductionYear { get; set; }
        public double Mileage { get; set; }
        public double Price { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public CarAvailability CarAvailability { get; set; }
    }
}

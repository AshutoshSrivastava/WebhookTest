namespace AirLineWeb.Dtos
{
    public class FlightDetailReadDto
    {
        public int Id { get; set; }

        public string FlightCode { get; set; }

        // [Column(TypeName = "decimal(6,2)")]
     
        public decimal Price { get; set; }
    }
}
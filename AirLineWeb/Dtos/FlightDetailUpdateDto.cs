using System.ComponentModel.DataAnnotations;

namespace AirLineWeb.Dtos
{
    public class FlightDetailUpdateDto
    {
        // Id is in URI
        
        [Required]
        public string FlightCode { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
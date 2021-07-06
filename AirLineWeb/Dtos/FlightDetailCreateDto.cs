using System.ComponentModel.DataAnnotations;

namespace AirLineWeb.Dtos
{
    public class FlightDetailCreateDto
    {
        [Required]
        public string FlightCode { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
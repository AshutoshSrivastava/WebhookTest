using System.ComponentModel.DataAnnotations;

namespace AirLineWeb.Dtos
{
    public class WebhookSubscriptionCreateDto
    {
        [Required]
        public string WebhookURI { get; set; }

        [Required]
        public string WebhookType { get; set; }  

    }
}
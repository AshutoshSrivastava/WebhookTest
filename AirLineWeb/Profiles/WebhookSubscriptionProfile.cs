using AutoMapper;
using AirLineWeb.Dtos;
using AirLineWeb.Models;

namespace AirLineWeb.Profiles
{
    public class WebhookSubscriptionProfile : Profile
    {
        public WebhookSubscriptionProfile()
        {
         
        // Source --> Target
        CreateMap<WebhookSubscription,WebhookSubscriptionReadDto>();
        CreateMap<WebhookSubscriptionCreateDto,WebhookSubscription>();
           
        }
    }
}
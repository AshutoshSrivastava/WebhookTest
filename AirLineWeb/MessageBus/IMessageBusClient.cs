using AirLineWeb.Dtos;

namespace AirLineWeb.MessageBus
{
    public interface IMessageBusClient
    {
        void SendMessage(NotificationMessageDto notificationMessageDto);
    }
}
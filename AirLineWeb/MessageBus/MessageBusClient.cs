using System;
using System.Text;
using System.Text.Json;
using AirLineWeb.Dtos;
using RabbitMQ.Client;

namespace AirLineWeb.MessageBus
{
    public class MessageBusClient : IMessageBusClient
    {
        public void SendMessage(NotificationMessageDto notificationMessageDto)
        {
            var factory = new ConnectionFactory(){HostName = "localhost", Port = 5672};
            using( var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout); //Fanout = broadcast
                var message = JsonSerializer.Serialize(notificationMessageDto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "trigger",
                                    routingKey: "",
                                    basicProperties: null,
                                    body: body
                );
                Console.WriteLine("--> Message Published on Message Bus");
            }
        }
    }
}
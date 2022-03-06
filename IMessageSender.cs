using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface IMessageSender
    {
        string Send();
    }

    public class EmailMessageSender : IMessageSender 
    {
        public string Send() 
        {
            return "Message is sent by email.";
        }
    }

    public class SmSMessageSender : IMessageSender 
    {
        public string Send()
        {
            return "Message is sent by  SmS.";
        }
    }

    public class MessageServices
    {
        private IMessageSender _sender;
        public MessageServices(IMessageSender sender)
        {
            _sender = sender;
        }
        public string SendMessage() => _sender.Send();
    }
    public class MessageMiddleware 
    {
        private RequestDelegate _next;
        public MessageMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, MessageServices sender) 
        {
            await context.Response.WriteAsync($"{sender.SendMessage()}");
            _next?.Invoke(context);
        }
    }
}

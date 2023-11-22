using System.Net;
using System.Net.Mail;
using service.Domain;
using service.service.Interfaces;

namespace service.Service.Implementations
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfiguration _configuration;
        public SendMailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(SendMessageRequest model)
        {
            try
            {
                //TODO Добавить Mapster
                Message message = new Message
                {
                    Id = Guid.NewGuid(),
                    Body = model.Body,
                    Author = model.Author,
                    EmailFrom = _configuration.GetSection("StmpEmail").Value,
                    EmailTo = model.EmailTo,
                    Created = DateTime.Now
                };

                using (MailMessage mailMessage = new MailMessage(message.EmailFrom, message.EmailTo))
                {
                    mailMessage.Subject = message.Author;
                    mailMessage.Body = message.Body;
                    mailMessage.IsBodyHtml = false;
                    using (SmtpClient client = new SmtpClient("smtp.yandex.ru", 587))
                    {
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new NetworkCredential(_configuration.GetSection("StmpEmail").Value,
                                                                     _configuration.GetSection("StmpPassword").Value);
                        client.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                //Добавить логгирование
               Console.WriteLine(ex.Message);
            }
        }
    }
}
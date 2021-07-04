using AcademiaMW.Business.Service.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;

        public EmailService
        (
            IOptions<EmailOptions> options
        )
        {
            _options = options.Value;
        }

        public async Task EnviarEmail(Core.Domain.Email email)
        {
            var client = new SendGridClient(_options.SendGridKey);

            var msg = new SendGridMessage
            {
                From = new EmailAddress(_options.Email, _options.SendGridUser),
                Subject = email.Subject,
                PlainTextContent = email.Message,
                HtmlContent = email.Message
            };

            msg.AddTo(new EmailAddress(email.To));

            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }

    }
}

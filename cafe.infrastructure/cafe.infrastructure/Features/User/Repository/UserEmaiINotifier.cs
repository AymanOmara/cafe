using SendGrid;
using SendGrid.Helpers.Mail;
using cafe.Domain.Users.Repository;
using Microsoft.Extensions.Configuration;

namespace cafe.infrastructure.Features.User.Repository
{
	public class UserEmaiINotifier: IUserNotifier
    {
        private readonly IConfiguration _configuration;

        public UserEmaiINotifier(IConfiguration configuration)
		{
            _configuration = configuration;
		}


        public async Task Notify(string channel, string body)
        {
            var apiKey = _configuration["SendGrid:SendGridKey"];
            var senderEmail = _configuration["SendGrid:SendGridEmail"];
            
            var client = new SendGridClient(apiKey);
            var from_email = new EmailAddress(senderEmail, "Example User");
            var subject = "shift report";
            var to_email = new EmailAddress(channel, "Example User");
            var htmlContent = $"<strong>{body}</strong>";
            var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, body, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}


using Microsoft.AspNetCore.Identity.UI.Services;

namespace StatiumSystem.Data
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // يمكنك وضع Log هنا أو تركه فارغاً
            return Task.CompletedTask;
        }
    }
}

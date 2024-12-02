namespace Telegin.UI.Interfaces
{
    public class NoOpEmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}

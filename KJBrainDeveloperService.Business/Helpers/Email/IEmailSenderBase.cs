using KJBrainDeveloperService.ServiceContracts;

namespace KJBrainDeveloperService.Business
{
    public interface IEmailSenderBase
    {
        Task SendEmailAsync(SendEmailRequestBase request);
        string CreateBody(CreateEmailBodyRequest request);
    }
}

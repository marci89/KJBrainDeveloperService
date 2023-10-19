using KJBrainDeveloperService.ServiceContracts;

namespace KJBrainDeveloperService.Business
{
    public interface IRegisterEmailSender
    {
        Task ExecuteAsync(RegisterEmailSenderRequest request);
    }
}

using KJBrainDeveloperService.ServiceContracts;

namespace KJBrainDeveloperService.Business
{
    public interface IResetPasswordEmailSender
    {
        Task<ResponseBase> ExecuteAsync(ResetPasswordEmailSenderRequest request);
    }
}

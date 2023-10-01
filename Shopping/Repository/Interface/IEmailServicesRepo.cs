using NuGet.Protocol.Plugins;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Services
{
    public interface IEmailServicesRepo : IRepositoryRepo<EmailModel>
    {
        void SendEmail(MessageModel message);
    }
}

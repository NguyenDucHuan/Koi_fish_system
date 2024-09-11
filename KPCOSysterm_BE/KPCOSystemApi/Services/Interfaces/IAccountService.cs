using Domain.Models;

namespace KPCOSystemApi.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CheckLogin(string username, string password);

    }
}

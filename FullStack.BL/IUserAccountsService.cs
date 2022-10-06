using FullStack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.BL
{
    public interface IUserAccountsService
    {
        Task<bool> CreateUserAccountAsync(string userName, string password, List<ContactDetail> contacDetails);
        Task<(bool authenticationSuccessful, UserAccount? userAccount)> LoginAsync(string username, string password);
    }
}

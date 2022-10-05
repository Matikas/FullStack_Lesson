using FullStack.DAL;
using FullStack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.BL
{
    public class UserAccountsService : IUserAccountsService
    {
        private readonly IDbRepository _dbRepository;

        public UserAccountsService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<bool> CreateUserAccountAsync(string userName, string password, List<ContactDetail> contacDetails)
        {
            var existingUser = await _dbRepository.GetAccountByUserNameAsync(userName);
            if (existingUser != null)
            {
                return false;
            }

            var (hash, salt) = CreatePasswordHash(password);

            var newUser = new UserAccount
            {
                UserName = userName,
                ContactDetails = contacDetails,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };

            await _dbRepository.InsertAccountAsync(newUser);
            await _dbRepository.SaveChangesAsync();

            return true;
        }

        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
    }
}

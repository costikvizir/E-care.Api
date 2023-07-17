using E_care.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        public Task<List<Client>> GetAllUsersAsync();
        public Task<Client> CreateUserAsync(Client user);
        public Task<Client> UpdateUserAsync(Client user);
    }
}

using E_care.Domain.Abstractions.Repositories;
using E_care.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_care.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Client>> GetAllUsersAsync()
        {
            var users = await _dataContext.Clients.ToListAsync();

            return users;
        }
        public async Task<Client> CreateUserAsync(Client user)
        {
            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<Client> UpdateUserAsync(Client user)
        {
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }
    }
}

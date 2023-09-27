using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //await --> ejecuta y no espera de manera async

        public async Task<bool> RegisterUser(User user)
        {
            await _dbContext.User.AddAsync(user);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Login(String correo , String password)
        {
             var FindUser = await _dbContext.User
            .Where(x => x.Email == correo && x.Password == password)
            .FirstOrDefaultAsync();

            if (FindUser == null)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            var User = await _dbContext
                .User
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (User == null)
                return false;

            _dbContext.User.Remove(User);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;

        }
    }
}

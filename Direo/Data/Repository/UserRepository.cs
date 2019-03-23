using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Direo.Helpers;
using Direo.Models;
using Microsoft.EntityFrameworkCore;

namespace Direo.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
          
            return users;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<User> UpdateUser(User user,string password)
        {
            if (user.Username != null)
            {
                user.Password = CryptoHelper.Crypto.HashPassword(password);
                user.ImageUrl = FileManager.Upload(user.ImageUrl, "jpg");
                //Delete that post
                _context.Users.Update(user);

                //Commit the transaction
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> DeleteUserPhoto(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.ImageUrl = "empty";
            _context.SaveChanges();
            FileManager.Delete(user.ImageUrl);

            return user;
        }
     
    }
}

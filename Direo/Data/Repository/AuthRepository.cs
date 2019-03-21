﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Direo.Models;
using Microsoft.EntityFrameworkCore;

namespace Direo.Data
{
    public class AuthRepository : IAuthRepository

    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!CryptoHelper.Crypto.VerifyHashedPassword(user.Password, password))
                return null;
          
                return user;
        }

        public async Task<User> Register(User user, string password)
        {
            user.Password = CryptoHelper.Crypto.HashPassword(user.Password);
            user.Status = true;

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

     

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}

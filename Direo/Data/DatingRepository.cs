﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Direo.Helpers;
using Direo.Models;
using Microsoft.EntityFrameworkCore;

namespace Direo.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
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
        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users
                .OrderByDescending(u => u.CreatedAt).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

          
            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
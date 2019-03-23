using Direo.Data.Repository.Interface;
using Direo.Helpers;
using Direo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Data.Repository
{
    public class MainRepository  : IMainRepository
    {
        private readonly DataContext _context;

        public MainRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            var locations = await _context.Locations.ToListAsync();

            return locations;
        }


        public async Task<PagedList<Listing>> GetListing(ListingParam listingParam)
        {
            var listings = _context.Listings.Include(f => f.Photos);

            return await PagedList<Listing>.CreateAsync(listings, listingParam.PageNumber,listingParam.PageSize);
        }

    }
}

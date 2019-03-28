using Direo.Data.Repository.Interface;
using Direo.Dtos.MainDtos;
using Direo.Helpers;
using Direo.Models;
using Direo.Models.ViewModel;
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

        public async Task<IEnumerable<CategoryDtos>> GetCategories()
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
            var listings = _context.Listings
                .Include(f=>f.Photos)
                .Include(l=>l.ListingTags)
                .ThenInclude(t=>t.Tag).OrderByDescending(o=>o.Id).AsQueryable();

            ///Filter by Category
            if (listingParam.CategoryId != 0)
            {
                listings = listings.Where(c => c.CategoryId == listingParam.CategoryId);
            }
            ///Filter by Location
            if (listingParam.LocationId != 0)
            {
                listings = listings.Where(c => c.LocationId == listingParam.LocationId);
            }
            ///Filter by Minimum Price
            if (listingParam.MinPrice != 0)
            {
                listings = listings.Where(c => c.Price >= listingParam.MinPrice);
            }
            ///Filter by Maximum Price
            if (listingParam.MaxPrice != 0)
            {
                listings = listings.Where(c => c.Price <= listingParam.MaxPrice);
            }
            ///Filter by Tags
            /// 
            if (listingParam.TagId != null)
            {
                foreach (var item in listingParam.TagId)
                {
                    listings = listings.Where(c => c.ListingTags.Where(w => w.TagId == item) != null);
                }
            }
            ///Order By
            if (!string.IsNullOrEmpty(listingParam.OrderBy))
            {
                switch (listingParam.OrderBy)
                {
                    case "LowToHigh":
                        listings = listings.OrderBy(u => u.Price);
                        break;
                    case "HighToLow":
                        listings = listings.OrderByDescending(u => u.Price);
                        break;
                    case "AtoZ":
                        listings = listings.OrderBy(u => u.Title);
                        break;
                    case "ZtoA":
                        listings = listings.OrderByDescending(u => u.Title);
                        break;
                    default:
                        listings = listings.OrderBy(u => u.Id);
                        break;
                }
            }
            return await PagedList<Listing>.CreateAsync(listings, listingParam.PageNumber,listingParam.PageSize);
        }

        public async Task<Listing> CreateListing(Listing listing,int userId )
        {
            listing.UserId = userId;
            listing.PostDate = DateTime.UtcNow.AddHours(4);
            Listing listingModel = new Listing();
            listingModel.Photo = FileManager.Upload(listing.Photo);
            listing.PhotoFileName = listingModel.Photo;

            await _context.Listings.AddAsync(listing);

             await  _context.SaveChangesAsync();

            return listing;
           
        }

        public async Task<IEnumerable<Photo>> CreateListingPhotos(IEnumerable<Photo> photos,int listingId)
        {
           
            foreach (var slider in photos)
            {
                if (string.IsNullOrWhiteSpace(slider.PhotoUrl))
                {
                    continue;
                }
                Photo photo = new Photo();
                photo.ListingId = listingId;
                photo.DateAdded = DateTime.UtcNow.AddHours(4);
                try
                {
                    photo.PhotoUrl = FileManager.Upload(slider.PhotoUrl);
                    slider.PhotoName = photo.PhotoUrl;
                    photo.IsMain = true;

                    await _context.Photos.AddAsync(photo);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return photos;
        }

        public async Task<IEnumerable<Tag>> CreateListingTags(IEnumerable<Tag> Tags,int listnigId)
        {
                /*Create PlaceTags*/
                if (Tags != null)
                {
                    foreach (var tags in Tags)
                    {
                        #region CehckTagsNull
                        if (!await _context.Tags.AnyAsync(t => t.Id == tags.Id))
                        {
                            continue;
                        }
                    #endregion

                    ListingTag ListingTag = new ListingTag
                    {
                        TagId = tags.Id,
                        ListingId = listnigId
                        };

                    Tag tagsGet = _context.Tags.Find(tags.Id);

                        tags.Name = tagsGet.Name;

                    //ListingTags add to context
                    
                            await _context.ListingTags.AddAsync(ListingTag);
                            await _context.SaveChangesAsync();
                }
            }
            return Tags;
        }
    }
}

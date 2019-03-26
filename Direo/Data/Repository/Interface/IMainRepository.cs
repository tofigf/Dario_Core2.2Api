using Direo.Helpers;
using Direo.Models;
using Direo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Data.Repository.Interface
{
   public  interface IMainRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<CategoryDtos>> GetCategories();
        Task<IEnumerable<Location>> GetLocations();
        Task<PagedList<Listing>> GetListing(ListingParam listingParam);
        Task<Listing> CreateListing(Listing listingCreate, int userId);
        Task<IEnumerable<Photo>> CreateListingPhotos(IEnumerable<Photo> photos, int listingId);
    }
}

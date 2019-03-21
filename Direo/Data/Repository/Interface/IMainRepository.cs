using Direo.Models;
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
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Location>> GetLocations();
    }
}

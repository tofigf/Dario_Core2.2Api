using Direo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }
        //bu metodla UserSeedData.json-nu database-e elave edirik.
        public void SeedUsers()
        {
            if (_context.Users.ToList().Count == 0)
            {
                var userJson = System.IO.File.ReadAllText("Data/Seed/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userJson);

                foreach (var user in users)
                {
                  var cryptoPassword = CryptoHelper.Crypto.HashPassword("password");
                    user.Password = cryptoPassword;
                    user.Username = user.Username.ToLower();
                    _context.Users.Add(user);
                }
                _context.SaveChanges();
            }

            if (_context.Categories.ToList().Count == 0)
            {
                var categoryJson = System.IO.File.ReadAllText("Data/Seed/CategorySeedData.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryJson);
                foreach (var category in categories)
                {
                    _context.Categories.Add(category);
                }
                _context.SaveChanges();
            }

            if (_context.Locations.ToList().Count == 0)
            {
                var locationJson = System.IO.File.ReadAllText("Data/Seed/LocationSeedData.json");
                var locations = JsonConvert.DeserializeObject<List<Location>>(locationJson);
                foreach (var location in locations)
                {
                    _context.Locations.Add(location);
                }
                _context.SaveChanges();
            }

            if (_context.Listings.ToList().Count == 0)
            {
                var listJson = System.IO.File.ReadAllText("Data/Seed/ListingSeedData.json");
                var lists = JsonConvert.DeserializeObject<List<Listing>>(listJson);
                int a = 2;
                foreach (var list in lists)
                {

                    if (a % 2 == 0)
                    {
                        list.CategoryId = _context.Categories.First().Id;
                        list.LocationId = _context.Locations.First().Id;
                        list.UserId = _context.Users.First().Id;

                    }
                    if (a % 2 != 0)
                    {
                        list.CategoryId = _context.Categories.Last().Id;
                        list.LocationId = _context.Locations.Last().Id;
                        list.UserId = _context.Users.Last().Id;

                    }
                    a++;
                    _context.Listings.Add(list);
                }
                _context.SaveChanges();
            }

            if (_context.Tags.ToList().Count == 0)
            {
                var tagJson = System.IO.File.ReadAllText("Data/Seed/TagSeedData.json");
                var tags = JsonConvert.DeserializeObject<List<Tag>>(tagJson);
                foreach (var tag in tags)
                {
                    _context.Tags.Add(tag);
                }
                _context.SaveChangesAsync();
            }

        }


    }
}

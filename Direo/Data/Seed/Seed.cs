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
                var userData = System.IO.File.ReadAllText("Data/Seed/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

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
                var category = System.IO.File.ReadAllText("Data/Seed/CategorySeedData.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(category);
                foreach (var cat in categories)
                {
                    _context.Categories.Add(cat);
                }
                _context.SaveChanges();
            }

            if (_context.Locations.ToList().Count == 0)
            {
                var location = System.IO.File.ReadAllText("Data/Seed/LocationSeedData.json");
                var locations = JsonConvert.DeserializeObject<List<Location>>(location);
                foreach (var loc in locations)
                {
                    _context.Locations.Add(loc);
                }
                _context.SaveChanges();
            }
        }


    }
}

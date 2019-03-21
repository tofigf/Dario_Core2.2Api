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
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
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
    
        }


    }
}

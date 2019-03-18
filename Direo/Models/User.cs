using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.Now;
        }
        
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string Desc { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string FbLink { get; set; }
        public string YbLink { get; set; }



    }
}

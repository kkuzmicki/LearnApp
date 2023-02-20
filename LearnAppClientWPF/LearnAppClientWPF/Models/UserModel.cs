
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAppClientWPF.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public bool isAdmin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string facebookLink { get; set; }
        public string twitterLink { get; set; }
        public string aboutMe { get; set; }
    }
}

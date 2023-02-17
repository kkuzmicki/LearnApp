
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAppClientWPF.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string AboutMe { get; set; }
    }
}

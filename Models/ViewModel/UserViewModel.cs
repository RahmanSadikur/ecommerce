using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NMS.Models;

namespace NMS.Models.ViewModel
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public List<UserCredential> UserCredentials { get; set; }
        public UserCredential UserCredential { get; set; }
    }
}
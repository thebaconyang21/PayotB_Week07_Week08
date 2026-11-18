using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payot_Week06_Week08
{

    public class User
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class UserStore
    {
        public static List<User> Users = new List<User>();
    }
}

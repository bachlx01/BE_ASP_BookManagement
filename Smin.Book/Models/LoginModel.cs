using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smin.Book.Models
{
    public class LoginModel
    {
        public string userLogin { set; get; }
        public string password { set; get; }
        public bool rememberMe { set; get; }
    }
}
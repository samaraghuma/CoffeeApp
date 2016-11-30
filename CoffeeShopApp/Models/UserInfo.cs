using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeShopApp.Models
{
    public class UserInfo
    {
        private string uname;
        private string email;

       
        public string Uname
        {
            get
            {
                return uname;
            }

            set
            {
                uname = value;
            }
        }
       
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public UserInfo(string uname, string email)
        {
            this.Uname = uname;
            this.Email = email;
        }
        public UserInfo()
        { }
    }
}
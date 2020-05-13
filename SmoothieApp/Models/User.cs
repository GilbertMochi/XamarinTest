using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool ValidateSignIn()
        {
            if (!this.Username.Equals("") && !this.Password.Equals("")){
                return true;
            }
            return false;
        }
    }
}

using MyGardenWildlife3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGardenWildlife3.Helpers
{
    public class SecurityHelper
    {
        string HashPassword(string clearPassword)
        {
            int BCRYPT_WORK_FACTOR = 10;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(clearPassword, BCRYPT_WORK_FACTOR);
            return hashedPassword;
        }

        bool MatchPassword(string clearPassword, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(clearPassword, hash);
        }
        
        //Add a user; takes a username and password and adds to the database
        public void AddUser(string UserName, string Password)
        {
            var context = new WildlifeContext();
            var user = new UserModel();
            context.UserModel.Add(user);
            user.UserName = UserName;
            user.Password = HashPassword(Password);
            context.SaveChanges();
        }

        //Login a user; check username and password against the database and returns true or false.
        public bool LoginUser(string UserName, string Password)
        {
            var user = GetUserByUserName(UserName);
            if(MatchPassword(Password, user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private UserModel GetUserByUserName(string userName)
        {
            var context = new WildlifeContext();
            var user = context.UserModel.Where((e) => e.UserName == userName).First();
            return user;
        }
    }
}
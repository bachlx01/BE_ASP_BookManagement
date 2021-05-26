using Book.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL
{
    public class UserDao
    {
        private BooksDbContext context = null;
        public UserDao()
        {
            context = new BooksDbContext();
        }

        public int Login(string userLogin, string password)
        {
            DM_USER user = context.DM_USERS.Where(c => c.USER_LOGIN == userLogin).FirstOrDefault();

            if (user == null)
            {
                return -1; // user does not exist
            }
            else
            {
                if (user.PASSWORD != password)
                {
                    return 0;  // password is wrong
                }
            }
            return 1;
        }

        public int UpdateUser(DM_USER user)
        {
            var self = this;
            DM_USER userDb = context.DM_USERS.Where(c => c.USER_LOGIN == user.USER_LOGIN).FirstOrDefault();
            DM_USER newUser = new DM_USER();
            newUser = userDb;
            if (userDb == null)
            {
                return -1;
            }
            else
            {
                if (userDb.PASSWORD == user.PASSWORD)
                {
                    
                    newUser.USER_LOGIN = user.USER_LOGIN;
                    newUser.PASSWORD = user.PASSWORD;
                    newUser.FULL_NAME = user.FULL_NAME;
                    newUser.BIRTH_DAY = user.BIRTH_DAY;
                    newUser.GENDER = user.GENDER;
                    newUser.MOBILE = user.MOBILE;
                    newUser.ADDRESS = user.ADDRESS;
                    newUser.EMAIL = user.EMAIL;
                    newUser.CMTNN = user.CMTNN;
                    
                    this.DeleteUser(userDb);
                    this.Save();
                    this.AddUser(newUser);

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public DM_USER GetUser (string userLogin)
        {
            return context.DM_USERS.Where(c => c.USER_LOGIN == userLogin).FirstOrDefault();
        }

        public List<DM_USER> GetUsers()
        {
            return context.DM_USERS.ToList();
        }

        public bool AddUser(DM_USER user)
        {
            try
            {
                context.DM_USERS.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(DM_USER user)
        {
            DM_USER userDb = context.DM_USERS.Where(c => c.USER_LOGIN == user.USER_LOGIN).FirstOrDefault();
            if (userDb == null)
            {
                return false;
            }
            else
            {
                context.DM_USERS.Remove(user);
                return true;
            }

        }

        public void Save()
        {
            context.SaveChanges();
        }
        
    }
}

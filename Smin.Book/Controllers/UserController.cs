using Book.BL;
using Book.DL;
using Book.Entity;
using Smin.Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smin.Book.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        // GET: api/User
        public UserInfo Get()
        {
            UserDao db = new UserDao();
            DM_USER userDB = db.GetUser(CommonConst.userLogin);
            UserInfo userInfo = new UserInfo();
            userInfo.USER_LOGIN = userDB.USER_LOGIN;
            userInfo.PASSWORD = "***";
            userInfo.FULL_NAME = userDB.FULL_NAME;
            userInfo.BIRTH_DAY = userDB.BIRTH_DAY.ToShortDateString();
            userInfo.GENDER = userDB.GENDER;
            userInfo.MOBILE = userDB.MOBILE;
            userInfo.ADDRESS = userDB.ADDRESS;
            userInfo.EMAIL = userDB.EMAIL;
            userInfo.CMTNN = userDB.CMTNN;
            
            return userInfo;
        }

        // GET: api/User/5
        public List<DM_USER> Get(string userLogin)
        {
            UserDao db = new UserDao();
            return db.GetUsers();
        }

        // POST: api/User
        
        public string Post([FromBody]UserInfo userInfo)
        {
            UserDao db = new UserDao();
            DM_USER userDb = new DM_USER();
            userDb.USER_LOGIN = userInfo.USER_LOGIN;
            userDb.PASSWORD = userInfo.PASSWORD;
            userDb.FULL_NAME = userInfo.FULL_NAME;
            userDb.BIRTH_DAY = Convert.ToDateTime(userInfo.BIRTH_DAY);
            userDb.GENDER = userInfo.GENDER;
            userDb.MOBILE = userInfo.MOBILE;
            userDb.ADDRESS = userInfo.ADDRESS;
            userDb.EMAIL = userInfo.EMAIL;
            userDb.CMTNN = userInfo.CMTNN;

            int result =  db.UpdateUser(userDb);

            if (result == -1)
            {
                return "Tài khoản không hợp lệ";
            }
            else if (result == 0)
            {
                return "Mật khẩu không đúng";
            }
            else if (result == 1)
            {
                db.Save();
                return "success";
            }
            else
            {
                return "Thay đổi thất bại";
            }
            
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

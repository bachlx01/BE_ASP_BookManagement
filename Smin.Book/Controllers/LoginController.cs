using Book.BL;
using Book.Entity;
using Smin.Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smin.Book.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UserDao dao = new UserDao();
            int result = dao.Login(model.userLogin, model.password);

            if (result == 1)
            {
                CommonConst.userLogin = model.userLogin;
                var userSession = new LoginModel();
                userSession.userLogin = model.userLogin;
                Session.Add(CommonConst.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else if (result == -1)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if (result == 0)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }
    }
}
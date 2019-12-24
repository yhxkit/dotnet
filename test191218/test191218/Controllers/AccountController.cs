using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test191218.DataContext;
using test191218.Models;
using test191218.ModelsForView;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test191218.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspNetDbContext())
                {
                    // Linq 쿼리식 - 메서드 체이닝으로 
                    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword)); //람다식으로 가져옴 
                    if (user != null) //로그인 성공
                    {
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        return RedirectToAction("LoginSuccess", "Home");
                    }
                    else //로그인 실패 
                    {
                        ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비번이 틀렸음");
                    }
                }
            }
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY"); // HttpContext.Session.Clear(); = 전체 세션 삭제.. 모든 유저 로그아웃되겠지 
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspNetDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home"); 
            }
            return View(model);
        }

    }
}

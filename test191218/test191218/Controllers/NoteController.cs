using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test191218.DataContext;
using test191218.Models;

namespace test191218.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {

            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //var list = new List<Note>();
            using (var db = new AspNetDbContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
               
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {

            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            if (ModelState.IsValid) {
                using (var db = new AspNetDbContext())
                {
                    db.Notes.Add(model);

                    if (db.SaveChanges() > 0) { //commit 결과가 성공일 경우
                        return Redirect("Index"); //동일한 컨트롤러 내의 리다이렉트는 toaction안해도 ㅇㅋ
                    }

                    ModelState.AddModelError(string.Empty, "게시물 저장 불가");
                    
                }
            }
            return View(model);
        }


        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = new AspNetDbContext())
            {
                var note = db.Notes.FirstOrDefault(n=>n.NoteNo.Equals(noteNo));
                return View(note);
            }

                //return View();
        }


        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }


        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

    }
}
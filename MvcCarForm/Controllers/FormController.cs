using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCarForm.Models;

namespace MvcCarForm.Controllers
{
    public class FormController : Controller
    {
        private CarContext db = new CarContext();
        // GET: Form
        public ActionResult Index()
        {
            return View(db.Infoes.ToList());
        }

        [HttpGet]
        public ActionResult UserInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserInfo([Bind(Include ="Id,Name,Phone,Email,Gender")]Info info)
        {
            if (ModelState.IsValid)
            {
                db.Infoes.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(info);
        }
    }
}
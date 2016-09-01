using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingDiary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var unitOfWork = new UnitOfWork(new DatabaseContext());
            var repo = unitOfWork.Repository<User>();

            repo.Add(new User() { Name = "user 111", BiometricInfo = new List<BiometricInfo>() { new BiometricInfo() { Date = DateTime.Now, Metadata = new BiometricMetadata() { Weight = 65 } } ,  new BiometricInfo() { Date = DateTime.Now.AddDays(-1), Metadata = new BiometricMetadata() { Weight = 67 } }  }});
            unitOfWork.Save();

            var users = repo.Get().ToList();

            return View();
        }

        //public ActionResult Training()
        //{
        //    return View();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;
using MAA.Basecore.Helpers.Common;
using Vektorel.EMarket.MVC.UI.Manage.Sessions;
using Vektorel.EMarket.MVC.UI.Models.Validators;
using Vektorel.EMarket.MVC.UI.Manage;
using Ninject;

namespace Vektorel.EMarket.MVC.UI.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserRepository repository;
        public AccountController(IUserRepository repo)
        {
            repository = repo;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login([Bind(Prefix ="LoginUser")]LoginModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = repository.Login(obj.Email, obj.Password);
                    switch (result.State)
                    {
                        case MAA.Basecore.Model.Enums.BusinessResultType.NotSet:
                            break;
                        case MAA.Basecore.Model.Enums.BusinessResultType.Success:
                            UserSessions.CurrentUser = result.Result;
                            //return RedirectToRoute("rtIndex");
                            //return RedirectToAction("Index", "Home");
                            break;
                        case MAA.Basecore.Model.Enums.BusinessResultType.Error:

                            break;
                        case MAA.Basecore.Model.Enums.BusinessResultType.Warning:
                            break;
                        case MAA.Basecore.Model.Enums.BusinessResultType.Info:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return Json("Vektörel Bilişim Ankara Kursu",JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Link = "register";
            //return View("login");
            return View("~/Views/Account/login.cshtml");
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RememberMe")]RegisterModel model)
        {
            ModelState.Remove("RememberMe");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    Password = model.Password.GetMD5Hash(),
                    FullName = "New User"
                };
                var result = repository.Insert(user);
                switch (result.State)
                {
                    case MAA.Basecore.Model.Enums.BusinessResultType.NotSet:
                        break;
                    case MAA.Basecore.Model.Enums.BusinessResultType.Success:
                        //UserSessions.CurrentUser = result.Result;
                        return RedirectToAction("Login");
                    case MAA.Basecore.Model.Enums.BusinessResultType.Error:
                        break;
                    case MAA.Basecore.Model.Enums.BusinessResultType.Warning:
                        break;
                    case MAA.Basecore.Model.Enums.BusinessResultType.Info:
                        break;
                }
            }
            return View();
        }

    }
}
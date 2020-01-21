using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.MVC.UI.Manage.Filters;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.MVC.UI.Manage.Sessions;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class AsyncAccountController : Controller
    {
        private readonly IUserRepository repository;
        public AsyncAccountController(IUserRepository repo)
        {
            repository = repo;
        }

        // GET: Async
        [HttpPost]
        [CustomHandler(View="~/Views/Error/internalservererror.cshtml")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Login([Bind(Prefix="LoginUser")]LoginModel model)
        {
            var result = new Dictionary<string, object>();
            var loginResult = repository.Login(model.Email, model.Password);
            switch (loginResult.UserState)
            {
                case UserResultType.Blocked:
                    result.Add("status", false);
                    result.Add("user", null);
                    result.Add("message", "This user has been blocked");
                    break;
                //case UserResultType.NotConfirmed:
                //    result.Add("status", false);
                //    result.Add("user", null);
                //    result.Add("message", "This user has been blocked");
                //    break;
                case UserResultType.Authenticated:
                    result.Add("status", true);
                    result.Add("userfullname", loginResult.Result.FullName);
                    result.Add("message","You have successfully logged in.");
                    UserSessions.CurrentUser = loginResult.Result;
                    break;
                case UserResultType.UnAuthorized:
                    result.Add("status", false);
                    result.Add("user", null);
                    result.Add("message", "You have no authorization to do.");
                    break;
                case UserResultType.NotFound:
                    result.Add("status", false);
                    result.Add("user", null);
                    result.Add("message", "There is no such user");
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {

            //
            return RedirectToAction("Index", "Home");
        }
    }
}
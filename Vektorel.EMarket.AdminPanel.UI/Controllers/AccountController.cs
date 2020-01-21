using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.AdminPanel.UI.Manage.Filters;
using Vektorel.EMarket.AdminPanel.UI.Manage.Sessions;
using Vektorel.EMarket.AdminPanel.UI.Models.ViewModels;
using Vektorel.EMarket.Datacore.Infrastructure;

namespace Vektorel.EMarket.AdminPanel.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepo;
        public AccountController(IUserRepository user_repo)
        {
            userRepo = user_repo;
        }


        // GET: Account
        [Authentication(false)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, Authentication(false)]
        public ActionResult Login(LoginModel model)
        {
            //UserSessions.CurrentUser = user
            if (ModelState.IsValid)
            {
                var loginResult = userRepo.Login(model.Email, model.Password);
                switch (loginResult.State)
                {
                    case MAA.Basecore.Model.Enums.BusinessResultType.NotSet:
                        break;
                    case MAA.Basecore.Model.Enums.BusinessResultType.Success:
                        var rolesResult = userRepo.GetUserRoles(loginResult.Result.Id);
                        if (rolesResult.State == MAA.Basecore.Model.Enums.BusinessResultType.Success)
                        {
                            var role = rolesResult.Result.Select(x => x.Name == "Customer");
                           
                            if (rolesResult.Result.Count()>1||role!=null)
                            {
                                UserSessions.CurrentUser = loginResult.Result;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("errorlbl", "You are not an authorized user.");
                            }
                        }
                        break;
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

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using People.Domain.Entities.User.UserDataTables;
using People.BusinessLogic.DBModel.DBContext;
using People.Web.Extension;
using People.Web.Models.User;
using System.Data.Entity;

namespace People.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Users List
        public List<UserData> GetUsers(UserContext uContext)
        {
            var result = new List<UserData>();

            if (uContext == null)
            {
                return new List<UserData>();
            }

            foreach (var userC in uContext.Users)
            {
                var newUser = new UserData
                {
                    Username = userC.Username,
                    Level = userC.Level,
                    ProfileImageUrl = userC.ProfileImageUrl
                };

                result.Add(newUser);
            }

            return result;
        }

        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }

            //var user = System.Web.HttpContext.Current.GetMySessionObject();
            var Db = new UserContext();
            var result = GetUsers(Db);

            return View(result);
        }

        public ActionResult UData()
        {
            var Db = new UserContext();
            var uName = Request.QueryString["p"];

            var user = Db.Users.FirstOrDefault(u => u.Username == uName);

            UserData result = new UserData
            {
                Username = user.Username,
                Level = user.Level,
                ProfileImageUrl = user.ProfileImageUrl
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult UData(string btn)
        {
            return RedirectToAction("UData", "Home", new { @p = btn });
        }
    }
}

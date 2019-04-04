using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using People.BusinessLogic;
using People.BusinessLogic.Interfaces;
using People.Domain.Entities.User.UserData;
using People.Web.Models.User;

namespace People.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            var us = new UserLogin();

            System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";

            return View(us);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                //ULoginData data = new ULoginData
                //{
                //    Username = login.Username,
                //    Password = login.Password,
                //    LoginIp = Request.UserHostAddress,
                //    LoginDateTime = DateTime.Now
                //};

                //Mapper.Initialize(cfg=> cfg.CreateMap<UserLogin,ULoginData>());
                var data = Mapper.Map<ULoginData>(login);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var status = _session.UserLogin(data);

                if (status.Status)
                {
                    HttpCookie cookie = _session.GenCookie(login.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Error at Login", status.StatusMessage);

                return View();
            }

            return View();
        }
    }
}

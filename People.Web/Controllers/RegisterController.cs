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
    public class RegisterController : BaseController
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }

        // MARK: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                //URegisterData data = new URegisterData
                //{
                //    Username = register.Username,
                //    Password = register.Password,
                //    Email = register.Email,
                //    ConfirmedPassword = register.ConfirmedPassword,
                //    LoginIp = Request.UserHostAddress,
                //    LoginDateTime = DateTime.Now
                //};

                //Mapper.Initialize(cfg=> cfg.CreateMap<UserRegister,URegisterData>());
                var data = Mapper.Map<URegisterData>(register);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var status = _session.UserRegister(data);

                if (status.Status)
                {
                    HttpCookie cookie = _session.GenCookie(register.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Login");
                }

                ModelState.AddModelError("Registration Error", status.StatusMessage);

                return View();
            }

            return View();
        }
    }
}

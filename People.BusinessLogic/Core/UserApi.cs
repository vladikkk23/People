using System;
using System.ComponentModel.DataAnnotations;
using People.Domain.Entities.User.UserResponses;
using People.Domain.Entities.User.UserData;
using People.Domain.Entities.User.UserDataTables;
using People.Helpers;
using People.BusinessLogic.DBModel.DBContext;
using System.Linq;
using System.Data.Entity;
using System.Web;
using AutoMapper;
using People.Domain.Enums;

namespace People.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResponse UserLoginAction(ULoginData data)
        {
            UDataTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Username))
            {
                var pass = LoginHelper.HashGen(data.Password);

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResponse { Status = false, StatusMessage = "The Username or Password is Incorrect(1)" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResponse { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResponse { Status = false, StatusMessage = "The Username or Password is Incorrect(2)" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResponse { Status = true };
            }
        }

        internal URegisterResponse UserRegisterAction(URegisterData data)
        {
            UDataTable result;
            EmailAddressAttribute validate = new EmailAddressAttribute();

            if (validate.IsValid(data.Email))
            {
                string pass = LoginHelper.HashGen(data.Password);

                if (data.Password == data.ConfirmedPassword)
                {
                    using (var db = new UserContext())
                    {
                        result = db.Users.FirstOrDefault(u => u.Email == data.Email);
                    }

                    if (result != null)
                    {
                        return new URegisterResponse { Status = false, StatusMessage = "This Username is already in use(1)" };
                    }

                    result = new UDataTable
                    {
                        Username = data.Username,
                        Email = data.Email,
                        LastIp = data.LoginIp,
                        LastLogin = data.LoginDateTime,
                        ProfileImageUrl = data.ProfileImageUrl,
                        Level = Role.User,
                        Password = LoginHelper.HashGen(data.Password)
                    };

                    using (var todo = new UserContext())
                    {
                        todo.Users.Add(result);
                        todo.SaveChanges();
                    }

                    return new URegisterResponse { Status = true };
                }
                return new URegisterResponse { Status = false, StatusMessage = "Passwords did not Match" };
            }
            else
            {
                string pass = LoginHelper.HashGen(data.Password);

                if (data.Password == data.ConfirmedPassword)
                {
                    using (var db = new UserContext())
                    {
                        result = db.Users.FirstOrDefault(u => u.Username == data.Username);
                    }

                    if (result != null)
                    {
                        return new URegisterResponse { Status = false, StatusMessage = "This Username is already in use(2)" };
                    }

                    result = new UDataTable
                    {
                        Username = data.Username,
                        Email = data.Email,
                        LastIp = data.LoginIp,
                        LastLogin = data.LoginDateTime,
                        ProfileImageUrl = data.ProfileImageUrl,
                        Level = Role.User,
                        Password = LoginHelper.HashGen(data.Password)
                    };

                    using (var todo = new UserContext())
                    {
                        todo.Users.Add(result);
                        todo.SaveChanges();
                    }

                    return new URegisterResponse { Status = true };
                }
                return new URegisterResponse { Status = false, StatusMessage = "Passwords did not Match" };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                SessionDBTable curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionDBTable
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UMinimalData UserCookie(string cookie)
        {
            SessionDBTable session;
            UDataTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null)
            {
                return null;
            }

            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();

                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null)
            {
                return null;
            }

            //Mapper.Initialize(cfg => cfg.CreateMap<UDBTable, UMinimalData>());
            var userminimal = Mapper.Map<UMinimalData>(curentUser);


            return userminimal;
        }
    }
}

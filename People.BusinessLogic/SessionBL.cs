using System;
using System.Web;
using People.BusinessLogic.Core;
using People.BusinessLogic.Interfaces;
using People.Domain.Entities.User.UserData;
using People.Domain.Entities.User.UserResponses;

namespace People.BusinessLogic
{
    public class SessionBL: UserApi, ISession
    {
        public ULoginResponse UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }

        public URegisterResponse UserRegister(URegisterData data)
        {
            return UserRegisterAction(data);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UMinimalData GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}

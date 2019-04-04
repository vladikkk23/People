using System;
using System.Web;
using People.Domain.Entities.User.UserData;
using People.Domain.Entities.User.UserResponses;

namespace People.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResponse UserLogin(ULoginData data);
        URegisterResponse UserRegister(URegisterData data);
        HttpCookie GenCookie(string loginCredential);
        UMinimalData GetUserByCookie(string apiCookieValue);
    }
}

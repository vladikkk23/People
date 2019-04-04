using System;
using System.Web;
using People.Domain.Entities.User.UserData;

namespace People.Web.Extension
{
    public static class HttpContextExtension
    {
        public static UMinimalData GetMySessionObject(this HttpContext current)
        {
            return (UMinimalData)current?.Session["__SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UMinimalData profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}

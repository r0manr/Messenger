using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using MessangerFirst.Core.Security;

namespace MessangerFirst.WebUI.Controllers
{
    public class FormAuthService : IFormsAuthentication
    {
        public void SignIn(string email, bool createPersistentCookie, IEnumerable<string> roles)
        {
            var str = string.Join(",", roles);

            var authTicket = new FormsAuthenticationTicket(
                1,
                email,
                DateTime.Now,
                DateTime.Now.AddHours(5),
                createPersistentCookie,
                str
                //,"/"
                );

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));

            if (authTicket.IsPersistent)
            {
                cookie.Expires = authTicket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
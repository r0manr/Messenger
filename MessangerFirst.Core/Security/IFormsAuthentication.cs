using System.Collections.Generic;

namespace MessangerFirst.Core.Security
{
    /// <summary>
    /// Интерфейс аутентификации пользователя
    /// </summary>
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie, IEnumerable<string> roles);
        void SignOut();
    }
}

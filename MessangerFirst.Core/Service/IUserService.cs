using System;
using MessangerFirst.Core.Model;

namespace MessangerFirst.Core.Service
{
    public interface IUserService : ICrudService<User>
    {
        /// <summary>
        /// Проверить email на уникальность
        /// </summary>
        bool IsUnique(string email);

        /// <summary>
        /// Изменить пароль
        /// </summary>
        void ChangePassword(Guid id, string password);

        /// <summary>
        /// Получить пользователя по логину и паролю
        /// </summary>
        User Get(string login, string password);

        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        User FindByName(string name);
    }
}

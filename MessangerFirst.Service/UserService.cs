using System;
using System.Linq;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;
using MessangerFirst.Core.Security;
using MessangerFirst.Core.Service;

namespace MessangerFirst.Service
{
    public class UserService : CrudService<User>, IUserService
    {
        private readonly IHasher _hasher;
        public UserService(IRepo<User> repo, IHasher hasher)
            : base(repo)
        {
            _hasher = hasher;
        }

        public override Guid Create(User user)
        {
            user.Password = _hasher.Encrypt(user.Password);
            return base.Create(user);
        }

        public bool IsUnique(string email)
        {
            return !Repo.Where(o => o.Email == email).Any();
        }

        public void ChangePassword(Guid id, string password)
        {
            Repo.Get(id).Password = _hasher.Encrypt(password);
            Repo.Save();
        }

        public User Get(string email, string password)
        {
            var user = Repo.Where(o => o.Email == email).SingleOrDefault();
            if (user != null && !_hasher.CompareStringToHash(password, user.Password)) return null;
            return user;
        }

        public User FindByName(string name)
        {
            var user = Repo.Where(x => x.Email == name).SingleOrDefault();
            return user;
        }
    }
}

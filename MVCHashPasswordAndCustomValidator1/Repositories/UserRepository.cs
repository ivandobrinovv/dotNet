using DataAccess;
using Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override void Save(User user)
        {
            if (user.ID == 0)
            {
                base.Create(user);
            }
            else
            {
                base.Update(user,item=>item.ID == user.ID);
            }
        }

        public User GetUserByNameAndPassword(string username, string password)
        {
            User user = base.DbSet.FirstOrDefault(u=>u.Username == username);
            if (user != null)
            {
                PasswordManager passManager = new PasswordManager();
                bool isValidPassword = passManager.IsPasswordMatch(password, user.PasswordHash, user.PasswordSalt);
                if (isValidPassword == false)
                {
                    user = null;
                }                
            }
            return user;
        }

        public void RegisterUser(User user, string password)
        {
            string salt, hash;
            PasswordManager passwordManager = new PasswordManager();
            hash = passwordManager.GeneratePasswordHash(password, out salt);

            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            base.Create(user);
        }

        public User GetUserByName(string username)
        {
            User user = base.DbSet.FirstOrDefault(u=>u.Username == username);
            return user;
        }
    }
}

using Microsoft.Extensions.Options;
using mysocietywebsite.Common.Helper;
using mysocietywebsite.Model.Entities;
using mysocietywebsite.Resource.ViewModel;
using mysocietywebsite.Service.Helper;
using mysocietywebsite.Service.interfaces;
using System;
using System.Linq;
using System.Text;

namespace mysocietywebsite.Service.services
{
    public class Account : IAccount
    {
        private readonly IRespository.IRepository<User> _context;
        private readonly IJwtAuth _auth;
        private readonly AppSettings _setting;

        public Account(IRespository.IRepository<User> context,IJwtAuth auth,IOptions<AppSettings> setting)
        {
            _context = context;
            _auth = auth;
            _setting = setting.Value;
        }
        public UserResponse Login(string user, string pass)
        {
            User resultantUser = _context.GetAll().Where(u=>(u.Username.Equals(user) && HashPassword.VerifyPassword(pass, Encoding.UTF32.GetBytes(_setting.Salt), u.Password)) || (u.Email.Equals(user) && HashPassword.VerifyPassword(pass, Encoding.UTF32.GetBytes(_setting.Salt), u.Password))).FirstOrDefault();
            string token = null;
            if (resultantUser != null)
            {
                token = _auth.Authentication(resultantUser.Id.ToString());

                return new UserResponse
                {
                    Fullname = resultantUser.Fullname,
                    Email = resultantUser.Email,
                    Address = resultantUser.Address,
                    Id = resultantUser.Id,
                    Token = token
                };
            }
            else {
                return null;
            }
        }

        public UserViewModel Register(User user) {
            try {
                user.Id = Guid.NewGuid();
                user.IsActive = true;
                user.IsDeleted = false;
                user.ModifiedBy = user.Id;
                user.ModifiedOn = DateTime.UtcNow;
                user.CreatedBy = user.Id;
                user.CreatedOn = user.ModifiedOn;
                user.Password = HashPassword.EncryptPassword(user.Password, Encoding.UTF32.GetBytes(_setting.Salt)).Hash;
                User resultantUser = _context.Insert(user);
                _context.Save();
                return new UserViewModel
                {
                    Id = resultantUser.Id,
                    Email = resultantUser.Email,
                    Fullname = resultantUser.Fullname
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}

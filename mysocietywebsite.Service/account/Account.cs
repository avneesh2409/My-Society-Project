using mysocietywebsite.Model.Entities;
using mysocietywebsite.Resource.ViewModel;
using mysocietywebsite.Service.interfaces;
using System.Linq;


namespace mysocietywebsite.Service.services
{
    public class Account : IAccount
    {
        private readonly IRespository.IRepository<User> _context;
        private readonly IJwtAuth _auth;

        public Account(IRespository.IRepository<User> context,IJwtAuth auth)
        {
            _context = context;
            _auth = auth;
        }
        public UserResponse Login(string user, string pass)
        {
            User resultantUser = _context.GetAll().Where(u=>(u.Username.Equals(user) && u.Password.Equals(pass)) || (u.Email.Equals(user) && u.Password.Equals(pass))).FirstOrDefault();
            string token = null;
            if (resultantUser != null) {
                token = _auth.Authentication(resultantUser.Id.ToString());
            }
            return new UserResponse { 
                Fullname = resultantUser.Fullname,
                Email = resultantUser.Email,
                Address = resultantUser.Address,
                Id=resultantUser.Id,
                Token = token
            };
        }

        public UserViewModel Register(User user) {
            User resultantUser = _context.Insert(user);
            _context.Save();
            return new UserViewModel
            {
                Id = resultantUser.Id,
                Email = resultantUser.Email,
                Fullname = resultantUser.Fullname
            };
        }
    }
}

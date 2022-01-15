using mysocietywebsite.Model.Entities;
using mysocietywebsite.Resource.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Service.interfaces
{
    public interface IAccount
    {
        UserResponse Login(string user, string pass);
        UserViewModel Register(User user);
    }
}

using mysocietywebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Resource.ViewModel
{
    public class UserViewModel : BaseEntity
    {
        public string Fullname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
    public class UserResponse : BaseEntity
    {
        public string Fullname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

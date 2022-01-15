using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Service.interfaces
{
    public interface IJwtAuth
    {
        string Authentication(string username);
    }
}

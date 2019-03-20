using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public interface IUser
    {
        ApplicationUser getUserByID(string id);
        ApplicationUser getUserByName(string name);

    }
}
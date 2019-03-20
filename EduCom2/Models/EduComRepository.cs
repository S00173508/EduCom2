using EduCom2.Models.DTO;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public class EduComRepository : IUser,IMember
    {
        EduContext ectx = new EduContext();
        ApplicationDbContext actx = new ApplicationDbContext();

     

        public ApplicationUser getUserByID(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser getUserByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
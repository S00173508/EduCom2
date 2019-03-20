using EduCom2.Models;
using EduCom2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduCom2.Controllers
{
   //[routePrefix=api/members]
    public class MembersController : ApiController
    {
        EduComRepository db = new EduComRepository();

        //// GET api/values
        //  route = getmemberlist
        //public MemberUserViewModel GetMemberList(string uid)
        //{
        //    return db.GetMembersByUser(uid);
        //}

    }
}
//              localhost:saef/api/members/getmemberlist
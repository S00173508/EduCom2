using EduCom2.Models;
using EduCom2.Models.DTO;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduCom2.Controllers
{

    [RoutePrefix("api/EduCom")]
    public class MembersController : ApiController
    {
        EduComRepository db = new EduComRepository();
        [Route("getAllMembers")]
        [HttpGet]
        public List<Member> getAllMembersInfo()
        {
            return db.GetAllMembers();
        }

        [Route("getMember/{memberId:int}")]
        [HttpGet]
        public Member getMemberInfo(int memberId)
        {
            return db.GetMember(memberId);
        }

        [Route("getSub/{memberId:int}")]
        [HttpGet]
        public Subscribe getSub(int memberId)
        {
            return db.GetSub(memberId);
        }

    }
}



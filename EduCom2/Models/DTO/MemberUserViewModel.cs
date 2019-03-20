using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models.DTO
{
    public class MemberUserViewModel
    {
        public string MemberUserID { get; set; }
        public string MemberUserName { get; set; }
        public List <Member> members { get; set; }
    }
}
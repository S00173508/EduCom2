using EduCom2.Models.DTO;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public interface IMember
    {
        List<Member> GetAllMembers();
        //deleting a member based on topic id
        void DeleteTopicMember( int memberID);

    }
}
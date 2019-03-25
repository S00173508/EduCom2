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

        public void DeleteTopicMember(int memberID)
        {
            //Member member = ectx.Members.Find(memberID);
            //ectx.Members.Remove(member);
        }


        public ApplicationUser getUserByID(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser getUserByName(string name)
        {
            throw new NotImplementedException();
        }

        //method to display all members on info page
        public List<Member> GetAllMembers()
        {
            var topicList = ectx.Members.ToList();
            return topicList;
        }

        public Member GetMemberByID(int memberID)
        {
            //return members.Find(m => m.MemberID == memberID);
            return null;
            //return members.Find(m => m.MemberID == memberID);
            //ectx.Members.FirstOrDefault(m => m.MemberID == memberID);
        }

        public void DeleteMember(int mID)
        {
            //var memberToRemove = ectx.Members.FirstOrDefault(e => e.MemberID == memberID);
            //ectx.Members.Remove(memberToRemove);


            //members.RemoveAll(m => m.MemberID == mID);
        }
    }
}
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduCom2.Models.DTO;

namespace EduCom2.Models
{
    public class TopicPostRepository: ITopic,IMember
    {
        EduContext ectx = new EduContext();

        //method to display all topics on info page
            public IEnumerable<Topic> GetAllTopics()
        {
            // var topicList = ectx.Topics.ToList();
            //return topicList;
            return ectx.Topics.ToList();
        }

        //deleting a member based on topic id
        public void DeleteTopicMember(int memberID)
        {
            Member member = ectx.Members.Find(memberID);
            ectx.Members.Remove(member);
            var topicList = ectx.Topics.ToList();

            return topicList;
        }

         public Topic CreateNewTopic(Topic topic)
        {
            ectx.Topics.Add(topic);
            ectx.SaveChanges();
            return null;
        }

       
    }
}
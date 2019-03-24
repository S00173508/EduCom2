using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduCom2.Models.DTO;

namespace EduCom2.Models
{
    public class TopicPostRepository: ITopic
    {
        EduContext ectx = new EduContext();

        //method to display all topics on info page
        public List <Topic> GetAllTopics()
        {          
            var topicList = ectx.Topics.ToList();          
            return topicList;
        }

         public Topic CreateNewTopic(Topic topic)
        {
            ectx.Topics.Add(topic);
            ectx.SaveChanges();
            return null;
        }

        // display all posts in a topic
        public List<Post> GetPosts(int topicID)
        {
            var postList = ectx.Posts.ToList()
                .Where(p => p.TopicId == topicID).ToList();
            return postList;
        }


        
        public void DeleteOneById(int id)
        {
            Topic topic = this.ectx.Topics.Where(x => x.ID == id).SingleOrDefault();
            this.ectx.Topics.Remove(topic);
            this.ectx.SaveChanges();
        }

    }
}
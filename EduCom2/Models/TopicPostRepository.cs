using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduCom2.Models.DTO;

namespace EduCom2.Models
{
    public class TopicPostRepository: ITopic,IPost
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

        public void NewPost(int topicId, string text)
        {
            ectx.Posts.Add(new Post()
            {
                MemberID = 1,
                Text = text,
                TopicId = topicId
            });
            ectx.SaveChanges();


        }
        public Post DeletePostById(int id)
        {
            Post post = this.ectx.Posts.Where(x => x.ID == id).SingleOrDefault();
            this.ectx.Posts.Remove(post);
            this.ectx.SaveChanges();
            return null;
        }

        public Topic DeleteOneById(int id)
        {
            Topic topic = this.ectx.Topics.Where(x => x.ID == id).SingleOrDefault();
            this.ectx.Topics.Remove(topic);
            this.ectx.SaveChanges();
            return null;
        }
        public Topic GetTopics(int id)
        {
            var post = ectx.Topics.Find(id);
            return post;
        }
    }
}
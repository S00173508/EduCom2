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

        public Subscribe Subscribr(Subscribe sub)
        {
            ectx.Subscribes.Add(sub);
            ectx.SaveChanges();
            return sub;
        }


        public void NewTopic(string topicName)
        {
            ectx.Topics.Add(new Topic()
            {
                ModeratorID = 1,
                TopicName = topicName,
                
            });
            ectx.SaveChanges();
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
        public Post Update(int id, int topicId, string text)
        {
            Post updatedPost = ectx.Posts.FirstOrDefault(p => p.ID == id);//post.ID);
            updatedPost.Text = text;//post.Text;
            updatedPost.TopicId = topicId;
            ectx.SaveChanges();
            return updatedPost;
        }


        public Member GetMemberByID(int memberID)
        {
          
            return ectx.Members.FirstOrDefault(m => m.MemberID == memberID);
        }

        public void DeleteMember(int mID)
        {
            Member member = ectx.Members.Find(mID);
            ectx.Members.Remove(member);
            ectx.SaveChanges();
        }
    }
}
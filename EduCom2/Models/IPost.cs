using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public interface IPost
    {
        List<Post> GetPosts(int topicID);
        Post DeletePostById(int id);
        //List<Post> GetPosts();

        //List<Post>Post();
        Post Update(int id, int topicId, string text);

        void NewPost(int topicId, string text);

    }
}
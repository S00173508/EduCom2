using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public interface IPost
    {
        List<Post> GetPosts();

        List<Post>Post();
        void NewPost(int topicId, string text);

    }
}
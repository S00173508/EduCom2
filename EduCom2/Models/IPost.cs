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
    }
}
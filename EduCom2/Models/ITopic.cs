using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EduCom2.Models
{
    public interface ITopic
    {

        List<Topic> GetAllTopics();
        void NewTopic(string topicName);
        Topic DeleteOneById(int id);
    }

        //IHttpActionResult NewPostTopicPost(Topic topic);

        
    }

    /*
    public IHttpActionResult NewPostTopicPost(Topic topic)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Topics.Add(topic);
        db.SaveChanges();

        return CreatedAtRoute("DefaultApi", new { id = topic.ID }, topic);
    }*/

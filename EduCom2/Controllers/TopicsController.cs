﻿using EduCom2.Models;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduCom2.Controllers
{
    [RoutePrefix("api/EduCom")]
    public class TopicsController : ApiController
    {
        TopicPostRepository db = new TopicPostRepository();

        [Route("getAllTopics")]
        [HttpGet]
        public List<Topic> getAllTopicsInfo()
        {
            return db.GetAllTopics();
        }

        // POST: api/Topics
        [Route("postTopics")]
        public Topic PostTopic(Topic topic)
        { 

            return db.CreateNewTopic(topic);

         
        }
    }
}
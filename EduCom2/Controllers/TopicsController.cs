using EduCom2.Models;
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
        // DELETE: api/Topic
        [Route("delateTopics")]
        public Topic DelateTopics(int topic)
        {
             db.DeleteOneById(topic);
            return null;
        }
       


        //[Route("deleteTopicMember/{memberID:int}")]
        //[HttpGet]
        //public void DeleteTopicMembers(int memberID)
        //{
        //    db.DeleteTopicMember(memberID);
        //}


        //    // DELETE: api/Employees/5
        //    [Route("deleteTopics")]
        //    public Topic DeleteTopic(int id)
        //    {
        //      //  Employee employee = db.Employees.Find(id);


        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Employees.Remove(employee);
        //        db.SaveChanges();

        //        return Ok(employee);
        //    }
    }
}

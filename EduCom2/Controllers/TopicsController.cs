using EduCom2.Models;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EduCom2.Controllers
{
    [RoutePrefix("api/EduCom")]
    [EnableCors("*","http://localhost:64135/api/EduCom/getAllTopics/", "*", "*")]
    public class TopicsController : ApiController
    {
        //TopicPostRepository db = new TopicPostRepository();

        private TopicPostRepository repo = new TopicPostRepository();

        [Route("getAllTopics")]
        [HttpGet]
        public List<Topic> getAllTopicsInfo()
        {
            return repo.GetAllTopics();
        }

        // POST: api/Topics
        [Route("postTopics")]
        public Topic PostTopic(Topic topic)
        {
            return repo.CreateNewTopic(topic);
         
        }
        // DELETE: api/Topic
        [Route("delateTopics")]
        public Topic DelateTopics(int topic)
        {
             repo.DeleteOneById(topic);
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

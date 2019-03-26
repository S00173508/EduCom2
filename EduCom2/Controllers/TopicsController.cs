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
        private EduContext db = new EduContext();

        private TopicPostRepository repo = new TopicPostRepository();

        [Route("getAllTopics")]
        [HttpGet]
        public List<Topic> getAllTopicsInfo()
        {
            return repo.GetAllTopics();
        }

        [Route("getTopics/{topicId:int}")]
        [HttpGet]
        public Topic getTopicInfo(int topicId)
        {
            return repo.GetTopics(topicId);
        }


        [Route("Subscribe/{topic:int}/{mem:int}")]
        public Subscribe Subscribe(int topic, int mem)
        {
            Subscribe sub = new Subscribe();
            sub.TopicId = topic;
            sub.MemberID = mem;

            return repo.Subscribr(sub);

        }


        // POST: api/Topics
        [Route("postTopics/{topicName}")]
        [HttpPost]
        public IHttpActionResult PostNewTopic(string topicName)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                repo.NewTopic(topicName);
                db.SaveChanges();
                return Ok();
            }

        }
        // DELETE: api/Topic
        [Route("delateTopics/{topicId:int}")]
        [HttpDelete]
        public void DelateTopics(int topicId)
        {
            repo.DeleteOneById(topicId);
             
        }

       

        [Route("GetMember/{memID:int}")]
        [HttpGet]
        public Member GetMember(int memID)
        {
            Member member = repo.GetMemberByID(memID);
            if (member == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return member;
        }

    
        // [Authorize(Roles = "Admin")]
        [Route("DeleteMember/{memID:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteMember(int memID)
        {
            try
            {
                using (EduContext ectx = new EduContext())
                {
                    // Member memberToRemove =  db.GetMemberByID(memID);
                    if (memID == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with ID = " + memID + " not found. Cannot complete your delete request");
                    }
                    else
                    {
                        //ectx.Members.Remove(memberToRemove);
                        // db.DeleteMember(memberToRemove);
                        repo.DeleteMember(memID);
                        ectx.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            // edcx.Topics.Find(topicID).Members.Remove(edcx.Members.Find(memID));            
        }






        //// DELETE: api/Employees/5
        //[Route("delateTopics")]
        //public IHttpActionResult DeleteEmployee(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Employees.Remove(employee);
        //    db.SaveChanges();

        //    return Ok(employee);
        //}


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

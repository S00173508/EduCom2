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

        [Route("getTopics")]
        [HttpGet]
        public Topic getTopicInfo(int topicId)
        {
            return repo.GetTopics(topicId);
        }

        // POST: api/Topics
        [Route("postTopics")]
        public Topic PostTopic(Topic topic)
        {
            return repo.CreateNewTopic(topic);
         
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

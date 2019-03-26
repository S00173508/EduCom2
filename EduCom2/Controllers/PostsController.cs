using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using EduCom2.Models;
using EduCom2.Models.DTO;
using EduComDataLayer;

namespace EduCom2.Controllers
{
    [RoutePrefix("api/EduCom")]
    //[EnableCors("*", "http://localhost:64135/api/EduCom/getAllPosts/", "*", "*")]
    [EnableCors("*", "http://localhost:64135/api/EduCom/AddPost/", "*", "*")]

    public class PostsController : ApiController
    {
        private EduContext db = new EduContext();
        private TopicPostRepository repo = new TopicPostRepository();


        [Route("getAllPosts/{topicID:int}")]
        [HttpGet]
        public List<Post> getAllPosts(int topicID)
        {
            return repo.GetPosts(topicID);
        }

        [EnableCors("*", "http://localhost:64135/api/EduCom/AddPost/", "*", "*")]
        [Route("AddPost/{topicId:int}/{text}")]
        [HttpPost]
        public IHttpActionResult PostNewPost(int topicId, string text)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            else
            {
                repo.NewPost(topicId, text);
                db.SaveChanges();
                return Ok();
            }


        }



        //Post: Add Post
        //[EnableCors("*", "http://localhost:64135/api/EduCom/AddPost/", "*", "*")]
        //[Route("AddPost")]
        //[HttpPost]      
        //public IHttpActionResult Post(PostViewModel post)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data.");

        //    using (var db = new EduContext())
        //    {
        //        db.Posts.Add(new Post()
        //        {
        //            Text = post.Text,
        //            TopicId = post.TopicId
        //        });

        //        db.SaveChanges();
        //    }

        //    return Ok();
        //}
        // DELETE: api/Topic
        [Route("delatePosts/{postId:int}")]
        [HttpDelete]
        public void DelatePosts(int postId)
        {
            repo.DeletePostById(postId);

        }

        //[Route("getAllPosts")]
        //[HttpGet]
        //public List<Post> getAllPosts()
        //{
        //    return repo.GetPosts();
        //}

        // GET: api/Posts
        [Route("getPosts")]
        [HttpGet]
        public IQueryable<Post> GetPosts()
        {

            return db.Posts;
        }


        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        //Put: Update a Previous Post
        [EnableCors("*", "http://localhost:64135/api/EduCom/UpdatePost/", "*", "*")]
        [Route("UpdatePost/{id:int}/{topicId:int}/{text}")]
        [HttpPut]
        public HttpResponseMessage PutPost(int id, int topicId, string text)
        {

           // post.ID = id;
            //post.TopicId = topicId;
            //post.Text = text;
            if (id == null)/*(!repo.Update(post))*/
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                repo.Update(id, topicId, text);
                return Request.CreateResponse(HttpStatusCode.OK);
            }


        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.ID)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.ID }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.ID == id) > 0;
        }
    }
}
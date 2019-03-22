using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class TopicController : Controller
    {
        public static HttpClient webClient = new HttpClient();
        // GET: Topic
        public ActionResult Index()
        {
            IEnumerable<TopicModel> topic;
            //HttpResponseMessage webResponse = webClient.GetAsync("http://localhost:64135/api/EduCom/getAllTopics/").Result;
            HttpResponseMessage webResponse = GlobalVariables.WebApiClient.GetAsync("getAllTopics").Result;
            topic = webResponse.Content.ReadAsAsync<IEnumerable<TopicModel>>().Result;

            //IEnumerable<mvcEmployeeModel> empList;
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            //empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            //return View(empList);

           // return View();

            return View(topic);
        }
    }
}
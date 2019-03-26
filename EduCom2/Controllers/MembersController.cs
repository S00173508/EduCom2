using EduCom2.Models;
using EduCom2.Models.DTO;
using EduComDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using EduComDataLayer;

namespace EduCom2.Controllers
{
        [RoutePrefix("api/EduCom")]
    public class MembersController : ApiController
    {

        EduComRepository db = new EduComRepository();


        [Route("getSub/{memberId:int}")]
        [HttpGet]
        public Subscribe getSub(int memberId)
        {
            return db.GetSub(memberId);
        }


        [Route("getAllMembers")]
         [HttpGet]
         public List<Member> getAllMembersInfo()
            {
                return db.GetAllMembers();
            }

        public enum AUTHSTATUS { NONE, OK, INVALID, FAILED }

        //class ClientAuthentication
        //{
        static public string baseWebAddress = "http://localhost:59644/";
        static public string AuthToken = "";
        static public AUTHSTATUS AuthStatus = AUTHSTATUS.NONE;
        // static public string IgdbUserToken = "PUT YOUR EXTERNAL WEB API TOKEN HERE";
        [Route("login/{username}/{password}")]
        [HttpGet]
        public bool login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                    });
                var result = client.PostAsync(baseWebAddress + "Token", content).Result;
                try
                {
                    var resultContent = result.Content.ReadAsAsync<Token>(
                        new[] { new JsonMediaTypeFormatter() }
                        ).Result;
                    string ServerError = string.Empty;
                    if (!(String.IsNullOrEmpty(resultContent.AccessToken)))
                    {
                        Console.WriteLine(resultContent.AccessToken);
                        AuthToken = resultContent.AccessToken;
                        AuthStatus = AUTHSTATUS.OK;
                        return true;
                    }
                    else
                    {
                        AuthToken = "Invalid Login";
                        AuthStatus = AUTHSTATUS.INVALID;
                        Console.WriteLine("Invalid credentials");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    AuthStatus = AUTHSTATUS.FAILED;
                    AuthToken = "Server Error -> " + ex.Message;
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
    }

}



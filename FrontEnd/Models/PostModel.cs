using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public string topicID { get; set; }
        public string text { get; set; }
        public int BoardID { get; set; }
    }
}

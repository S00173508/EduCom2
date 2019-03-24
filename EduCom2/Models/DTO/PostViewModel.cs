using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCom2.Models.DTO
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }

    }
}
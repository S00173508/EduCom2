using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class Post
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
    public class Topic
    {
        public int ID { get; set; }
        public string TopicName { get; set; }
        public ICollection<Post> Posts { get; set; }
        public virtual ICollection<Member> Members { get; set; }

    }

    public class Member

    {

        public int MemberID { get; set; }
        public string MemberName { get; set; }

        public virtual ICollection<Topic> AssociatedTopic { get; set; }


    }
}

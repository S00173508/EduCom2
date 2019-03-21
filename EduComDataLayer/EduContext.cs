using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComDataLayer
{
    public class EduContext: DbContext
    {
      
            public EduContext() : base("EduComConnection")
            {
                Database.SetInitializer(new EduComInitializer());
                Database.Initialize(true);
            }

            public DbSet<Post> Posts { get; set; }
            public DbSet<Topic> Topics { get; set; }
            public DbSet<Member> Members { get; set; }


        }
    [Table("Post")]

    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

    }

    [Table("Topic")]

    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TopicName { get; set; }
        public ICollection<Post> Posts { get; set; }
        public virtual ICollection<Member> Members { get; set; }

    }
    [Table("Member")]

    public class Member

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public virtual ICollection<Topic> AssociatedTopic { get; set; }


    }
}


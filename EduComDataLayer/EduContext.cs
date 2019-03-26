using Newtonsoft.Json;
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
    public class EduContext : DbContext
    {

        public EduContext() : base("EduComConnection")
        {
            Database.SetInitializer(new EduComInitializer());
            Database.Initialize(true);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Members)
                .WithMany(t => t.Topics)
                .Map(m =>
                {
                    m.ToTable("TopicMembers");
                    m.MapLeftKey("TopicID");
                    m.MapRightKey("MemberID");
                });
            base.OnModelCreating(modelBuilder);
        }

    }
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Text { get; set; }

        //a post has one topic
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        //a post has one members
        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public Member Member { get; set; }

    }

    [Table("Topic")]
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TopicName { get; set; }
        public int ModeratorID { get; set; }

        [ForeignKey("Members")]
        public int MemberId { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public string MemberName { get; set; }

        //a member has many topics
        [ForeignKey("Topics")]
        public int TopicId { get; set; }
        public ICollection<Topic> Topics { get; set; }

        //a member has many posts
        public ICollection<Post> Posts { get; set; }

    }

    [Table("Subscribe")]
    public class Subscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Topics")]
        public int TopicId { get; set; }
        public ICollection<Topic> Topics { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public Member Member { get; set; }

    }
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}



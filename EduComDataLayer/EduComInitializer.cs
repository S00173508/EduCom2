using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EduComDataLayer.EduContext;

namespace EduComDataLayer
{
    class EduComInitializer : DropCreateDatabaseIfModelChanges<EduContext>
    {
        public EduComInitializer()
        {

        }
        protected override void Seed(EduContext context)
        {
            context.Topics.AddOrUpdate(t => t.TopicName, new Topic[]
                     {
                        new Topic{ TopicName="Sports", 
                        Posts = new List<Post>
                        {
                            new Post { Text="I think the running club is great"}
                        },
                        Members= new List<Member>
                        {
                            new Member {MemberName="Aoife" }

                        }
                        
                        }
                     });
          
            base.Seed(context);


        }
            
           
    }
}

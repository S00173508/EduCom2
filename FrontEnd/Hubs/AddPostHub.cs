using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FrontEnd.Models;
using Microsoft.AspNet.SignalR;

namespace FrontEnd.Hubs
{
    public class AddPostHub : Hub
    {
        static ConcurrentDictionary<string, PostModel> postDictionary =
           new ConcurrentDictionary<string, PostModel>();
        public void firstHandShake()
        {
            Parallel.ForEach(postDictionary, (movingShape) =>
            {
                Clients.Caller.updateShape(movingShape.Value);
            });

        }
        public void UpdateModel(PostModel postModel)
        {
            postDictionary[postModel.Id] = postModel;

            Clients.Others.updateShape(postModel);

        }
        public void AddNewShape(PostModel postModel)
        {
            postDictionary[postModel.Id] = postModel;
            Clients.Others.newShapeAdded(postModel);
        }

    }
}
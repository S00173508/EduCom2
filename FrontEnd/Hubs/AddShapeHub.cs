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
    public class AddShapeHub : Hub
    {
        static ConcurrentDictionary<string, PostModel> shapesDictionary =
           new ConcurrentDictionary<string, PostModel>();

        public void FirstHandShake()
        {
            Parallel.ForEach(shapesDictionary, (movingShape) =>
            {
                Clients.Caller.newShapeAdded(movingShape.Value);
            });
        }

        public void AddNewShape(PostModel postModel)
        {
            shapesDictionary[postModel.Id] = postModel;
            Clients.Others.newShapeAdded(postModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace MusicApp.App_Start
{
    public class MongoDbContext
    {
        public IMongoDatabase db;

        public MongoDbContext()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");

        }
    }
}
using MongoDB.Driver;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Database
{
    public class MongoDatabaseConnection
    {

        public MongoDatabaseConnection()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");
            var coll = db.GetCollection<SongModel>("songs");

        }

        public static SongModel getSong(String title)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");
            var coll = db.GetCollection<SongModel>("song");


            var result = coll
                .Find(song => song.title == title)
                .ToList();
            return result.FirstOrDefault();
        }

        public static List<SongModel> getSongs()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");
            var coll = db.GetCollection<SongModel>("song");
            
            var titles = new List<String>();

            var result = coll.AsQueryable().Select(x=>x) .ToList();
            return result;
        }
    }
}
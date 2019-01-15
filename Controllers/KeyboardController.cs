using MongoDB.Bson;
using MongoDB.Driver;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class KeyboardController : Controller
    {
        List<SongModel> tempSongs;

        // GET: Keyboard
        public ActionResult Keyboard()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");
            var coll = db.GetCollection<SongModel>("song");

            var myId = new ObjectId("5c3bdb5339bf6e202de49307");

            var result = coll
                .Find(user => user.Id == myId)
                .ToList();


            tempSongs = result;


            return View(tempSongs.FirstOrDefault());
        }

      

        
    }
}
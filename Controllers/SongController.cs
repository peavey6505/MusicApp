using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApp.App_Start;
using MongoDB.Driver;
using MusicApp.Models;
using MongoDB.Bson;

namespace MusicApp.Controllers
{
    public class SongController : Controller
    {

        private MongoDbContext dbContext;
        private IMongoCollection<SongModel> songCollection;
        String message = "";

        List<SongModel> tempSongs;

        public SongController()
        {
            //dbContext = new MongoDbContext();
            //songCollection = dbContext.db.GetCollection<SongModel>("songs");

            var client = new MongoClient();
            var db = client.GetDatabase("MusicAppDb");
            var coll = db.GetCollection<SongModel>("songs");

            var myId = new ObjectId("5c33f2ceb4a408031f33af91");

            var result = coll
                .Find(user => user.Id == myId)
                .ToListAsync()
                .Result;


            tempSongs = result;
           

            
        }

        // GET: Songs
        public ActionResult Index()
        {
            String notes = "";
            string lengths = "";

            //foreach (var song in tempSongs)
            //{
            //    foreach (var note in song.melody.notes)
            //        notes += note + "\n";
            //    foreach (var length in song.melody.lengths)
            //        lengths += length + "\n";
            //}

            string result = notes + lengths;
            
           

            return Content(result);
        }

        // GET: Song/Details/5
        public ActionResult Details(string id)
        {
            var songId = new ObjectId(id);
            var song = songCollection.AsQueryable<SongModel>().SingleOrDefault(x=>x.Id==songId);
            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(SongModel song)
        {
            try
            {
                // TODO: Add insert logic here

                songCollection.InsertOne(song);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Edit/5
        public ActionResult Edit(string id)
        {
            var songId = new ObjectId(id);
            var product = songCollection.AsQueryable<SongModel>().SingleOrDefault(x => x.Id == songId);
            return View();
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SongModel song)
        {
            try
            {
                var filter = Builders<SongModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<SongModel>.Update
                    .Set("title", song.title)
                    .Set("author", song.author);


                    var result = songCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Delete/5
        public ActionResult Delete(string id)
        {
            var songId = new ObjectId(id);
            var song = songCollection.AsQueryable<SongModel>().SingleOrDefault(x => x.Id == songId);
            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                songCollection.DeleteOne(Builders<SongModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

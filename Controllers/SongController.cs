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
           
            
        }

        // GET: Songs
        public ActionResult Index()
        {

            return View();
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
                    ;


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

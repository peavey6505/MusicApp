using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{

    public class SongModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string title { get; set; }
        public Bar[] bars { get; set; }
    }

    public class Bar
    {
        public string[] notes { get; set; }
        public int[] lengths { get; set; }
        public int noteCounter { get; set; }
    }


}
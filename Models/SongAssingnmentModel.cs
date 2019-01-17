using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class SongAssingnmentModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongDetailsId { get; set; }
        public int StartTempo { get; set; }
        public int DestinationTempo { get; set; }
    }


}
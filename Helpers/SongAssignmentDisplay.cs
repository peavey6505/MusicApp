using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class SongAssignmentDisplay
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int OrginalTempo { get; set; }
        public int StartTempo { get; set; }
        public int DestinationTempo { get; set; }
    }
}
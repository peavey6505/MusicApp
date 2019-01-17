using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class SongAssignmentViewModel
    {
        public List<SongAssingnmentModel> SongAssignments { get; set; }
        public List<UserModel> Users { get; set; }
        public List<SongDetailsModel> SongsDetails { get; set; }
        public string ChosenStudent { get; set; }
        public List<SongAssignmentDisplay> SongAssignmentsDisplay { get; set; }

    }



}
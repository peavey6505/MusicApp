using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class SongModeViewModel
    {
        public List<SongModel> Songs { get; set; }
        public string ChosenTitle { get; set; }
        public SongModeViewModel()
        {

        }
    }
}
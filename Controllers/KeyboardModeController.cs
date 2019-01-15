using MusicApp.Database;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class KeyboardModeController : Controller
    {
        // GET: KeyboardMode
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChooseMode(KeyboardModeModel keyboardMode)
        {
            if (keyboardMode.Mode == "free")
                return View("~/Views/Keyboard/Index.cshtml");
            else if (keyboardMode.Mode == "exercise")
                return View("~/Views/KeyboardMode/ExerciseMode.cshtml");
            else if (keyboardMode.Mode == "song")
                return RedirectToAction("showSongs");
            else if (keyboardMode.Mode == "improvisation")
                return View("~/Views/KeyboarMode/Index.cshtml");
            else
                return View("~/Views/Keyboard/Index.cshtml");
        }


        public ActionResult showSongs() {
            SongModeViewModel songViewModel = new SongModeViewModel();
            songViewModel.Songs = MongoDatabaseConnection.getSongs();

            return View("~/Views/KeyboardMode/SongMode.cshtml",songViewModel);
        }

        [HttpPost]
        public ActionResult LoadSong(SongModeViewModel songViewModel)
        {
            SongModel song = MongoDatabaseConnection.getSong(songViewModel.ChosenTitle);
            return View("~/Views/Keyboard/Index.cshtml", song);
        }


    }
}
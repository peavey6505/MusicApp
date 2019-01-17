using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApp.Database;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class SongAssignmentController : Controller
    {
        // GET: SongAssignment
        public ActionResult Index()
        {
            SongAssignmentViewModel songAssignmentVM = new SongAssignmentViewModel();
            songAssignmentVM.SongsDetails = SqlDatabaseConnection.getSongsDetails();
            songAssignmentVM.Users = SqlDatabaseConnection.getStudents();

            return View(songAssignmentVM);
        }

        [HttpPost]
        public ActionResult DisplayAssignments(SongAssignmentViewModel songAssignmentVM)
        {

            //TO DO!
            songAssignmentVM = new SongAssignmentViewModel();
            songAssignmentVM.SongsDetails = SqlDatabaseConnection.getSongsDetails();
            songAssignmentVM.Users = SqlDatabaseConnection.getStudents();
            songAssignmentVM.SongAssignments = SqlDatabaseConnection.getSongAssignments();

            string chosenStudent = songAssignmentVM.ChosenStudent;
            string[] fullName;
            string firstName = null;
            string lastName = null;
            //if (string.IsNullOrEmpty(chosenStudent))
            //{
            //     fullName = chosenStudent.Split();
            //     firstName = fullName[0];
            //     lastName = fullName[1];
            //}





            //int chosenStudentId = int.Parse(songAssignmentVM.Users
            //    .Where(user => user.FirstName == firstName && user.LastName == lastName)
            //    .Select(user => user.Id)
            //    .ToList().FirstOrDefault().ToString());

            int chosenStudentId = 2;

            List<SongAssingnmentModel> assignmentsToDisplay = songAssignmentVM.SongAssignments
                .Where(a => a.UserId == chosenStudentId)
                .Select(a => a)
                .ToList();

            List<SongDetailsModel> detailsToDisplay = new List<SongDetailsModel>();
            foreach(var assignment in assignmentsToDisplay)
            {
                detailsToDisplay.Add(songAssignmentVM.SongsDetails
                    .Where(det => det.Id == assignment.SongDetailsId)
                    .Select(a => a)
                    .ToList().First());
            }

            List<SongAssignmentDisplay> result = new List<SongAssignmentDisplay>();

            if(assignmentsToDisplay.Count == detailsToDisplay.Count)
            {
                for(int i =0; i< assignmentsToDisplay.Count; i++)
                {
                    result.Add(new SongAssignmentDisplay()
                    {
                        Title = detailsToDisplay[i].Title,
                        Author = detailsToDisplay[i].Author,
                        OrginalTempo = detailsToDisplay[i].OrginalTempo,
                        StartTempo = assignmentsToDisplay[i].StartTempo,
                        DestinationTempo = assignmentsToDisplay[i].DestinationTempo
                    });
                }
            }
            songAssignmentVM.SongAssignmentsDisplay = result;

            return View("~/Views/SongAssignment/Index.cshtml",songAssignmentVM);
        }
    }
}
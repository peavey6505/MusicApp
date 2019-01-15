using MusicApp.Database;
using MusicApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(UserModel user) {
            MySqlConnection dbConnection = new SqlDatabaseConnection().dbConnection;

            String query = $"SELECT * FROM user WHERE username='{user.Username}' AND password='{user.Password}' AND role='{user.Role}'";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return View("~/Views/Home/Index.cshtml", user);
            }
            else
            {
                ViewBag.Error = "Wrong username or password";
                return View("~/Views/Login/Index.cshtml", user);
            }

            
        }
    }
}
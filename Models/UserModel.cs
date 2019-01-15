using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdult { get; set; }
        public string Role { get; set; }

        public UserModel()
        {

        }

        public UserModel(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }

    }
}
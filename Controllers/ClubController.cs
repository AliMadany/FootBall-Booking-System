using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M3gogo.DBLayer;
using M3gogo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace M3gogo.Controllers
{
    public class ClubController : Controller
    {

        string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;


        // GET: Club
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("CreateClub")]
        public ActionResult CreateClub() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateClub(Club club) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {
            FootballContext dBContext = new FootballContext();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "insert into Club values (@Name,@Location)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", club.Name);
                    command.Parameters.AddWithValue("@Location", club.Location);

                    connection.Open();
                     command.ExecuteNonQuery();

                    
                }
            }

   


            return View(club);
        }


        [HttpGet]
        
        public ActionResult Deleteclub() // display view UI form to enter club details get method
        {

            return View();
        }


        [HttpPost]
        
        public ActionResult Deleteclub(Club club)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "Delete From club where cName =  @cName";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@cName", club.Name);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }
            return View (club);

        }



    }
}
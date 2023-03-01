using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M3gogo.BLL;
using M3gogo.DBLayer;
using M3gogo.Models;

namespace M3gogo.Controllers
{
    public class StadiumController : Controller
    {



       StadiumBLL stadiumBLL= new StadiumBLL();
        // GET: Stadium
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("CreateStadium")]
        public ActionResult CreateStadium() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateStadium(Stadium stadium) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {

            stadiumBLL.CreateStadium(stadium);
        


            return View(stadium);
        }
        [HttpGet]
        
        public ActionResult DeleteStadium() // display view UI form to enter club details get method
        {

            return View();
        }
        [HttpPost]
        public ActionResult DeleteStadium(Stadium stadium) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {


            stadiumBLL.DeleteStadium(stadium);

       

            return View(stadium);
        }
    }
}
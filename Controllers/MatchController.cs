using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M3gogo.BLL;
using M3gogo.DBLayer;
using M3gogo.Models;

namespace M3gogo.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PassDate() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult PassDate(availableMatchesToAttend availableMatchesToAttend1) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            //DateTime pass = DateTime.Parse(availableMatchesToAttend1);
           // int res = DateTime.Compare(availableMatchesToAttend1.start_time, DateTime.Now);

            
              return RedirectToAction("viewavailablematch", new { CurrentDate = availableMatchesToAttend1.start_time });

         

        }


           [HttpGet]
     
           public ActionResult viewavailablematch(DateTime CurrentDate) // post method to get called automatically after user clicks submit button to submit form to db with club model data
           {

               MatchBLL match = new MatchBLL();
               List<Match> list = match.viewavailablematch(CurrentDate).ToList();




               return View(list);
           }



          /* [HttpGet]

           public ActionResult ViewAlreadyPlayed(DateTime CurrentDate) // post method to get called automatically after user clicks submit button to submit form to db with club model data
           {

               MatchBLL match = new MatchBLL();
               List<Match> list = match.ViewAlreadyPlayed(CurrentDate).ToList();




               return View(list);
           }*/

        [HttpGet]
        public ActionResult Upcoming() // display view UI form to enter club details get method
        {

            MatchBLL match = new MatchBLL();
            List<allMatches>  matches = match.Upcoming().ToList();


            return View(matches);
        }

        [HttpGet]
        public ActionResult Alreadyplayed() // display view UI form to enter club details get method
        {

            MatchBLL match = new MatchBLL();
            List<allMatches> matches = match.Alreadyplayed().ToList();


            return View(matches);
        }



        [HttpGet]
        public ActionResult Creatematch() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult Creatematch(Match match) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {

        
            MatchBLL newmatch = new MatchBLL();
            newmatch.Creatematch(match);



            return View();


        }


        [HttpGet]
        public ActionResult Deletematch() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult Deletematch(Match match) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {


            MatchBLL newmatch = new MatchBLL();
            newmatch.Deletematch(match);



            return View();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M3gogo.BLL;
using M3gogo.DBLayer;
using M3gogo.Models;

namespace M3gogo.Controllers
{
    public class RegisterController : Controller
    {

        FootballContext footballContext = new FootballContext();
     
        RegisterBLL Register1 = new RegisterBLL();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
       


        [HttpGet]


        [ActionName("signUpAM")]
        public ActionResult signUpAM() // display view UI form to enter club details get method
        {

            
           
                return View();
            
            
        }

        [HttpPost]
        public ActionResult signUpAM(AM register) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {

            /*if (footballContext.users.Any(x=>x.username == register.username))
            {
                ModelState.AddModelError("username", "username already exists");
            }*/

            if (!ModelState.IsValid)
            {
                return View();
            }



            Register1.signUpAM(register);

           return  RedirectToAction("insideSAM", "base");

          //  return View(register);
        }

        
        public ActionResult signUpFan() // display view UI form to enter club details get method
        {

            return View();
        }

        [HttpPost]
        public ActionResult signUpFan(Fan register1) // post method to get called automatically after user clicks submit button to submit form to db with club model data
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            Register1.signUpFan(register1);
            return RedirectToAction("insidefan", "base");


            
        }
    }
}
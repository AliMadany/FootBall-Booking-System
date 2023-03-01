using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml.Linq;
using M3gogo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using M3gogo.DBLayer;
using System.Configuration;


namespace M3gogo.BLL
{
    public class RegisterBLL
    {

         public void signUpAM(AM AM)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
            FootballContext dBContext = new FootballContext();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("[addAssociationManager]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", AM.name));
                cmd.Parameters.Add(new SqlParameter("@username", AM.username));
                cmd.Parameters.Add(new SqlParameter("@password", AM.password));

                connection.Open();
                cmd.ExecuteNonQuery();
                /*  try
                  {
                      conn.Open();
                      int success = cmd.ExecuteNonQuery();
                      conn.Close();

                      if (success != 0)
                      {
                          Session["isClubRepresentativeLoggedIn"] = "true";
                          Session["clubName"] = cn;
                          // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                          //     Response.Cache.SetExpires(DateTime.Now.AddMinutes(-30));
                          Page_Load(sender, e);
                      }
                      else
                      {
                          Response.Write("something went wrong");
                      }
                  }
                  catch
                  {
                      Response.Write("something went wrong");
                  }*/
            }
        }
        public void signUpFan(Fan fan)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
            FootballContext dBContext = new FootballContext();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("[addFan]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", fan.name));
                cmd.Parameters.Add(new SqlParameter("@username",fan.username));
                cmd.Parameters.Add(new SqlParameter("@password", fan.password));
                cmd.Parameters.Add(new SqlParameter("@nationalId", fan.nationalId));
                cmd.Parameters.Add(new SqlParameter("@birthDate", fan.BirthDate));
                cmd.Parameters.Add(new SqlParameter("@address", fan.Adress));
                cmd.Parameters.Add(new SqlParameter("@phoneNumber", fan.phoneNumber));
                connection.Open();
                cmd.ExecuteNonQuery();
                /*  try
                  {
                      conn.Open();
                      int success = cmd.ExecuteNonQuery();
                      conn.Close();

                      if (success != 0)
                      {
                          Session["isClubRepresentativeLoggedIn"] = "true";
                          Session["clubName"] = cn;
                          // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                          //     Response.Cache.SetExpires(DateTime.Now.AddMinutes(-30));
                          Page_Load(sender, e);
                      }
                      else
                      {
                          Response.Write("something went wrong");
                      }
                  }
                  catch
                  {
                      Response.Write("something went wrong");
                  }*/
            }
        }


    }
}
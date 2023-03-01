using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using M3gogo.DBLayer;
using M3gogo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace M3gogo.BLL
{
    public class MatchBLL
    {



        public List<allMatches> Upcoming()
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
            FootballContext dBContext = new FootballContext();

            List<allMatches> upcominglist = new List<allMatches>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "select * from allMatches where startTime >" + "'"+ DateTime.Now.ToString()+"'" ;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allMatches coming = new allMatches();

                            // process result
                            coming.Host = reader.GetString(0); // get first column from view, assume it's a 32-bit int
                            coming.Guest = reader.GetString(1); // get second column from view, assume it's a string
                            coming.StartTime = reader.GetDateTime(2);                                                // etc.

                            upcominglist.Add(coming);

                        }
                    }
                }
            }

            return upcominglist;

        }
        public List<allMatches> Alreadyplayed()
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
            FootballContext dBContext = new FootballContext();

            List<allMatches> upcominglist = new List<allMatches>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "select * from allMatches where startTime <" + "'" + DateTime.Now.ToString() + "'";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allMatches coming = new allMatches();

                            // process result
                            coming.Host = reader.GetString(0); // get first column from view, assume it's a 32-bit int
                            coming.Guest = reader.GetString(1); // get second column from view, assume it's a string
                            coming.StartTime = reader.GetDateTime(2);                                                // etc.

                            upcominglist.Add(coming);

                        }
                    }
                }
            }

            return upcominglist;

        }





         public List<Match> viewavailablematch(DateTime dateTime) // 2.2D All upcoming matches
          {
              List<Match> upcomingList1 = new List<Match>();
              string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;





              using (SqlConnection connection = new SqlConnection(connectionString))
              {

                  SqlCommand cmd = new SqlCommand("select * from availableMatchesToAttend(" + "'" + dateTime + "'" + ")", connection);
                  DateTime currenttime = DateTime.Now;
                  SqlParameter parm1 = new SqlParameter();
                  parm1.ParameterName = "@StartTime";
                  parm1.SqlDbType = SqlDbType.DateTime;
                  parm1.Value = DateTime.Now;
                    
                   cmd.Parameters.Add(parm1);
                  cmd.CommandType = CommandType.Text;

                  connection.Open();

                  SqlDataReader dr = cmd.ExecuteReader();

                  //    cmd.Parameters.AddWithValue("@dateTime", dateTime );

                  while (dr.Read())
                  {
                      Match upmatches = new Match();

                      upmatches.HostClub = dr["club_name"].ToString();
                      upmatches.GuestClub = dr["Guest_Club"].ToString();
                      upmatches.StartTime = Convert.ToDateTime(dr["Start_time"]);
                      upmatches.Stadium = dr["Stadium_hosting"].ToString();



                      upcomingList1.Add(upmatches);

                  }

              }
              return (upcomingList1);

          }
  


        /* public List<Match> ViewAlreadyPlayed(DateTime dateTime1) // 22.E Already played matches
         {
             List<Match> upcomingList1 = new List<Match>();
             string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;


             using (SqlConnection connection = new SqlConnection(connectionString))
             {

                 SqlCommand cmd = new SqlCommand("select * from availableMatchesToAttend(" + "'" + dateTime1 + "'" + ")", connection);



                 DateTime currenttime = DateTime.Now;
                 *//*SqlParameter parm1 = new SqlParameter();
                 parm1.ParameterName = "@StartTime";
                 parm1.SqlDbType = SqlDbType.DateTime;
                 parm1.Value = DateTime.Now;*//*
                 // cmd.Parameters.Add(parm1);
                 cmd.CommandType = CommandType.Text;

                 connection.Open();

                 SqlDataReader dr = cmd.ExecuteReader();

                 //    cmd.Parameters.AddWithValue("@dateTime", dateTime );

                 while (dr.Read())
                 {
                     Match upmatches = new Match();

                     upmatches.HostClub = dr["club_name"].ToString();
                     upmatches.GuestClub = dr["Guest_Club"].ToString();
                     upmatches.StartTime = Convert.ToDateTime(dr["Start_time"]);
                     upmatches.Stadium = dr["Stadium_hosting"].ToString();

                     upcomingList1.Add(upmatches);

                 }


             }
             return (upcomingList1);

         }*/





        public void Creatematch(Match match)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addNewMatch", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraHost = new SqlParameter();
                paraHost.ParameterName = "@hostClub";
                paraHost.Value = match.HostClub;
                cmd.Parameters.Add(paraHost);

                SqlParameter paraGuest = new SqlParameter();
                paraGuest.ParameterName = "@guestclub";
                paraGuest.Value = match.GuestClub;
                cmd.Parameters.Add(paraGuest);

                SqlParameter paraStartTime = new SqlParameter();
                paraStartTime.ParameterName = "@startTime";
                paraStartTime.Value = match.StartTime;
                cmd.Parameters.Add(paraStartTime);

                SqlParameter paraEndTime = new SqlParameter();
                paraEndTime.ParameterName = "@endTime";
                paraEndTime.Value = match.endTime;
                cmd.Parameters.Add(paraEndTime);



                connection.Open();
               cmd.ExecuteNonQuery();




            }






        }

        public void Deletematch(Match match)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteMatch", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraHost = new SqlParameter();
                paraHost.ParameterName = "@hostClubName";
                paraHost.Value = match.HostClub;
                cmd.Parameters.Add(paraHost);

                SqlParameter paraGuest = new SqlParameter();
                paraGuest.ParameterName = "@guestClubName";
                paraGuest.Value = match.GuestClub;
                cmd.Parameters.Add(paraGuest);



                connection.Open();
                cmd.ExecuteNonQuery();




            }






        }



    }

}
    
















      
   


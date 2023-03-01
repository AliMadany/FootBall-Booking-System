using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using M3gogo.DBLayer;
using M3gogo.Models;
using Microsoft.EntityFrameworkCore.Storage;


namespace M3gogo.BLL
{
    public class ClubBLL
    {

        public List<clubsNeverMatched> getclubsnevermatch(clubsNeverMatched neverwatched)
        {

            {
                string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
                FootballContext dBContext = new FootballContext();

                List<clubsNeverMatched> clubsNM = new List<clubsNeverMatched>();


                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("clubsNeverMatched", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        clubsNeverMatched club = new clubsNeverMatched();
                        club.Host = rdr["Host"].ToString();
                        club.Guest = rdr["Guest"].ToString();
                       



                        clubsNM.Add(club);
                    }



                }

                return clubsNM;
            }


        }
        public List<clubsNeverMatched> testView()
        { 


            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
            FootballContext dBContext = new FootballContext();

            List<clubsNeverMatched> clubsNeverMatchedList = new List<clubsNeverMatched>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * from clubsNeverMatched";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clubsNeverMatched clubsNeverMatchedd = new clubsNeverMatched();

                            // process result
                            clubsNeverMatchedd.Host = reader.GetString(0); // get first column from view, assume it's a 32-bit int
                            clubsNeverMatchedd.Guest = reader.GetString(1); // get second column from view, assume it's a string
                                                                           // etc.

                            clubsNeverMatchedList.Add(clubsNeverMatchedd);

                        }
                    }
                }
            }

            return clubsNeverMatchedList;

        }



    }
}
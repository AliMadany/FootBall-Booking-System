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
using System.Text.RegularExpressions;
using System.IO;

namespace M3gogo.BLL
{
    public class FanTicketBLL
    {

        public void purchaseticket(Fan fan)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("purchaseTicket", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paranationalID = new SqlParameter();
                paranationalID.ParameterName = "@national_id";
                paranationalID.Value = fan.nationalId;
                cmd.Parameters.Add(paranationalID);

                SqlParameter paraHost = new SqlParameter();
                paraHost.ParameterName = "@host_club";
                paraHost.Value = fan.host_club;
                cmd.Parameters.Add(paraHost);

                SqlParameter paraguest = new SqlParameter();
                paraguest.ParameterName = "@guest_club";
                paraguest.Value = fan.guest_club;
                cmd.Parameters.Add(paraguest);


                SqlParameter paraStartTime = new SqlParameter();
                paraStartTime.ParameterName = "@start_time";
                paraStartTime.Value = fan.start_time;
                cmd.Parameters.Add(paraStartTime);

             



                connection.Open();
                cmd.ExecuteNonQuery();




            }






        }
    }
}
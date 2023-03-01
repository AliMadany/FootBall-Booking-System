using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using M3gogo.DBLayer;
using M3gogo.Models;


namespace M3gogo.BLL
{
    public class StadiumBLL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FootballContext"].ConnectionString;
        FootballContext dBContext = new FootballContext();

        public void CreateStadium(Stadium stadium) {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "insert into Stadium (stName,stLocation,stCapacity) values (@Name,@Location,@Capacity)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", stadium.Name);
                    command.Parameters.AddWithValue("@Location", stadium.Location);
                    command.Parameters.AddWithValue("@Capacity", stadium.Capacity);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }


        }

        public void DeleteStadium(Stadium stadium) {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "Delete From Stadium where stName =  @stName";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@stName", stadium.Name);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }


        }

        public void BlockFan(Fan bfan)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                
                string query = "Update fan set fStatus = 1 where nationalid = @nationalId";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@nationalId", bfan.nationalId);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }


        }
      /*  public void upcoming(viewUpcomping test)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                string query = "Update fan set fStatus = 1 where nationalid = @nationalId";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@nationalId", test.nationalId);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }


        }*/


    }
}
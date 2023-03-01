using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3gogo
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (Session["isStadiumManagerLoggedIn"] == "true")
            {
                Control signup = Page.FindControl("signup");
                form1.Controls.Remove(signup);
                Control login = Page.FindControl("login");
                form1.Controls.Remove(login);

                try
                {
                    SqlCommand stadium = conn.CreateCommand();
                    stadium.CommandText = "SELECT * FROM allStadiums WHERE stName = '" + Session["stadiumName"] + "'";
                    conn.Open();
                    //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                    SqlDataReader rdr = stadium.ExecuteReader();

                    DataTable dt = new DataTable();
                    DataRow dr;

                    dt.Columns.Add("StadiumName");
                    dt.Columns.Add("StadiumLocation");
                    dt.Columns.Add("StadiumCapacity");
                    dt.Columns.Add("Available");

                    while (rdr.Read())
                    {
                        dr = dt.NewRow();
                        string name = rdr.GetString(0);
                        string location = rdr.GetString(1);
                        int capacity = rdr.GetInt32(2);
                        bool status = rdr.GetBoolean(3);

                        dr[0] = name;
                        dr[1] = location;
                        dr[2] = capacity;
                        dr[3] = status;
                        dt.Rows.Add(dr);

                    }
                    DataView dv = new DataView(dt);
                    itemsGrid.DataSource = dv;
                    itemsGrid.DataBind();



                    SqlCommand requests = conn.CreateCommand();
                    requests.CommandText = "SELECT * FROM allRequestsForManager('" + Session["stadiumManagerUsername"] + "')";
                    //conn.Open();
                    //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                    SqlDataReader rdr2 = requests.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    DataTable dt2 = new DataTable();
                    DataRow dr2;

                    dt2.Columns.Add("RepresentataiveName");
                    dt2.Columns.Add("hostClubName");
                    dt2.Columns.Add("guestClubName");
                    dt2.Columns.Add("startTime");
                    dt2.Columns.Add("endTime");
                    dt2.Columns.Add("status");

                    while (rdr2.Read())
                    {
                        dr2 = dt2.NewRow();
                        string repname = rdr2.GetString(0);
                        string hostcname = rdr2.GetString(1);
                        string guestcname = rdr2.GetString(2);
                        DateTime start = rdr2.GetDateTime(3);
                        DateTime end = rdr2.GetDateTime(4);
                        string stats = rdr2.GetString(5);



                        dr2[0] = repname;
                        dr2[1] = hostcname;
                        dr2[2] = guestcname;
                        dr2[3] = start;
                        dr2[4] = end;
                        dr2[5] = stats;


                        dt2.Rows.Add(dr2);

                    }
                    DataView dv2 = new DataView(dt2);
                    itemsGrid2.DataSource = dv2;
                    itemsGrid2.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("something went wrong");
                }
            }
            else
            {
                Control others = Page.FindControl("others");
                form1.Controls.Remove(others);
            }
        }

        protected void signUp(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String n = name.Text;
            String cn = clubName.Text;
            String u = username.Text;
            String p = password.Text;


            SqlCommand cmd = new SqlCommand("addStadiumManager", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@stadiumManagerName", n));
            cmd.Parameters.Add(new SqlParameter("@stadiumName", cn));
            cmd.Parameters.Add(new SqlParameter("@username", u));
            cmd.Parameters.Add(new SqlParameter("@password", p));

            try
            {
                conn.Open();
                int success = cmd.ExecuteNonQuery();
                conn.Close();

                if (success != 0)
                {
                    Session["isStadiumManagerLoggedIn"] = "true";
                    Session["stadiumName"] = cn;
                    Session["stadiumManagerUsername"] = u;
                    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //     Response.Cache.SetExpires(DateTime.Now.AddMinutes(-30));
                    Page_Load(sender, e);
                }
                else
                {
                    Response.Write("something went wrong");
                }
            }
            catch( Exception ex)
            {
                Response.Write("something went wrong");
            }

        }

        protected void acceptRequest(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String n = textBox1.Text;
            String g = textBox3.Text;
            DateTime h = DateTime.Parse(textBox4.Text);

            SqlCommand cmd = new SqlCommand("acceptRequest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@stadiumManagerUsername", Session["stadiumManagerUsername"]));
            cmd.Parameters.Add(new SqlParameter("@hostClubName", n));
            cmd.Parameters.Add(new SqlParameter("@guestClubName", g));
            cmd.Parameters.Add(new SqlParameter("@startTime", h));

            try
            {
                conn.Open();
                int success = cmd.ExecuteNonQuery();
                conn.Close();

                if (success != 0)
                {
                    Response.Write("request accepted successfully");
                }
                else
                {
                    Response.Write("something went wrong");
                }
            }
            catch (Exception ex)
            {
                Response.Write("something went wrong");
            }

        }

        protected void rejectRequest(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String n = textBox2.Text;
            String g = textBox5.Text;
            DateTime h = DateTime.Parse(textBox6.Text);

            SqlCommand cmd = new SqlCommand("rejectRequest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@stadiumManagerUsername", Session["stadiumManagerUsername"]));
            cmd.Parameters.Add(new SqlParameter("@hostClubName", n));
            cmd.Parameters.Add(new SqlParameter("@guestClubName", g));
            cmd.Parameters.Add(new SqlParameter("@startTime", h));

            try
            {
                conn.Open();
                int success = cmd.ExecuteNonQuery();
                conn.Close();

                if (success != 0)
                {
                    Response.Write("request rejected successfully");
                }
                else
                {
                    Response.Write("something went wrong");
                }
            }
            catch (Exception ex)
            {
                Response.Write("something went wrong");
            }

        }

        protected void loginF(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String u = TextBox7.Text;
            String p = TextBox8.Text;



            try
            {
                SqlCommand club = conn.CreateCommand();
                club.CommandText = "SELECT * FROM loginStadiumMan('" + u + "', '" + p + "')";
                conn.Open();
                //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                SqlDataReader rdr = club.ExecuteReader();


                while (rdr.Read())
                {
                    string name = rdr.GetString(0);
                    string clubn = rdr.GetString(1);

                    Session["isStadiumManagerLoggedIn"] = "true";
                    Session["stadiumName"] = clubn;

                }
                Page_Load(sender, e);

            }
            catch
            {
                Response.Write("something went wrong");
            }

        }
    }
}
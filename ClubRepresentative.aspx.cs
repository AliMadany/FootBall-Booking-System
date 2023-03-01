using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace M3gogo
{
    public partial class ClubRepresentative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //name clubname username password

            if (Session["isClubRepresentativeLoggedIn"] == "true")
            {
                Control signup = Page.FindControl("signup");
                form1.Controls.Remove(signup);
                Control login = Page.FindControl("login");
                form1.Controls.Remove(login);

                try
                {
                    SqlCommand club = conn.CreateCommand();
                    club.CommandText = "SELECT * FROM allClubs WHERE ClubName = '" + Session["clubName"] + "'";
                    conn.Open();
                    //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                    SqlDataReader rdr = club.ExecuteReader();

                    DataTable dt = new DataTable();
                    DataRow dr;

                    dt.Columns.Add("ClubName");
                    dt.Columns.Add("ClubLocation");

                    while (rdr.Read())
                    {
                        dr = dt.NewRow();
                        string name = rdr.GetString(rdr.GetOrdinal("ClubName"));
                        string location = rdr.GetString(rdr.GetOrdinal("ClubLocation"));
 
                        dr[0] = name;
                        dr[1] = location;
                        dt.Rows.Add(dr);

                    }
                    DataView dv = new DataView(dt);
                    itemsGrid.DataSource = dv;
                    itemsGrid.DataBind();



                    SqlCommand match = conn.CreateCommand();
                    match.CommandText = "SELECT * FROM upcomingMatchesOfClub('" + Session["clubName"] + "')";
                    //conn.Open();
                    //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                    SqlDataReader rdr2 = match.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    DataTable dt2 = new DataTable();
                    DataRow dr2;

                    dt2.Columns.Add("clubName");
                    dt2.Columns.Add("SecondClubName");
                    dt2.Columns.Add("startTime");
                    dt2.Columns.Add("stadiumName");

                    while (rdr2.Read())
                    {
                        dr2 = dt2.NewRow();
                        string clubName = rdr2.GetString(rdr2.GetOrdinal("clubName"));
                        string second = rdr2.GetString(rdr2.GetOrdinal("secondClubName"));
                        DateTime start = rdr2.GetDateTime(rdr2.GetOrdinal("startTime"));
                        string sname = "";
                        if(!rdr2.IsDBNull(3))
                        {
                            sname = rdr2.GetString(rdr2.GetOrdinal("stadiumName"));
                        }
                     
           

                        dr2[0] = clubName;
                        dr2[1] = second;
                        dr2[2] = start;
                        dr2[3] = sname;
                        

                        dt2.Rows.Add(dr2);

                    }
                    DataView dv2 = new DataView(dt2);
                    itemsGrid2.DataSource = dv2;
                    itemsGrid2.DataBind();
                }
                catch(Exception ex)
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


            SqlCommand cmd =  new SqlCommand("addRepresentative", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@representativeName", n));
            cmd.Parameters.Add(new SqlParameter("@clubName", cn));
            cmd.Parameters.Add(new SqlParameter("@representativeUsername", u));
            cmd.Parameters.Add(new SqlParameter("@representativePassword", p));

            try
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
            }

        }

        protected void getStadiums(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                SqlCommand club = conn.CreateCommand();
                club.CommandText = "SELECT * FROM viewAvailableStadiumsOn('" + DateTime.Parse(textBox2.Text) + "')";
                conn.Open();
    

                SqlDataReader rdr = club.ExecuteReader();

                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("stadiumNamw");
                dt.Columns.Add("stadiumLocation");
                dt.Columns.Add("stadiumCapacity");

                while (rdr.Read())
                {
                    dr = dt.NewRow();
                    string name = rdr.GetString(0);
                    string location = rdr.GetString(1);
                    string capacity = rdr.GetString(2);

                    dr[0] = name;
                    dr[1] = location;
                    dr[2] = capacity;
                    dt.Rows.Add(dr);

                }
                DataView dv = new DataView(dt);
                itemsGrid3.DataSource = dv;
                itemsGrid3.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void submitRequest(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            DateTime d = DateTime.Parse(textBox3.Text);
            String n = textBox4.Text;
            


            SqlCommand cmd = new SqlCommand("addHostRequest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@clubName", Session["clubName"]));
            cmd.Parameters.Add(new SqlParameter("@stadiumName", n));
            cmd.Parameters.Add(new SqlParameter("@startTime", d));

            try
            {
                conn.Open();
                int success = cmd.ExecuteNonQuery();
                conn.Close();

                if (success != 0)
                {
                    Response.Write("request submitted successfully");
                }
                else
                {
                    Response.Write("something went wrong");
                }
            }
            catch(Exception ex)
            {
                Response.Write("something went wrong");
            }

        }

        protected void loginF(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["FootballContext"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String u = TextBox6.Text;
            String p = TextBox7.Text;



            try
            {
                SqlCommand club = conn.CreateCommand();
                club.CommandText = "SELECT * FROM loginClubRep('" + u + "', '" + p + "')";
                conn.Open();
                //Response.Write("SELECT * FROM allClubs WHERE cName = '" + Session["clubName"] + "'");

                SqlDataReader rdr = club.ExecuteReader();


                while (rdr.Read())
                {
                    string name = rdr.GetString(0);
                    string clubn = rdr.GetString(1);

                    Session["isClubRepresentativeLoggedIn"] = "true";
                    Session["clubName"] = clubn;

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
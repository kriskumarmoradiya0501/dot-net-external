using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practiceDB2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserInfo"] != null)
                {
                    TextBox1.Text = Request.Cookies["UserInfo"]["Username"];
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(constr))
            {
                // CHANGE: Table name changed to 'data'
                string qry = "SELECT COUNT(1) FROM data WHERE username=@username AND password=@password";

                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    Session["username"] = TextBox1.Text.Trim();

                    if (CheckBox1.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["Username"] = TextBox1.Text.Trim();
                        cookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }

                    Response.Redirect("main.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Username or Password');</script>");
                }
            }
        }
    }
}
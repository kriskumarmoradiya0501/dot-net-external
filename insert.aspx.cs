using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practiceDB2
{
    public partial class insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome, " + Session["username"].ToString();
            }
        }

        protected void btnCalculateSave_Click(object sender, EventArgs e)
        {
            try
            {
                int maths = Convert.ToInt32(txtMaths.Text);
                int science = Convert.ToInt32(txtScience.Text);
                int english = Convert.ToInt32(txtEnglish.Text);

                int total = maths + science + english;
                // Use 3.0 to ensure decimal division
                decimal percentage = (decimal)total / 3;
                string grade = "";

                if (percentage >= 90) grade = "A+";
                else if (percentage >= 80) grade = "A";
                else if (percentage >= 60) grade = "B";
                else if (percentage >= 35) grade = "C";
                else grade = "Fail";

                string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(constr))
                {
                    // CHANGE: Converted from INSERT to UPDATE.
                    // We match the row using the logged-in 'username' and fill in the marks columns.
                    // We also map Session["username"] to the 'studentname' column.

                    string qry = "UPDATE data SET studentname=@stuname, Maths=@m, Science=@s, English=@e, Total=@tot, Percentage=@perc, Grade=@gr WHERE username=@user";

                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@user", Session["username"].ToString()); // Used for WHERE clause
                    cmd.Parameters.AddWithValue("@stuname", Session["username"].ToString()); // Fills studentname column
                    cmd.Parameters.AddWithValue("@m", maths);
                    cmd.Parameters.AddWithValue("@s", science);
                    cmd.Parameters.AddWithValue("@e", english);
                    cmd.Parameters.AddWithValue("@tot", total);
                    cmd.Parameters.AddWithValue("@perc", percentage);
                    cmd.Parameters.AddWithValue("@gr", grade);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        lblMessage.Text = "Result Updated Successfully! Percentage: " + percentage.ToString() + "%";
                        lblMessage.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Error: User not found or update failed.";
                        lblMessage.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}

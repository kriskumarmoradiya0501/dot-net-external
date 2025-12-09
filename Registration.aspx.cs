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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = txtUsername.Text;
                string password = txtPassword.Text;
                string gender = "";
                gender += rblGender.SelectedValue;
                string qualification = "";
                qualification += ddlQualification.SelectedValue;
                string mobile = txtMobile.Text;
                string imgpath = "";

                if (fuProfilePhoto.HasFile)
                {
                    string folderPath = Server.MapPath("~/Uploads/");
                    if (!System.IO.File.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    imgpath = "~/Uploads/" + fuProfilePhoto.FileName;
                    fuProfilePhoto.SaveAs(Server.MapPath(imgpath));
                }

                string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                // CHANGE: Table name is now 'data'. 
                // This creates the initial row with User info. The Marks columns will be NULL for now.
                String qry = "Insert into data (username,password,gender,qualification,mobile,imgpath) values (@username,@password,@gender,@qualification,@mobile,@imgpath)";

                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.Parameters.AddWithValue("@username", uname);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@qualification", qualification);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@imgpath", imgpath);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    // Optional: Redirect to login after success
                    Response.Write("<script>alert('Registration Successful'); window.location='Login.aspx';</script>");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid values");
            }
        }
    }
}

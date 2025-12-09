using System;
using System.Data.SqlClient;

namespace practiceDB2
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    // Store ID in Label
                    lblId.Text = id;

                    string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM data WHERE Id=@id", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txtUsername.Text = dr["username"].ToString();
                            txtPassword.Text = dr["password"].ToString();
                            rblGender.SelectedValue = dr["gender"].ToString();
                            ddlQualification.SelectedValue = dr["qualification"].ToString();
                            txtMobile.Text = dr["mobile"].ToString();
                            imgCurrent.ImageUrl = dr["imgpath"].ToString();

                            // Store old image path in Label
                            lblOldImagePath.Text = dr["imgpath"].ToString();

                            txtMaths.Text = dr["Maths"].ToString();
                            txtScience.Text = dr["Science"].ToString();
                            txtEnglish.Text = dr["English"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = lblId.Text;
            string imagePath = lblOldImagePath.Text;

            if (fuProfilePhoto.HasFile)
            {
                string newPath = "~/uploads/" + fuProfilePhoto.FileName;
                fuProfilePhoto.SaveAs(Server.MapPath(newPath));
                imagePath = newPath;
            }

            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE data 
                    SET username=@u, password=@p, gender=@g, qualification=@q, mobile=@m, 
                        imgpath=@img, Maths=@maths, Science=@science, English=@english 
                    WHERE Id=@id", con);

                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@g", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@q", ddlQualification.SelectedValue);
                cmd.Parameters.AddWithValue("@m", txtMobile.Text);
                cmd.Parameters.AddWithValue("@img", imagePath);
                cmd.Parameters.AddWithValue("@maths", txtMaths.Text);
                cmd.Parameters.AddWithValue("@science", txtScience.Text);
                cmd.Parameters.AddWithValue("@english", txtEnglish.Text);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("display.aspx");
        }
    }
}

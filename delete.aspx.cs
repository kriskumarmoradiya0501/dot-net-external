using System;
using System.Data.SqlClient;

namespace practiceDB2
{
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                DeleteRecord(id);
            }
            else
            {
                lblMessage.Text = "No ID provided.";
            }
        }

        private void DeleteRecord(int id)
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "DELETE FROM data WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    lblMessage.Text = "Record with ID " + id + " has been successfully deleted.";
                }
                else
                {
                    lblMessage.Text = "Deletion failed or ID not found.";
                }
            }
        }
    }
}

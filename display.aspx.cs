using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace practiceDB2
{
    public partial class display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
        }

        private void BindTable()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practiceDB2;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM data", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        StringBuilder sb = new StringBuilder();

                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr>");
                            sb.AppendFormat("<td>{0}</td>", row["Id"]);
                            sb.AppendFormat("<td>{0}</td>", row["username"]);
                            sb.AppendFormat("<td>{0}</td>", row["password"]);
                            sb.AppendFormat("<td>{0}</td>", row["gender"]);
                            sb.AppendFormat("<td>{0}</td>", row["qualification"]);
                            sb.AppendFormat("<td>{0}</td>", row["mobile"]);

                            sb.AppendFormat("<td><img src='{0}' height='50' width='50' /></td>", row["imgpath"]);

                            sb.AppendFormat("<td>{0}</td>", row["Maths"]);
                            sb.AppendFormat("<td>{0}</td>", row["Science"]);
                            sb.AppendFormat("<td>{0}</td>", row["English"]);
                            sb.AppendFormat("<td>{0}</td>", row["Total"]);
                            sb.AppendFormat("<td>{0}</td>", row["Percentage"]);
                            sb.AppendFormat("<td>{0}</td>", row["Grade"]);

                            // Action links
                            sb.AppendFormat("<td><a href='delete.aspx?id={0}'>Delete</a></td>", row["Id"]);
                            sb.AppendFormat("<td><a href='update.aspx?id={0}'>Update</a></td>", row["Id"]);

                            sb.Append("</tr>");
                        }

                        litTableRows.Text = sb.ToString();
                    }
                }
            }
        }
    }
}

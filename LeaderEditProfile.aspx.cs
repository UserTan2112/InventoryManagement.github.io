using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderEditProfile : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Leader")
        {
            Response.Redirect("SignIn.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                BindUserInfo();

            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblUsers SET FullName=@FullName, MobileNumber=@MobileNumber,Email=@Email WHERE UserID=@Uid", con);
            cmd.Parameters.AddWithValue("@FullName", txtName.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text);
            cmd.Parameters.AddWithValue("@Uid", Session["USERID"]);
            cmd.Parameters.AddWithValue("@Email", txtgmail.Text);
            cmd.ExecuteNonQuery();


            Response.Write("<script> alert('Updated Profile successfully'); </script>");
            con.Close();
        }
        
    }

    private void BindUserInfo()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select FullName,MobileNumber,Email from tblUsers where UserID=@Uid", con);
            cmd.Parameters.AddWithValue("@Uid", Session["USERID"]);
            // Execute the SQL query and retrieve the data
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["FullName"].ToString();
                txtMobile.Text = reader["MobileNumber"].ToString();
                txtgmail.Text = reader["Email"].ToString();
            }

            con.Close();
        }
    }

}
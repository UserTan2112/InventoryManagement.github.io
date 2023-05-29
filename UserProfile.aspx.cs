using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Engineer")
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

    private void BindUserInfo()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Username,FullName,MobileNumber,UserType,Email from tblUsers where UserID=" + Session["USERID"] + "", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblUsername.Text = reader["Username"].ToString();
                lblname.Text = reader["FullName"].ToString();
                lblUserType.Text = reader["UserType"].ToString();
                lblMobile.Text = reader["MobileNumber"].ToString();
                lblGmail.Text = reader["Email"].ToString();
            }

            con.Close();
        }
    }

}
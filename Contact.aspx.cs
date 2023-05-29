using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Engineer")
        {
            Response.Redirect("SignIn.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblContact(Name,Email,Question,MobileNumber,UserID,Date,Status) Values(@Name,@Email,@Question,@MobileNumber,@UserID,GETDATE(),@Status)", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Question", txtQuestion.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text);
            cmd.Parameters.AddWithValue("@UserID", Session["USERID"]);
            cmd.Parameters.AddWithValue("@Status", "Processing");
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Submit Question successfully'); </script>");
            clr();
            con.Close();
        }
    }

    private void clr()
    {
        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtQuestion.Text = string.Empty;
        txtMobile.Text = string.Empty;
    }
}
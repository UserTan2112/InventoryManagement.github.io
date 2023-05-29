using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUsers : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Admin")
        {
            Response.Redirect("SignIn.aspx");
        }
    }

    private bool isformatvalid()
    {
        if (txtUname.Text == "")
        {
            Response.Write("<script> alert('Username not valid'); </script>");
            txtUname.Focus();
            return false;
        }
        else if (txtPass.Text == "")
        {
            Response.Write("<script> alert('Password not valid'); </script>");
            txtPass.Focus();
            return false;
        }
        else if (txtPass.Text != txtCPass.Text)
        {
            Response.Write("<script> alert('Confirm Password not valid'); </script>");
            txtCPass.Focus();
            return false;
        }
        else if (txtEmail.Text == "")
        {
            Response.Write("<script> alert('Email not valid'); </script>");
            txtEmail.Focus();
            return false;
        }
        else if (txtName.Text == "")
        {
            Response.Write("<script> alert('Name not valid'); </script>");
            txtName.Focus();
            return false;
        }

        else if (txtMobile.Text == "")
        {
            Response.Write("<script> alert('Mobile Number not valid'); </script>");
            txtMobile.Focus();
            return false;
        }
        return true;
    }

    private void clr()
    {
        txtName.Text = string.Empty;
        txtPass.Text = string.Empty;
        txtUname.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtCPass.Text = string.Empty;
        txtMobile.Text = string.Empty;
        ddlUserType.SelectedIndex = -1;
    }


    protected void AddUsers_Click1(object sender, EventArgs e)
    {
        if (isformatvalid())
        {
            // Check if username already exists
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblUsers WHERE Username = @username", con);
                checkCmd.Parameters.AddWithValue("@username", txtUname.Text);
                int userCount = (int)checkCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    // Username already exists
                    Response.Write("<script> alert('Username already exists.'); </script>");
                    lblMsg.Text = "Username already exists.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
            {
                con.Open();
                SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM tblUsers WHERE Email = @Email", con);
                checkEmail.Parameters.AddWithValue("@Email", txtEmail.Text);
                int EmailCount = (int)checkEmail.ExecuteScalar();

                if (EmailCount > 0)
                {
                    // Username already exists
                    Response.Write("<script> alert('Email already exists.'); </script>");
                    lblMsg.Text = "Email already exists.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            // Add user to database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblUsers(Username, Password, Email, FullName, MobileNumber, Usertype) VALUES (@Username, @Password, @Email, @Name, @MobileNumber, @Usertype)", con);
                cmd.Parameters.AddWithValue("@Username", txtUname.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Usertype", ddlUserType.SelectedValue);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Register successfully'); </script>");

                clr();
                con.Close();
                lblMsg.Text = "Added User Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;

            }
        }
        else
        {
            Response.Write("<script> alert('Register failed'); </script>");
            lblMsg.Text = "All field are mandatory";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    
}
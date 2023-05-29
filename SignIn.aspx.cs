using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"] != null)
            {
                txtUsername.Text = Request.Cookies["UNAME"].Value;
                txtPass.Text = Request.Cookies["UPWD"].Value;
                CheckBox1.Checked = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblUsers where Username=@username and Password=@pwd", con);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);

            cmd.Parameters.AddWithValue("@pwd", txtPass.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["UserID"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);

                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = txtUsername.Text;
                    Response.Cookies["UPWD"].Value = txtPass.Text;

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);

                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);

                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);

                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                }

                string Utype;
                Utype = dt.Rows[0][6].ToString().Trim();


                if (Utype == "Engineer")
                {
                    Session["Username"] = txtUsername.Text;
                    Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                    Session["getFullName"] = dt.Rows[0]["FullName"].ToString();
                    //Session["Mobile"] = dt.Rows[0]["Mobile"].ToString();
                    Session["LoginType"] = Utype;
                    Response.Write("<script> alert('Login Successfull'); </script>");
                    Response.Redirect("UserHome.aspx");
                    //Session["AdminType"] = null;

                }
                
                if (Utype == "Admin")
                {
                    Session["LoginType"] = Utype;
                    Session["Username"] = txtUsername.Text;
                    Session["AdminType"] = "Admin";
                    Response.Redirect("~/AdminHome.aspx");
                }
                if(Utype == "Leader")
                {
                    Session["LoginType"] = Utype;
                    Session["Username"] = txtUsername.Text;
                    Session["AdminType"] = "Leader";
                    Response.Redirect("~/LeaderHome.aspx");
                }
            }
            else
            {
                lblError.Text = "Invalid Username and password";
            }

            //Response.Write("<script> alert('Login Successfully done');  </script>");
            clr();
            con.Close();
            //lblMsg.Text = "Registration Successfully done";
            //lblMsg.ForeColor = System.Drawing.Color.Green;
        }
    }

    private void clr()
    {
        txtUsername.Text = string.Empty;
        txtPass.Text = string.Empty;
        txtUsername.Focus();
    }

    
}
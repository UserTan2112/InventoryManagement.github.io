using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddToolType : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Admin")
        {
            Response.Redirect("SignIn.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }
    }

    protected void btnAddToolType_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblToolType(ToolTypeName) Values('" + txtToolType.Text + "')", con);
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Tool Type Added successfully'); </script>");
            txtToolType.Text = string.Empty;
            con.Close();
            txtToolType.Focus();

        }
        BindBrandRepeater();
    }

    protected void rptrToolType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditToolType")
        {
            // Ignore the validator control
            Button EditToolType = (Button)e.CommandSource;
            EditToolType.CausesValidation = false;
            Response.Redirect("EditToolType.aspx");
        }
    }


    private void BindBrandRepeater()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select * from tblToolType", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrToolType.DataSource = dt;
                    rptrToolType.DataBind();
                }
            }

        }
    }
}
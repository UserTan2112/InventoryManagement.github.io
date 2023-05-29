using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class AddGroup : System.Web.UI.Page
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

    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblGroup(GroupName) VALUES (@GroupName)", con);
            cmd.Parameters.AddWithValue("@GroupName", txtGroupName.Text);
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Group Name Added successfully'); </script>");
            txtGroupName.Text = string.Empty;
            con.Close();
            txtGroupName.Focus();

        }
        BindBrandRepeater();
        clear();
    }

    private void BindBrandRepeater()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        { 
            using (SqlCommand cmd = new SqlCommand("select * from tblGroup ", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dt.Columns.Add("SequenceNumber", typeof(string));

                    // Populate the sequence numbers in the new column
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SequenceNumber"] = (i + 1);
                    }
                    rptrGroup.DataSource = dt;
                    rptrGroup.DataBind();
                }
            }

        }
    }

    protected void rptrGroup_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            // Ignore the validator control
            Button EditGroup = (Button)e.CommandSource;
            EditGroup.CausesValidation = false;
            Response.Redirect("EditGroup.aspx");
        }
    }

    

    private void clear()
    {
        txtGroupName.Text = string.Empty;
    }
}
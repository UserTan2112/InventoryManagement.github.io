using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderAddProject : System.Web.UI.Page
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
                BindProjectRepeater();
                BindUserName();
                BindBillOfMaterial();
                AddtblInventory();
            }
        }
    }

    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();

            // Insert the project details
            SqlCommand cmd = new SqlCommand("INSERT INTO tblProject(ProjectName,ProjectManager,ScenarioXiom, BillOfMaterial, Quantity,UserID,Status,Description) VALUES (@ProjectName,@ProjectManager,@ScenarioXiom, @BillOfMaterial, @Quantity, @UserID,@Status,@Description)", con);
            cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
            cmd.Parameters.AddWithValue("@ProjectManager", txtProjectManager.Text);
            cmd.Parameters.AddWithValue("@ScenarioXiom", txtScenarioXiom.Text);
            cmd.Parameters.AddWithValue("@BillOfMaterial", ddlBillOfMaterial.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@UserID", ddlUsers.SelectedValue);
            cmd.Parameters.AddWithValue("@Status", "Preparing");
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            AddtblInventory();
            Response.Write("<script> alert('Project Added successfully'); </script>");

            BindProjectRepeater();
            clear();
        }
    }

    protected void rptrProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditProject")
        {
            // Ignore the validator control
            Button EditProject = (Button)e.CommandSource;
            EditProject.CausesValidation = false;
            Response.Redirect("LeaderEditProject.aspx");
        }
    }

    private void BindProjectRepeater()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*, B.*, C.* FROM tblProject A " +
                                                   "INNER JOIN tblInventory B ON B.InventoryID = A.BillOfMaterial " +
                                                   "INNER JOIN tblUsers C ON C.UserID = A.UserID "
                                                   , con))
            {
                cmd.Parameters.AddWithValue("@UserID", Session["USERID"]);

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
                    rptrProject.DataSource = dt;
                    rptrProject.DataBind();
                }
            }
        }
    }



    private void clear()
    {
        txtProjectName.Text = string.Empty;
        txtProjectManager.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtScenarioXiom.Text = string.Empty;
        ddlBillOfMaterial.SelectedIndex = 0;
        ddlUsers.SelectedIndex = 0;
        txtDescription.Text = string.Empty;
    }

    private void AddtblInventory()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblInventory SET SellQuantity = SellQuantity + @SellQuantity WHERE InventoryID = @InventoryID", con);
            cmd.Parameters.AddWithValue("@SellQuantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@InventoryID", ddlBillOfMaterial.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }

    private void BindBillOfMaterial()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblInventory ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlBillOfMaterial.DataSource = dt;
                ddlBillOfMaterial.DataTextField = "InventoryName";
                ddlBillOfMaterial.DataValueField = "InventoryID";
                ddlBillOfMaterial.DataBind();
                ddlBillOfMaterial.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }


    private void BindUserName()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblUsers ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlUsers.DataSource = dt;
                ddlUsers.DataTextField = "Username";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }

}
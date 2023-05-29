using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderAddInventory : System.Web.UI.Page
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
                BindInventoryRepeater();
                BindToolType();
                BindGroup();
            }
        }
    }

    protected void rptrInventory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditInventory")
        {
            // Ignore the validator control
            Button EditInventory = (Button)e.CommandSource;
            EditInventory.CausesValidation = false;
            Response.Redirect("LeaderEditInventory.aspx");
        }
    }

    protected void btnAddInventory_Click(object sender, EventArgs e)
    {
        int inventoryID;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();

            // Insert into tblInventory
            SqlCommand cmd = new SqlCommand("INSERT INTO tblInventory (InventoryName, ToolTypeID, ToolGroupID, Quantity, SellQuantity) " +
                                            "VALUES (@Name, @ToolTypeID, @ToolGroupID, @Quantity, @SellQuantity); " +
                                            "SELECT SCOPE_IDENTITY()", con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
            cmd.Parameters.AddWithValue("@ToolGroupID", ddlGroup.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@SellQuantity", "0");

            // Execute the INSERT statement and retrieve the inserted InventoryID
            inventoryID = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
        }

        // Add the inventoryID to the tblPhysicalGoods table
            AddPhysicalGoods(inventoryID);

            Response.Write("<script> alert('Inventory Added successfully'); </script>");
            BindInventoryRepeater();
            clear();
    }

    private void BindInventoryRepeater()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,C.*,D.*\r\nFROM tblInventory A\r\ninner join tblToolType C on C.ToolTypeID=A.ToolTypeID inner join tblGroup D on D.GroupID=A.ToolGroupID", con))
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
                    rptrInventory.DataSource = dt;
                    rptrInventory.DataBind();
                }
            }

        }
    }

    private void clear()
    {
        txtQuantity.Text = string.Empty;
        ddlToolType.SelectedIndex = 0;
        ddlGroup.SelectedIndex = 0;
    }

    private void BindToolType()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblToolType", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlToolType.DataSource = dt;
                ddlToolType.DataTextField = "ToolTypeName";
                ddlToolType.DataValueField = "ToolTypeID";
                ddlToolType.DataBind();
                ddlToolType.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
    }

    private void BindGroup()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblGroup", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlGroup.DataSource = dt;
                ddlGroup.DataTextField = "GroupName";
                ddlGroup.DataValueField = "GroupID";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }

    private void AddPhysicalGoods(int inventoryID)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();

            // Insert into tblPhysicalGoods with the provided InventoryID
            SqlCommand cmd = new SqlCommand("INSERT INTO tblPhysicalGoods (ToolTypeID, ToolGroupID, Quantity, UsedQuantity, InventoryID) " +
                                            "VALUES (@ToolTypeID, @ToolGroupID, @Quantity, @UsedQuantity, @InventoryID)", con);

            cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
            cmd.Parameters.AddWithValue("@ToolGroupID", ddlGroup.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@UsedQuantity", "0");
            cmd.Parameters.AddWithValue("@InventoryID", inventoryID);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }


}
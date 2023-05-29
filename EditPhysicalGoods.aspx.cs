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

public partial class EditPhysicalGoods : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    string ToolType = "";
    string ToolGroup = "";
    string InvName = "";
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
                BindGridview();

            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update tblPhysicalGoods set InventoryID=@InventoryID , ToolTypeID=@ToolTypeID, ToolGroupID=@ToolGroupID where InventoryID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@InventoryID", ddlName.SelectedValue);
            cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
            cmd.Parameters.AddWithValue("@ToolGroupID", ddlToolGroup.SelectedValue);
            UpdateInventory();
            AddQuantity();
            MinusQuantity();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update successfully')</script>");
            BindGridview();
            clear();
        }
    }

   

    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblPhysicalGoods where PhysicalInvID=" + txtID.Text + "", con);
                
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Delete successfully')</script>");
                DeleteInventory();
                BindGridview();
                clear();
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong " + "')</script>");
        }
    }

    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select * from tblPhysicalGoods where PhysicalInvID=@PhysicalInvID", con);
                cmd.Parameters.AddWithValue("@PhysicalInvID", Convert.ToInt32(txtID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    InvName= ds.Tables[0].Rows[0]["inventoryID"].ToString();
                    ToolType = ds.Tables[0].Rows[0]["ToolTypeID"].ToString();
                    ToolGroup = ds.Tables[0].Rows[0]["ToolGroupID"].ToString();
                    txtStocking.Text= ds.Tables[0].Rows[0]["Stocking"].ToString();

                    BindToolType();
                    BindGroup();
                    BindInvName();
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    
                    ToolType = "";
                    ToolGroup = "";
                    InvName = "";
                }
                con.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + "Please enter the ID First" + "')</script>");
        }
    }

    private void BindGridview()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("SELECT A.PhysicalInvID, B.InventoryName,C.ToolTypeName, D.GroupName,A.Quantity,A.UsedQuantity,A.Stocking\r\nFROM tblPhysicalGoods AS A\r\n inner join tblInventory as B on B.InventoryID=A.InventoryID INNER JOIN tblToolType AS C ON C.ToolTypeID = A.ToolTypeID\r\nINNER JOIN tblGroup AS D ON D.GroupID = A.ToolGroupID;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

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
                ddlToolType.SelectedValue = ToolType;
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
                ddlToolGroup.DataSource = dt;
                ddlToolGroup.DataTextField = "GroupName";
                ddlToolGroup.DataValueField = "GroupID";
                ddlToolGroup.DataBind();
                ddlToolGroup.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlToolGroup.SelectedValue = ToolGroup;
            }
        }
    }

    private void BindInvName()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblInventory", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlName.DataSource = dt;
                ddlName.DataTextField = "InventoryName";
                ddlName.DataValueField = "InventoryID";
                ddlName.DataBind();
                ddlName.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlName.SelectedValue = InvName;
            }
        }
    }

    private void UpdateInventory()
    {
        
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update tblInventory set ToolTypeID=@ToolTypeID, ToolGroupID=@ToolGroupID where InventoryID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
                cmd.Parameters.AddWithValue("@ToolGroupID", ddlToolGroup.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
               
                BindGridview();
                
            }

        
    }

    private void DeleteInventory()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblInventory where InventoryID=" + ddlName.SelectedValue + "", con);
                cmd.ExecuteNonQuery();
                
                BindGridview();
                
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong " + "')</script>");
        }
    }

    private void AddQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblPhysicalGoods SET UsedQuantity = UsedQuantity + @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ddlName.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtPlus.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void MinusQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblPhysicalGoods SET UsedQuantity = UsedQuantity - @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ddlName.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtMinus.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void clear()
    {
        txtID.Text = string.Empty;
        ddlToolType.SelectedIndex = 0;
        ddlToolType.SelectedIndex = 0;
        ddlName.SelectedIndex = 0;
        txtStocking.Text = string.Empty;
        txtPlus.Text = string.Empty;
        txtMinus.Text = string.Empty;
    }


    protected void btnSelect_Click(object sender, EventArgs e)
    {
        int rowId = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        GridViewRow selectedRow = GridView1.Rows[rowId];
        string inventoryID = selectedRow.Cells[1].Text;
        txtID.Text = inventoryID;

        // Trigger the txtID_TextChanged event
        txtID_TextChanged(sender, e);
    }
}
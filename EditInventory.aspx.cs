using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class EditInventory : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    
    string ToolType = "";
    string ToolGroup = "";
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

    protected void txtID_TextChanged(object sender, EventArgs e)
    {

        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select InventoryName,ToolTypeID,ToolGroupID,Quantity from tblInventory where InventoryID=@InventoryID", con);
                cmd.Parameters.AddWithValue("@InventoryID", Convert.ToInt32(txtID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    txtName.Text = ds.Tables[0].Rows[0]["InventoryName"].ToString();
                    ToolType = ds.Tables[0].Rows[0]["ToolTypeID"].ToString();
                    ToolGroup = ds.Tables[0].Rows[0]["ToolGroupID"].ToString();
                    txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                    
                    BindToolType();
                    BindGroup();

                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    
                    ToolType = "";
                    ToolGroup = "";

                }
                con.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + "Please enter the ID First" + "')</script>");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddlToolType.SelectedIndex != 0 && ddlToolGroup.SelectedIndex != 0)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update tblInventory set InventoryName=@Name , ToolTypeID=@ToolTypeID, ToolGroupID=@ToolGroupID where InventoryID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
                cmd.Parameters.AddWithValue("@ToolGroupID", ddlToolGroup.SelectedValue);
                UpdateddlPhysicalGoods();
                AddQuantity();
                MinusQuantity();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update successfully')</script>");
                BindGridview();
                clear();
            }

        }
        else
        {
            Response.Write("<script>alert('Please fill Up All the Field')</script>");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblInventory where InventoryID=" + txtID.Text + "", con);
                DeletePhysicalGoods();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Delete successfully')</script>");
                BindGridview();
                clear();
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong " + "')</script>");
        }

    }


    private void BindGridview()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("SELECT A.InventoryID, A.InventoryName,C.ToolTypeName, D.GroupName, A.Quantity, A.SellQuantity, A.Stocking\r\nFROM tblInventory AS A\r\nINNER JOIN tblToolType AS C ON C.ToolTypeID = A.ToolTypeID\r\nINNER JOIN tblGroup AS D ON D.GroupID = A.ToolGroupID;", con);
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

    /*private void UpdatePhysicalGoods()
    {
        if (txtID.Text != string.Empty && txtQuantity.Text != string.Empty && ddlToolType.SelectedIndex != -1 && ddlToolGroup.SelectedIndex != -1)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update tblPhysicalGoods set ToolTypeID=@ToolTypeID, ToolGroupID=@ToolGroupID, Quantity=@Quantity where InventoryID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
                cmd.Parameters.AddWithValue("@ToolGroupID", ddlToolGroup.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update successfully')</script>");
                BindGridview();
                txtID.Text = string.Empty;
                ddlToolType.SelectedIndex = -1;
                ddlToolType.SelectedIndex = -1;
                txtQuantity.Text = string.Empty;
            }

        }
    }*/

    private void DeletePhysicalGoods()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblPhysicalGoods where InventoryID=" + txtID.Text + "", con);
                cmd.ExecuteNonQuery();
                BindGridview();
               
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong, maybe the project have used this Inventory " + "')</script>");
        }
    }


    private void AddPhysicalQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblPhysicalGoods SET Quantity = Quantity + @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtPlus.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void MinusPhysicalQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblPhysicalGoods SET Quantity = Quantity - @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtMinus.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void AddQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblInventory SET Quantity = Quantity + @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtPlus.Text);
            AddPhysicalQuantity();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void MinusQuantity()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblInventory SET Quantity = Quantity - @Quantity WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtMinus.Text);
            MinusPhysicalQuantity();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void UpdateddlPhysicalGoods()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("UPDATE tblPhysicalGoods SET ToolTypeID=@ToolTypeID, ToolGroupID=@ToolGroupID WHERE InventoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@ToolTypeID", ddlToolType.SelectedValue);
            cmd.Parameters.AddWithValue("@ToolGroupID", ddlToolGroup.SelectedValue);
            MinusPhysicalQuantity();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void clear()
    {
        txtID.Text = string.Empty;
        ddlToolType.SelectedIndex = 0;
        ddlToolGroup.SelectedIndex = 0;
        txtQuantity.Text = string.Empty;
        txtName.Text = string.Empty;
        txtMinus.Text = string.Empty;
        txtPlus.Text = string.Empty;
    }


    
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int selectedIndex = GridView1.SelectedIndex;
        if (selectedIndex >= 0)
        {
            GridViewRow selectedRow = GridView1.Rows[selectedIndex];
            string inventoryID = selectedRow.Cells[0].Text;
            txtID.Text = inventoryID;

        }
            
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int rowId = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        GridViewRow selectedRow = GridView1.Rows[rowId];
        string inventoryID = selectedRow.Cells[1].Text;
        txtID.Text = inventoryID;

        // Trigger the txtID_TextChanged event
        txtID_TextChanged(sender, e);
    }
}
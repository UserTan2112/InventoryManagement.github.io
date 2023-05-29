using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class EditGroup : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select GroupName from tblGroup where GroupID=@GroupID", con);
                cmd.Parameters.AddWithValue("@GroupID", Convert.ToInt32(txtID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    txtUpdate.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();

                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    txtUpdate.Text = string.Empty;
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
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update tblGroup set GroupName=@GroupName where GroupID=@GroupID", con);
            cmd.Parameters.AddWithValue("@GroupID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@GroupName", txtUpdate.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update successfully')</script>");
            BindGridview();
            txtID.Text = string.Empty;
            txtUpdate.Text = string.Empty;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblGroup where GroupID=" + txtID.Text + "", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Delete successfully')</script>");
                BindGridview();
                txtID.Text = string.Empty;
                txtUpdate.Text = string.Empty;
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong, maybe the Project or Inventory have used this Group of tools " + "')</script>");
        }
    }

    private void BindGridview()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select GroupID,GroupName from tblGroup", con);
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


    protected void btnselect_Click(object sender, EventArgs e)
    {
        int rowId = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        GridViewRow selectedRow = GridView1.Rows[rowId];
        string inventoryID = selectedRow.Cells[1].Text;
        txtID.Text = inventoryID;

        // Trigger the txtID_TextChanged event
        txtID_TextChanged(sender, e);
    }
}
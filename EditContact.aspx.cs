using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel.Protocols.WSTrust;

public partial class EditContact : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    string Status = "";
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

    private void BindGridview()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select * from tblContact", con);
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


    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT Name, Email, Question, MobileNumber, CONVERT(VARCHAR(10), Date, 101) AS Date, Status FROM tblContact WHERE contactID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdateContact.Enabled = true;
                    btnDeleteContact.Enabled = true;
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtQuestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
             
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    

                }
                else
                {
                    btnUpdateContact.Enabled = false;
                    btnDeleteContact.Enabled = false;
                    txtName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtQuestion.Text = string.Empty;
                    txtMobile.Text = string.Empty;
                    txtDate.Text = string.Empty;

                }
                con.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + "Please enter the ID first" + "')</script>");
        }
    }

    protected void btnUpdateContact_Click(object sender, EventArgs e)
    {
        if(ddlStatus.SelectedIndex != 0)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update tblContact set Status=@Status where contactID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update successfully')</script>");
                BindGridview();
                Clear();
            }
        }
        else
        {
            Response.Write("<script>alert('Please fill up all the field')</script>");
        }
    }

    protected void btnDeleteContact_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblContact where contactID=" + txtID.Text + "", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Delete successfully')</script>");
                BindGridview();
                Clear();
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong" + "')</script>");
        }
    }

    private void Clear()
    {
        txtID.Text = string.Empty;
        txtDate.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtName.Text = string.Empty;
        txtQuestion.Text = string.Empty;
        ddlStatus.SelectedIndex=0;
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUsers : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString;
    string UserType = "";
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
            SqlCommand cmd = new SqlCommand("update tblUsers set Username=@Username , Password=@Password, FullName=@FullName, MobileNumber=@MobileNumber, Email=@Email, UserType=@UserType where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@Username", txtUpdate.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", txtMobile.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@UserType", ddlUserType.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update successfully')</script>");
            BindGridview();
            clear();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblUsers where UserID=" + txtID.Text + "", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Delete successfully')</script>");
                BindGridview();
                clear();
            }
        }
        catch
        {
            Response.Write("<script>alert('" + "Something went wrong" + "')</script>");
        }
    }

    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select Username,Password,FullName,MobileNumber,Email,UserType from tblUsers where UserID=@UserID", con);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(txtID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    txtUpdate.Text = ds.Tables[0].Rows[0]["Username"].ToString();
                    txtPass.Text= ds.Tables[0].Rows[0]["Password"].ToString();
                    txtFullName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    UserType= ds.Tables[0].Rows[0]["UserType"].ToString();
                    ddlUserType.SelectedValue = UserType;
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
            Response.Write("<script>alert('" + "Please enter the ID first" + "')</script>");
        }
    }

    private void BindGridview()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select * from tblUsers", con);
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

    private void clear()
    {
        ddlUserType.SelectedIndex=0;
        txtID.Text = string.Empty;
        txtUpdate.Text= string.Empty;
        txtPass.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtEmail.Text = string.Empty;
        
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
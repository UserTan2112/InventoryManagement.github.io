using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderInventoryReport : System.Web.UI.Page
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
                BindGridview();

            }
        }
    }

    private void BindGridview()
    {

        SqlConnection con = new SqlConnection(CS);
        string qr = "SELECT A.InventoryID, A.InventoryName,C.ToolTypeName, D.GroupName, A.Quantity, A.SellQuantity, A.Stocking\r\nFROM tblInventory AS A\r\nINNER JOIN tblToolType AS C ON C.ToolTypeID = A.ToolTypeID\r\nINNER JOIN tblGroup AS D ON D.GroupID = A.ToolGroupID";
        SqlCommand cmd = new SqlCommand(qr, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

}
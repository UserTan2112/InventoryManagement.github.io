using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhysicalGoodsReport : System.Web.UI.Page
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
                bindGrid1();

            }
        }
    }

    private void bindGrid1()
    {

        SqlConnection con = new SqlConnection(CS);
        string qr = "SELECT A.PhysicalInvID, B.InventoryName,C.ToolTypeName, D.GroupName,A.Quantity,A.UsedQuantity,A.Stocking\r\nFROM tblPhysicalGoods AS A\r\n inner join tblInventory as B on B.InventoryID=A.InventoryID INNER JOIN tblToolType AS C ON C.ToolTypeID = A.ToolTypeID\r\nINNER JOIN tblGroup AS D ON D.GroupID = A.ToolGroupID";
        SqlCommand cmd = new SqlCommand(qr, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

}
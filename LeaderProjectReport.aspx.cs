using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderProjectReport : System.Web.UI.Page
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
                bindGrid1();

            }
        }
    }

    private void bindGrid1()
    {

        SqlConnection con = new SqlConnection(CS);
        string qr = "SELECT TOP (1000) p.[ProjectID], p.[ProjectName], p.[ProjectManager], p.[ScenarioXiom], i.[InventoryName] AS [BillOfMaterial], p.[Quantity], p.[Status] FROM [Project_A].[dbo].[tblProject] p JOIN [Project_A].[dbo].[tblInventory] i ON p.[BillOfMaterial] = i.[InventoryID] where UserID=@UserID"; SqlCommand cmd = new SqlCommand(qr, con);
        cmd.Parameters.AddWithValue("@UserID", Session["USERID"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

}
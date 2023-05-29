using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Admin")
        {
            Response.Redirect("SignIn.aspx");
        }
    }

    protected void btnAdminlogout_Click1(object sender, EventArgs e)
    {
        Session["LoginType"] = null;
        Response.Redirect("~/SignIn.aspx");
        
    }
}

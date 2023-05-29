using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeaderMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginType"] == null || Session["LoginType"].ToString() != "Leader")
        {
            btnlogout.Visible = false;
            Response.Redirect("~/SignIn.aspx");
        }
        else
        {
            btnlogout.Visible = true;
            Button1.Text = "Welcome: " + Session["Username"].ToString().ToUpper();
        }
    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["LoginType"] = null;
        Response.Redirect("SignIn.aspx");
    }
}

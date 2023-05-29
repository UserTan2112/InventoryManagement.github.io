using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testing : System.Web.UI.Page
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

                BindProjectRepeater();
                
                BindBillOfMaterial();
                AddtblInventory();
                BindUserName();
            }
        }
    }

    protected void rptrProject_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditProject")
        {
            // Ignore the validator control
            Button EditProject = (Button)e.CommandSource;
            EditProject.CausesValidation = false;
            Response.Redirect("EditProject.aspx");
        }
    }

    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();

            // Insert the project details
            SqlCommand cmd = new SqlCommand("INSERT INTO tblProject(ProjectName, ProjectManager, ScenarioXiom, UserID, Status, Description) VALUES (@ProjectName, @ProjectManager, @ScenarioXiom, @UserID, @Status, @Description)", con);
            cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
            cmd.Parameters.AddWithValue("@ProjectManager", txtProjectManager.Text);
            cmd.Parameters.AddWithValue("@ScenarioXiom", txtScenarioXiom.Text);
            cmd.Parameters.AddWithValue("@UserID", ddlUsers.SelectedValue);
            cmd.Parameters.AddWithValue("@Status", "Preparing");
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.ExecuteNonQuery(); // Insert the project details

            /*int projectId;
            using (SqlCommand cmdGetProjectId = new SqlCommand("SELECT SCOPE_IDENTITY()", con))
            {
                projectId = Convert.ToInt32(cmdGetProjectId.ExecuteScalar());
            }*/

            // Insert the selected bill of material with their corresponding quantities
            foreach (ListItem item in ckBillOfMaterial.Items)
            {
                if (item.Selected)
                {
                    TextBox txtQuantity = quantityPlaceHolder.FindControl("txtQuantity_" + item.Value) as TextBox;
                    if (txtQuantity != null && !string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        int quantity;
                        if (int.TryParse(txtQuantity.Text, out quantity))
                        {
                            // Insert the quantity for the current item
                            SqlCommand cmdBillOfMaterial = new SqlCommand("INSERT INTO tblProject( BillOfMaterialID, Quantity) VALUES (@ProjectID, @BillOfMaterialID, @Quantity)", con);
                            
                            cmdBillOfMaterial.Parameters.AddWithValue("@BillOfMaterialID", item.Value);
                            cmdBillOfMaterial.Parameters.AddWithValue("@Quantity", quantity);
                            cmdBillOfMaterial.ExecuteNonQuery();
                        }
                        else
                        {
                            // Handle invalid quantity input
                            // You can show an error message or take appropriate action here
                        }
                    }
                }
            }

            con.Close();
            Response.Write("<script> alert('Project Added successfully'); </script>");

            BindProjectRepeater();
            clear();
        }

    }


    private void BindProjectRepeater()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.* from tblProject A inner join tblInventory B on B.InventoryID=A.BillOfMaterial inner join tblUsers C on C.UserID=A.UserID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Add an additional column to store the sequence numbers
                    dt.Columns.Add("SequenceNumber", typeof(string));

                    // Populate the sequence numbers in the new column
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SequenceNumber"] = (i + 1);
                    }

                    rptrProject.DataSource = dt;
                    rptrProject.DataBind();
                }
            }
        }
    }



    private void clear()
    {
        txtProjectName.Text = string.Empty;
        txtProjectManager.Text = string.Empty;
        //txtQuantity.Text = string.Empty;
        txtScenarioXiom.Text = string.Empty;
        
    }

    private void AddtblInventory()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
        {
            con.Open();

            // Update the SellQuantity for selected items in the CheckBoxList
            foreach (ListItem listItem in ckBillOfMaterial.Items)
            {
                if (listItem.Selected)
                {
                    TextBox txtQuantity = quantityPlaceHolder.FindControl("txtQuantity_" + listItem.Value) as TextBox;
                    if (txtQuantity != null && !string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        int sellQuantity = Convert.ToInt32(txtQuantity.Text);
                        SqlCommand cmdUpdateQuantity = new SqlCommand("UPDATE tblInventory SET SellQuantity = SellQuantity + @SellQuantity WHERE InventoryID = @InventoryID", con);
                        cmdUpdateQuantity.Parameters.AddWithValue("@SellQuantity", sellQuantity);
                        cmdUpdateQuantity.Parameters.AddWithValue("@InventoryID", listItem.Value);
                        cmdUpdateQuantity.ExecuteNonQuery();
                    }
                }
            }

            con.Close();
        }
    }

    private void BindBillOfMaterial()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("SELECT InventoryID, InventoryName FROM tblInventory", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ckBillOfMaterial.Items.Clear(); // Clear the existing items before populating
                ckBillOfMaterial.DataSource = dt;
                ckBillOfMaterial.DataTextField = "InventoryName";
                ckBillOfMaterial.DataValueField = "InventoryID";
                ckBillOfMaterial.DataBind();
            }
        }
    }

    private void BindUserName()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Select * from tblUsers ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count != 0)
            {
                ddlUsers.DataSource = dt;
                ddlUsers.DataTextField = "Username";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }


    protected void ckBillOfMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenerateQuantityTextBoxes();
    }

    private void GenerateQuantityTextBoxes()
    {
        quantityPlaceHolder.Controls.Clear(); // Clear any existing textboxes

        foreach (ListItem item in ckBillOfMaterial.Items)
        {
            if (item.Selected)
            {
                TextBox txtQuantity = new TextBox();
                txtQuantity.ID = "txtQuantity_" + item.Value;
                txtQuantity.CssClass = "form-control";
                quantityPlaceHolder.Controls.Add(txtQuantity);

                Console.Write("test ID:"+txtQuantity.ID + "   " + txtQuantity.Text);
            }
        }
    }

}
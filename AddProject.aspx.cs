using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testing2 : System.Web.UI.Page
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
                BindGridView();
                //BindBillOfMaterial();
                //AddtblInventory();
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
        
        txtDescription.Text = string.Empty;
    }

    private void AddtblInventory()
    {
        try
        {
            foreach (GridViewRow row in gridViewProjects.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                    if (txtQuantity != null && !string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        int sellQuantity;
                        if (int.TryParse(txtQuantity.Text, out sellQuantity))
                        {
                            int inventoryID = Convert.ToInt32(row.Cells[1].Text);

                            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project_A"].ConnectionString))
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand("UPDATE tblInventory SET SellQuantity = SellQuantity + @SellQuantity WHERE InventoryID = @InventoryID", con);
                                cmd.Parameters.AddWithValue("@SellQuantity", sellQuantity);
                                cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else
                        {
                            // Invalid sell quantity value entered
                            Response.Write("<script> alert('Invalid sell quantity value entered. Please enter a valid integer value.'); </script>");
                            return;
                        }
                    }
                }
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        


    }

    

    private void BindGridView()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            //string query = "SELECT InventoryID, InventoryName FROM tblInventory";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT InventoryID, InventoryName FROM tblInventory";
            cmd.Connection = con;
            SqlDataReader da = cmd.ExecuteReader();
            gridViewProjects.DataSource = da;
            gridViewProjects.DataBind();
            con.Close();
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






    protected void btnAddProject_Click1(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                // Insert the project details
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProject(ProjectName, ProjectManager, ScenarioXiom, BillOfMaterial, Quantity, UserID, Status, Description) VALUES (@ProjectName, @ProjectManager, @ScenarioXiom, @BillOfMaterial, @Quantity, @UserID, @Status, @Description)", con);
                cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                cmd.Parameters.AddWithValue("@ProjectManager", txtProjectManager.Text);
                cmd.Parameters.AddWithValue("@ScenarioXiom", txtScenarioXiom.Text);
                cmd.Parameters.AddWithValue("@UserID", ddlUsers.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", "Preparing");
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                bool isAnyItemSelected = false; // Flag variable to track if at least one checkbox is selected

                foreach (GridViewRow row in gridViewProjects.Rows)
                {
                    CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                        if (txtQuantity != null && !string.IsNullOrEmpty(txtQuantity.Text))
                        {
                            int quantity;
                            if (int.TryParse(txtQuantity.Text, out quantity))
                            {
                                // Get the inventory ID from the BoundField column
                                int inventoryID = Convert.ToInt32(row.Cells[1].Text);

                                // Set the @BillOfMaterial and @Quantity parameters
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                                cmd.Parameters.AddWithValue("@ProjectManager", txtProjectManager.Text);
                                cmd.Parameters.AddWithValue("@ScenarioXiom", txtScenarioXiom.Text);
                                cmd.Parameters.AddWithValue("@BillOfMaterial", inventoryID);
                                cmd.Parameters.AddWithValue("@Quantity", quantity);
                                cmd.Parameters.AddWithValue("@UserID", ddlUsers.SelectedValue);
                                cmd.Parameters.AddWithValue("@Status", "Preparing");
                                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                                cmd.ExecuteNonQuery();

                                // At least one checkbox is selected
                                isAnyItemSelected = true;
                            }
                            else
                            {
                                // Invalid quantity value entered
                                Response.Write("<script> alert('Invalid quantity value entered for " + row.Cells[2].Text + ". Please enter a valid integer value.'); </script>");
                                return;
                            }
                        }
                    }
                }

                if (!isAnyItemSelected)
                {
                    Response.Write("<script> alert('Please select at least one checkbox.'); </script>");
                }
                else
                {
                    Response.Write("<script> alert('Project(s) added successfully.'); </script>");
                    AddtblInventory();
                }

                con.Close();

                BindProjectRepeater();
                clear();
            }
        }
        catch (Exception ex)
        {
            // Handle the exception and display a more detailed error message
            string errorMessage = "An error occurred while adding the project: " + ex.Message;
            if (ex.InnerException != null)
            {
                errorMessage += " Inner Exception: " + ex.InnerException.Message;
            }
            Response.Write("<script> alert('" + errorMessage + "'); </script>");
        }
    }




    }
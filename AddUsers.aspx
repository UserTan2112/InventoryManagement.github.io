<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddUsers.aspx.cs" Inherits="AddUsers" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style>
        body{
  /* Safari 4-5, Chrome 1-9 */
    background: -webkit-gradient(radial, center center, 0, center center, 460, from(#1a82f7), to(#2F2727));

  /* Safari 5.1+, Chrome 10+ */
    background: -webkit-radial-gradient(circle, #1a82f7, #2F2727);

  /* Firefox 3.6+ */
    background: -moz-radial-gradient(circle, #1a82f7, #2F2727);

  /* IE 10 */
    background: -ms-radial-gradient(circle, #1a82f7, #2F2727);
    height:600px;
}

.centered-form{
	margin-top: 60px;
}

.centered-form .panel{
	background: rgba(255, 255, 255, 0.8);
	box-shadow: rgba(0, 0, 0, 0.3) 20px 20px 20px;
}

label.label-floatlabel {
    font-weight: bold;
    color: #46b8da;
    font-size: 11px;
}
        </style>
    
        <div>
         <!--signup page-->
        <div class="container">
        <div class="row centered-form">
        <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
        	<div class="panel panel-default">
        		<div class="panel-heading">
			    		<h3 class="panel-title">................ <small>.........</small></h3>
			 			</div>
			 			<div class="panel-body">
			    		<form role="form">
			    				
			    					<div class="form-group">
			                <label class="form-control">Username:</label>
                                        <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the UserName" ForeColor="Red" ControlToValidate="txtUname"></asp:RequiredFieldValidator>
			    					</div>
			    				

			    					<div class="form-group">
			    						<label class="form-control">Password:</label>
	                                    <asp:TextBox ID="txtPass" runat="server" Textmode="Password" Class="form-control" placeholder="Enter Your Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Password" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
			    				</div>
			    			
			    			<div class="form-group">
			    				<label class="form-control">Confirm Password:</label>
                                <asp:TextBox ID="txtCPass" runat="server" Textmode="Password" Class="form-control" placeholder="Enter Your Confirm Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Conform Password" ForeColor="Red" ControlToValidate="txtCPass"></asp:RequiredFieldValidator>
			    			</div>

			    					<div class="form-group">
			    						<label class="form-control">Your Full Name:</label>
                                        <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Name" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
			    					</div>
			    				
			    					<div class="form-group">
			    						<label class="form-control">Email:</label>
                                        <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Email" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
			    					</div>

                            <div class="form-group">
                                <label class="form-control">MobileNumber:</label>
                                <asp:TextBox ID="txtMobile" runat="server" Class="form-control" placeholder="Enter Your Mobile Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Mobile Number" ForeColor="Red" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label class="form-control">UserType</label>
                                <asp:DropDownList ID="ddlUserType" runat="server" Class="form-control" >
                                    <asp:ListItem>Leader</asp:ListItem>
                                    <asp:ListItem>Engineer</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="Add" class="btn btn-success" runat="server" Text="AddUsers" OnClick="AddUsers_Click1" />
                <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                            </div>
			    		
                            

			    		</form>
			    	</div>
	    		</div>
    		</div>
    	</div>
    </div>
</div>
        <!--signup page end-->

    

</asp:Content>


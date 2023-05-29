<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" EnableEventValidation="false" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
       .content-header{
  font-family: 'Oleo Script', cursive;
  color:#fcc500;
  font-size: 45px;
}

.section-content{
  text-align: center; 
}
body {
  font-family: 'Teko', sans-serif;
  background: linear-gradient(to left, #3a6186 , #89253e);
  color: #fff;
}

#contact {
  width: 70vw;
  height: 550px;
  margin: 0 auto;
  padding-top: 60px;
}
.contact-section{
  padding-top: 40px;
}
.contact-section .col-md-6{
  width: 50%;
}

.form-line{
  border-right: 1px solid #B29999;
}

.form-group{
  margin-top: 10px;
}
label{
  font-size: 1.3em;
  line-height: 1em;
  font-weight: normal;
}
.form-control{
  font-size: 1.3em;
  color: #080808;
}
textarea.form-control {
    height: 135px;
   /* margin-top: px;*/
}

.submit{
  font-size: 1.1em;
  float: right;
  width: 150px;
  background-color: transparent;
  color: #fff;

}
		</style>
  
	<br />
	<br />
	<br />
	<br />
    <section id="contact">
		
			<div class=" content section-content">
				<h1 class="section-header">Get in <span class="content-header wow fadeIn " data-wow-delay="0.2s" data-wow-duration="2s"> Touch with us</span></h1>
				<h3>Did you face any problems?Please contact with us</h3>
			</div>
			
			<div class="contact-section">
			<div class="container">
				<form>
					<div class="col-md-6 form-line">
			  			<div class="form-group">
			  				<asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
					    	<asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtCategoryName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Name" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
				  		</div>
				  		<div class="form-group">
					    	<asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
					    	<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Email" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
					  	</div>	
					  	<div class="form-group">
					    	<asp:Label ID="Label4" runat="server" Text="Mobile Number"></asp:Label>
					    	<asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Mobile Number" ForeColor="Red" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
			  			</div>
			  		</div>
			  		<div class="col-md-6">
			  			<div class="form-group">
			  				<asp:Label ID="Label3" runat="server" Text="Question"></asp:Label>
			  			 	<asp:TextBox ID="txtQuestion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Question" ForeColor="Red" ControlToValidate="txtQuestion"></asp:RequiredFieldValidator>
			  			</div>
			  			<div>

			  				<asp:Button ID="btnSubmit" class="btn btn-default submit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
			  			</div>
			  			
					</div>
				</form>
                </div>
			</div>
			
		</section>
	
</asp:Content>


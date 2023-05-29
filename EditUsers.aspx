<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        body{
            background-image:url(https://img-qn-1.51miz.com/Element/00/71/97/24/82171f9d_E719724_66c41ea8.jpg!/quality/90/unsharp/true/compress/true/fw/450);
            background-size: cover;
  background-repeat: no-repeat;
        }
    </style>
    <br />
<br />
<br />
<br />
<div class="container">


<div class="row">
         

         <div class ="col-md-6"> 

         <div class="row">
         <div class="col-md-6">
         <div class="form-group">
                        <label>Enter ID:</label>
                        <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtID_TextChanged"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please enter the ID" ForeColor="Red" ControlToValidate="txtID"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                   
                    </div>
         </div>
         <div class="col-md-7">
         <div class="form-group">
                        <label>Enter Username:</label>
                        <asp:TextBox ID="txtUpdate" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Tool Group" ForeColor="Red" ControlToValidate="txtUpdate"></asp:RequiredFieldValidator>
                    </div>
         
             <div class="form-group">
                        <label>Enter Password:</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"  ></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Password" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                    </div>

             <div class="form-group">
                        <label>Enter Full Name:</label>
                        <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"  ></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Full Name" ForeColor="Red" ControlToValidate="txtFullName"></asp:RequiredFieldValidator>
                    </div>

             <div class="form-group">
                        <label>Enter Mobile Number:</label>
                        <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"  ></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Mobile Number" ForeColor="Red" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                    </div>

             <div class="form-group">
                        <label>Enter Email:</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Email" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </div>

             <div class="form-group">
                                <label >UserType</label>
                                <asp:DropDownList ID="ddlUserType" runat="server" Class="form-control" >
                                    <asp:ListItem>-Select-</asp:ListItem>
                                    <asp:ListItem>Leader</asp:ListItem>
                                    <asp:ListItem>Engineer</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                </asp:DropDownList>
                            </div>

          <div class="form-group">
                        <asp:Button ID="btnUpdate" CssClass ="btn btn-primary " runat="server" 
                            Text="UPDATE" OnClick="btnUpdate_Click"  />&emsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass ="btn btn-primary" OnClick="btnDelete_Click"  />
                    </div>
         </div>
        
         </div>
                    
                    

                    
                    
          </div>    
          <div class="col-md-8">
          
             <div class="row">
                <div class="col-md-12">
                <h4 class="alert-info text-center"> All Users</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid blue" CssClass="form-control" runat="server" placeholder="Search User...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr />
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                           <Columns>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:Button ID="btnSelect" runat="server" Text="select " CausesValidation="false" OnClick="btnSelect_Click"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                       </asp:GridView>
                   </div>
                </div>
             </div>
          </div>

 </div>

 </div>




 <script type="text/javascript">
     function Search_Gridview(strKey) {
         var strData = strKey.value.toLowerCase().split(" ");
         var tblData = document.getElementById("<%=GridView1.ClientID %>");
         var rowData;
         for (var i = 1; i < tblData.rows.length; i++) {
             rowData = tblData.rows[i].innerHTML;
             var styleDisplay = 'none';
             for (var j = 0; j < strData.length; j++) {
                 if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                     styleDisplay = '';
                 else {
                     styleDisplay = 'none';
                     break;
                 }
             }
             tblData.rows[i].style.display = styleDisplay;
         }
     }  
 </script>
</asp:Content>


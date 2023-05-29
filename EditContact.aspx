<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="EditContact.aspx.cs" Inherits="EditContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        body{
            background-image:url(https://img-qn-1.51miz.com/Element/00/71/97/24/82171f9d_E719724_66c41ea8.jpg!/quality/90/unsharp/true/compress/true/fw/450);
            background-size: cover;
  background-repeat: no-repeat;
        }
    </style>
    <div class="container">
  <h2></h2>  
  <br /><br /><br /><br />
    <div class="panel panel-primary">
      <div class="panel-heading">Edit Contact</div>
      <div class="panel-body">
          <div class="row">
               <div class="col-sm-6">
                  <div class="form-group">
                       <label> Enter ID:</label>
                       <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true"  ontextchanged="txtID_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the ID" ForeColor="Red" ControlToValidate="txtID"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                       <label> Enter Name </label>
                       <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Name" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                       <label> Enter Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoPostBack="true" ReadOnly="true" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Email" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                       <label> Enter Question</label>
                        <asp:TextBox ID="txtQuestion" CssClass="form-control" runat="server" AutoPostBack="true" ReadOnly="true" ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Question" ForeColor="Red" ControlToValidate="txtQuestion"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                       <label> Mobile Number</label>
                        <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" AutoPostBack="true" ReadOnly="true" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Mobile Number" ForeColor="Red" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                       <label> Date </label>
                       <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" AutoPostBack="true" ReadOnly="true" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Date" ForeColor="Red" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                  </div>

                    <div class="form-group">
                       <label> Status </label>
                        <asp:DropDownList ID="ddlStatus" CssClass ="form-control" runat="server">
                             <asp:ListItem>-Select-</asp:ListItem>
                                    <asp:ListItem>Processing</asp:ListItem>
                                    <asp:ListItem>Done</asp:ListItem>
                        </asp:DropDownList>
                        
                  </div>
                  <div class="form-group">
                  <asp:Button ID="btnUpdateContact" CssClass="btn btn-primary" runat="server" Text="UPDATE" onclick="btnUpdateContact_Click" />&emsp;<asp:Button ID="btnDeleteContact" runat="server" Text="Delete" CssClass ="btn btn-primary" OnClick="btnDeleteContact_Click" />
                  </div>

               
               </div>

               <div class="col-sm-6">

                <div class="row">
                <div class="col-md-12">
                <h4 class="alert-info text-center"> All Contact</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid blue" CssClass="form-control" runat="server" placeholder="Search Contact...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr />
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                            <Columns>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:Button ID="btnselect" runat="server" Text="select " CausesValidation="false" OnClick="btnselect_Click"/>
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
      <div class="panel-footer">Panel Footer</div>
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


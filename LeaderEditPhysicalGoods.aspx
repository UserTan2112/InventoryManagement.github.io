<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="LeaderEditPhysicalGoods.aspx.cs" Inherits="LeaderEditPhysicalGoods" %>

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

                    
         </div>
         <div class="col-md-7">
         
             <div class="form-group">
                        <label>Name</label>
                 <asp:DropDownList ID="ddlName" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

             <div class="form-group">
                        <label>Tool Type</label>
                 <asp:DropDownList ID="ddlToolType" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

             <div class="form-group">
                        <label>Tool Group</label>
                 <asp:DropDownList ID="ddlToolGroup" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

             <div class="form-group">
                        <label>Add UsedQuantity:</label>
                        <asp:TextBox ID="txtPlus" CssClass="form-control" runat="server"></asp:TextBox>
             
                    </div>

              <div class="form-group">
                        <label>Minus UsedQuantity:</label>
                        <asp:TextBox ID="txtMinus" CssClass="form-control" runat="server"></asp:TextBox>
             
                    </div>

             <div class="form-group">
                        <label>Stocking</label>
                        <asp:TextBox ID="txtStocking" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please enter the Stocking" ForeColor="Red" ControlToValidate="txtStocking"></asp:RequiredFieldValidator>
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
                <h4 class="alert-info text-center"> All Physical Goods</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid blue" CssClass="form-control" runat="server" placeholder="Search Inventory...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr />
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                           <Columns>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:Button ID="btnSelect" runat="server" Text="Select " CausesValidation="false" OnClick="btnSelect_Click"/>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddGroup.aspx.cs" Inherits="AddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        body{
            background-image:url(https://img-qn-1.51miz.com/Element/00/71/97/24/82171f9d_E719724_66c41ea8.jpg!/quality/90/unsharp/true/compress/true/fw/450);
            background-size: cover;
  background-repeat: no-repeat;
        }
    </style>

     <div class="container">
                 <div class="form-horizontal">
                     <br />
                     <br />
                     <h2>Add Group</h2>
                     <hr />
                     <div class="form-group">
                         <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="GroupName"></asp:Label>
                        <div class="col-md-3">

                            <asp:TextBox ID="txtGroupName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Group Name" ForeColor="Red" ControlToValidate="txtGroupName"></asp:RequiredFieldValidator>
                        </div>
                     </div>
      
                    

                     <div class="form-group">
                         <div class="col-md-2"></div>
                        <div class="col-md-6">

                            <asp:Button ID="btnAddGroup" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddGroup_Click" />
                            
                        </div>
                     </div>

                 </div>

        <h1>All Group</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading"> All Group</div>

            <asp:Repeater ID="rptrGroup" runat="server" OnItemCommand="rptrGroup_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                <thread>
                    <tr>
                        <th>#<</th>
                        <th>Group Name</th>
                       
                        <th>Edit</th>
                        
                    </tr>
                </thread>

                <tbody>

                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <th> <%# Eval("SequenceNumber") %> </th>
                        <td> <%# Eval("GroupName") %> </td>
                       
                        <td><asp:Button runat="server" ID="btnEditGroup" Text="Edit" CommandName="EditGroup" CommandArgument='<%# Eval("GroupID") %>' CausesValidation="false" /></td>
                        
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </tbody>

            </table>
                </FooterTemplate>
            </asp:Repeater>

            
                    
                
        </div>

             </div>

</asp:Content>


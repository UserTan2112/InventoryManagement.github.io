<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="LeaderAddInventory.aspx.cs" Inherits="LeaderAddInventory" %>

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
                     <h2>Add Inventory</h2>
                     <hr />

                     <div class="form-group">
                         <asp:Label ID="Label3" CssClass="col-md-2 control-label" runat="server" Text="Name"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Name" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                      <div class="form-group">
                         <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="ToolType"></asp:Label>
                        <div class="col-md-3">

                            <asp:DropDownList ID="ddlToolType" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="GroupName"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                     </div>


                     <div class="form-group">
                         <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Quantity"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Inventory Quantity" ForeColor="Red" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator>
                        </div>
                     </div>


                     <div class="form-group">
                         <div class="col-md-2"></div>
                        <div class="col-md-6">

                            <asp:Button ID="btnAddInventory" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddInventory_Click" />
                            
                        </div>
                     </div>

                 </div>

        <h1>Inventory</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading"> All Inventory</div>

            <asp:Repeater ID="rptrInventory" runat="server" OnItemCommand="rptrInventory_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                <thread>
                    <tr>
                        <th>#<</th>
                        <th>Name</th>
                       <th>Type</th>
                        <th>Group</th>
                        <th>Quantity</th>
                        <th>Stocking</th>
                        <th>Edit</th>
                        
                    </tr>
                </thread>

                <tbody>

                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <th> <%# Eval("SequenceNumber") %> </th>
                        <td> <%# Eval("InventoryName") %> </td>
                        <td> <%# Eval("ToolTypeName") %> </td>
                        <td> <%# Eval("GroupName") %> </td>
                        <td> <%# Eval("Quantity") %> </td>
                        <td> <%# Eval("Stocking") %> </td>
                       
                        <td><asp:Button runat="server" ID="btnEditInventory" Text="Edit" CommandName="EditInventory" CommandArgument='<%# Eval("InventoryID") %>' CausesValidation="false" /></td>
                        
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


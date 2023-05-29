<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="LeaderAddToolType.aspx.cs" Inherits="LeaderAddToolType" %>

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
                     <h2>Add ToolType</h2>
                     <hr />
                     <div class="form-group">
                         <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="ToolType"></asp:Label>
                        <div class="col-md-3">

                            <asp:TextBox ID="txtToolType" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the ToolType" ForeColor="Red" ControlToValidate="txtToolType"></asp:RequiredFieldValidator>
                        </div>
                     </div>
      
                     

                     <div class="form-group">
                         <div class="col-md-2"></div>
                        <div class="col-md-6">

                            <asp:Button ID="btnAddToolType" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddToolType_Click" />
                            
                        </div>
                     </div>

                 </div>

        <h1>ToolType</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading"> All Tool Type</div>

            <asp:Repeater ID="rptrToolType" runat="server" OnItemCommand="rptrToolType_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                <thread>
                    <tr>
                        <th>#<</th>
                        <th>ToolType</th>
                        <th>Edit</th>
                        
                    </tr>
                </thread>

                <tbody>

                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <th> <%# Eval("SequenceNumber") %> </th>
                        <td> <%# Eval("ToolTypeName") %> </td>
                        <td><asp:Button runat="server" ID="btnEditTool" Text="Edit" CommandName="EditToolType" CommandArgument='<%# Eval("ToolTypeID") %>' CausesValidation="false" /></td>
                        
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


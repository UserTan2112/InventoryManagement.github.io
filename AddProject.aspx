<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddProject.aspx.cs" Inherits="testing2" %>

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
                     <h2>Add Project</h2>
                     <hr />

                     <div class="form-group">
                         <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="ProjectName"></asp:Label>
                        <div class="col-md-3">

                            <asp:TextBox ID="txtProjectName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the ScenarioXiom" ForeColor="Red" ControlToValidate="txtScenarioXiom"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label6" CssClass="col-md-2 control-label" runat="server" Text="ProjectManager"></asp:Label>
                        <div class="col-md-3">

                            <asp:TextBox ID="txtProjectManager" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the ScenarioXiom" ForeColor="Red" ControlToValidate="txtScenarioXiom"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="ScenarioXiom"></asp:Label>
                        <div class="col-md-3">

                            <asp:TextBox ID="txtScenarioXiom" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the ScenarioXiom" ForeColor="Red" ControlToValidate="txtScenarioXiom"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     
      
                      <div class="form-group">
                         <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Bill Of Material"></asp:Label>
                        <div class="col-md-3">
                            <asp:GridView ID="gridViewProjects" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                   <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InventoryID" HeaderText="Inventory ID" />
                                    <asp:BoundField DataField="InventoryName" HeaderText="Inventory Name" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter Quantity"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                          
                          
                     </div>



                     

                     <%--<div class="form-group">
                         <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Quantity"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Quantity" ForeColor="Red" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator>
                        </div>
                     </div>--%>

                     <div class="form-group">
                         <asp:Label ID="Label7" CssClass="col-md-2 control-label" runat="server" Text="Description"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label3" CssClass="col-md-2 control-label" runat="server" Text="User"></asp:Label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                     </div>

               

                     <div class="form-group">
                         <div class="col-md-2"></div>
                        <div class="col-md-6">

                            <asp:Button ID="btnAddProject" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAddProject_Click1" />
                            
                        </div>
                     </div>

                 </div>
                         </div>

        <h1>Project</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading"> All Project</div>

            <asp:Repeater ID="rptrProject" runat="server" OnItemCommand="rptrProject_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                <thread>
                    <tr>
                        <th>#<</th>
                        <th>Project Name</th>
                        <th>Project Manager</th>
                        <th>Scanario Xiom</th>
                        <th>Bill Of Material </th>
                        <th>Quantity </th>
                        <th>Username</th>
                        <th>Edit</th>
                        
                    </tr>
                </thread>

                <tbody>

                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <th> <%# Eval("SequenceNumber") %> </th>
                        <th> <%# Eval("ProjectName") %> </th>
                        <th> <%# Eval("ProjectManager") %> </th>
                        <td> <%# Eval("ScenarioXiom") %> </td>
                        <td> <%# Eval("InventoryName") %> </td>
                        <td> <%# Eval("Quantity") %> </td>
                        <td> <%# Eval("Username") %> </td>
                        <td><asp:Button runat="server" ID="btnEditProejct" Text="Edit" CommandName="EditProject" CommandArgument='<%# Eval("ProjectID") %>' CausesValidation="false" /></td>
                        
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


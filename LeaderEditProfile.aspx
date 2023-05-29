<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="LeaderEditProfile.aspx.cs" Inherits="LeaderEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        body{
            background-image:url(https://img-qn.51miz.com/Element/00/59/16/27/0d342054_E591627_ec0e9cag.jpg!/quality/90/unsharp/true/compress/true/fwfh2/450x225/clip/450x225a0a0/gravity/center);
            background-size: cover;
  background-repeat: no-repeat;
        }
    </style>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container background">
                 <div class="form-horizontal">
                     <h2>Profile Form</h2>
                     <hr />
                     <div class="form-group">
                         <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Name"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Name" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Mobile Number"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Mobile Number" ForeColor="Red" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     <div class="form-group">
                         <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="Email"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtgmail" CssClass="form-control" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Gmail" ForeColor="Red" ControlToValidate="txtgmail"></asp:RequiredFieldValidator>
                        </div>
                     </div>

                     <div class="form-group">
                         <div class="col-md-2"></div>
                        <div class="col-md-6">

                            <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                            
                        </div>
                     </div>

                 </div>
        </div>
</asp:Content>


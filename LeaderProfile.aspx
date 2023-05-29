<%@ Page Title="" Language="C#" MasterPageFile="~/LeaderMasterPage.master" AutoEventWireup="true" CodeFile="LeaderProfile.aspx.cs" Inherits="LeaderProfile" %>

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
    <div class="container">    
                <div class="jumbotron">
                  <div class="row">
                      <div class="col-md-4 col-xs-12 col-sm-6 col-lg-4">
                          <img src="https://www.svgimages.com/svg-image/s5/man-passportsize-silhouette-icon-256x256.png" alt="stack photo" class="img">
                      </div>
                      <div class="col-md-8 col-xs-12 col-sm-6 col-lg-8">
                          <div class="container" style="border-bottom:1px solid black">
                            <asp:Label ID="lblUsername" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
                          </div>
                            <hr>
                          <ul class="container details">
                            <li><p><span class="glyphicon glyphicon-user" style="width:50px;"></span>&nbsp;<asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-earphone one" style="width:50px;"></span>&nbsp;<asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-envelope one" style="width:50px;"></span>&nbsp;<asp:Label ID="lblGmail" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-map-marker one" style="width:50px;"></span>&nbsp;<asp:Label ID="lblUserType" runat="server" Text="Label"></asp:Label></p></li>
                            
                          </ul>
                      </div>
                  </div>
                </div>
        </div>
</asp:Content>


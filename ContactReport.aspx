<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ContactReport.aspx.cs" Inherits="ContactReport" %>

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
    <div class="container">
  


    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Contact Reports</h2>  </div>
      <div class="panel-body">
          <div class="row">
             <div class="col-md-12">
                <div class="">
                    <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" BackColor="White" 
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="6" CellSpacing="5">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                
                </div>
             
             </div>
          </div>
          </div>
        </div>
        </div>
</asp:Content>


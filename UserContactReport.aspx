<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserContactReport.aspx.cs" Inherits="UserContactReport" %>

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
    <div class="container">
   
   <hr />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Contact Report</h2> </div>
      <div class="panel-body">
           <div class="col-md-12">
              <div class="form-group">
                <div class="table table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
                    <Columns>  
                        <asp:BoundField DataField="contactID" HeaderText="S.No." />  
                        <asp:BoundField DataField="Name" HeaderText="Name" />  
                        <asp:BoundField DataField="Email" HeaderText="Email" />  
                        <asp:BoundField DataField="Question" HeaderText="Question" />  
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />  
                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:d}"/>  
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        
                        
                       
                    
                        
                         </Columns> 
                    </asp:GridView>
                </div>
              
              </div>
           
           </div>
      
      
      </div>
      <div class="panel-footer">Panel Footer</div>
    </div>
    
</div>
</asp:Content>


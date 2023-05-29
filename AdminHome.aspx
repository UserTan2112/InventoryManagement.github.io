<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .btn-dblue { 
  color: #ffffff; 
  background-color: #1B23BD; 
  border-color: #000A7A; 
} 
        .btn-dred { 
  color: #ffffff; 
  background-color: #B50D2E; 
  border-color: #69021F; 
} 
        .btn-dgreen { 
  color: #ffffff; 
  background-color: #0DB548; 
  border-color: #026926; 
} 
        body{
            background-image:url(data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw0NDQcHDQ0QDQcHBw0HBwcHDQ8IDQcNIBEWFhURExMYHSggGCYlGx8fITEhJSkrLi4uFx8zODMsNygtLisBCgoKDQ0NFQ0PFysZHxkrKysrKzcrKysrKysrKysrKysrKy0rKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIARMAtwMBIgACEQEDEQH/xAAZAAEBAQEBAQAAAAAAAAAAAAAAAwIBBAf/xAAbEAEBAQEBAQEBAAAAAAAAAAAAEhEBAmHwE//EABcBAQEBAQAAAAAAAAAAAAAAAAABAwL/xAAWEQEBAQAAAAAAAAAAAAAAAAAAERL/2gAMAwEAAhEDEQA/APh+DUmKM4Y1hgM4Y3hgMY7juEgzhjUmAzhjUkgzhjUmAzhjWGAyY3jmAzhjUkoM4Y1hgM4N4A7hjckgxhjckrBjDG5JIMYY3JJBjHcakwgzjmN4SDGGNyYDGO41JIM45jckgxjstSYDOGNSSDOONyA3hjeGCsYY3hgMYY3hgMYY3hgMYY3hnAYwxvDAYwxvDAYwxvDAYwxvDAYwxTHMBjDG8MBjBvAG8Mbx2RU8Mbx3ATwxTDATwxTDATwxTHMBjDFMATwxTAE8MUxzAYx3G8ATMUwwE8dxsBjBsBrDG8+GfFGMMbwwGMMbwwGMMbwwGMMbwwGMMbkwGMMbwwGMMbwwGMMbwwGMMbwwGMMbwwGMG8AUkxSSViJy5is/CSCckqSSQTklSSSCckqSSQTklSSSCckqSSQTklSXJIMSS3JJBjDFJckgxhjcuyREpFZCCmGKS7LqIlJKskkEpJUl3CCWGKSSQTwxXHJIJ4YpJJBPDFJJIJYYtLkkEsdxSSSKnJikkkE5MUkkglgrLpBWSVZJdxylJKskkEpJVkwgjLsq98uSQTlzFcJIJySpJhBOXJWkkEpJUkkEpJVkwglJKuEkEpJVkwglIrIQWkni8kOoiE8JXgkiISSvBJBCSFoIIIySvBJB55dhaCQRkni0EAjhK0kgjJK0EAjJK0kgjJK0kEEZFpAXgheXYdI88ELySQqEELySCMOQvJJBCSF++SSCEn815JWCEErySQqEELyc8kEJJX75JIISQvJJBCCF5JIV54HokILwQ9EEKjzwQ9EEA88EPRBAPP3wS9EEA88kPRBAPPJL0QQDzwQ9EEA88EPRBAPPBD0QQDzwQ9EEA88EPRBAPPA9EAlXl2F5JFQgheSQQgheSQQgheCREIch6JJB54JXh2QeeSV4IBCSV4IBCCF4JBCSF4IBCCF4IBCReHQXglaXYSuohLkPRBJSISSvLklIhJK8EFIjJK0OyUjzySvJBSIy5K8kBEJJXkkIhJK8khEJdlaCAiEErwQEQl1aQpF5JWkllXcRklaSSkQkheSSkQgheSSkQgheSSkQkheCFpEZcheCCkQgleCDREJJWkk0RGSV4JNEeeXZWkk0RGXF4DRF5JWkljWsRklaSSkRklaSSkRklaSFqRGSVpJKRGSFpJKRGSVpJNER75JWkk0RGSFpJKRGCFpJKRCSV5JNEQl1aQ0RaSVpJY6aRGSVpJNERklaSTREZJWkk0RGSVpMNERklaTDREJJXkk0RCXZWlyTREZJWkk0RGSVpJNERklaSSkQkXkNEWklWSWOmsSklWSSpEpJVkk0RGSVpJNERkxbDDREZJWn4Z+00RHCVsck0RKTFZJNESklWSTREpJVkw0RKTFZJNESl1SXDSRbDHRm0c7wwAMABwwAdxzHQHOmOgOYY6A5hjoDgCgADjuOiIyAD//Z);
            background-size: 100%; /* adjust to your desired size */
  background-repeat: no-repeat;
        }

        h2{
            color:white
        }
    </style>
    <br />
    <br />
    <br />
    <br />
    <h2 font-color="#fff">Welcome Admin !</h2>
    <div class="container ">
<section>
	<div class="row">
		<div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><span class="glyphicon glyphicon-thumbs-up"></span> Admin Dashboard Buttons</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h1>Add Function</h1>
                          <!-- dblue -->
                          <a href="AddUsers.aspx" class="btn btn-dblue btn-lg" role="button"><span class="glyphicon glyphicon-plus green"></span><br />Add<br />Users</a>
                          <a href="AddToolType.aspx" class="btn btn-dblue btn-lg" role="button"><span class="glyphicon glyphicon-plus green"></span><br />Add<br />Tool Type</a>
                          <a href="AddGroup.aspx" class="btn btn-dblue btn-lg" role="button"><span class="glyphicon glyphicon-plus green"></span><br />Add<br />Group</a>
                          <a href="AddInventory.aspx" class="btn btn-dblue btn-lg" role="button"><span class="glyphicon glyphicon-plus green"></span><br />Add<br />Inventory</a>
                          <a href="AddProject.aspx" class="btn btn-dblue btn-lg" role="button"><span class="glyphicon glyphicon-plus green"></span><br />Add<br />Project</a>
                        </div>
                        </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <h1>Edit Function</h1>
                          <!-- dred -->
                          <a href="EditToolType.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Tool Type</a>
                          <a href="EditGroup.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Group</a>
                          <a href="EditInventory.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Inventory</a>
                          <a href="EditPhysicalGoods.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Physical Goods</a>
                          <a href="EditProject.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />project</a>
                          <a href="EditUsers.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Users</a>
                          <a href="EditContact.aspx" class="btn btn-dred btn-lg" role="button"><span class="glyphicon glyphicon-cog glyphsize yellow"></span><br />Edit<br />Contact</a>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <h1>Report</h1>
                          <!-- green -->
                          <a href="UserReport.aspx" class="btn btn-dgreen btn-lg" role="button"><span class="glyphicon glyphicon-calendar glyphsize"></span><br />View<br />Users Report</a>
                          <a href="InventoryReport.aspx" class="btn btn-dgreen btn-lg" role="button"><span class="glyphicon glyphicon-calendar glyphsize"></span><br />View<br />Inventory Report</a>
                          <a href="PhysicalGoodsReport.aspx" class="btn btn-dgreen btn-lg" role="button"><span class="glyphicon glyphicon-calendar glyphsize"></span><br />View<br />Physical Goods Report</a>
                          <a href="ContactReport.aspx" class="btn btn-dgreen btn-lg" role="button"><span class="glyphicon glyphicon-calendar glyphsize"></span><br />View<br />Contact Report</a>
                          </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


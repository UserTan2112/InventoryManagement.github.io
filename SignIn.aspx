<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/Custome.css" rel="stylesheet" />

  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .main{margin-top:70px;
-webkit-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
-moz-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
padding:0px;
}
.fb:focus, .fb:hover{color:FFF !important;}
body{
background-image:url(https://cdn.vectorstock.com/i/1000x1000/02/10/infographics-background-e-commerce-vector-22580210.webp);
font-family: 'Raleway', sans-serif;
}

.left-side{
	padding:0px 0px 100px;
	background:#9100ff;
	background-size:cover;
}
.left-side h1{
	font-size: 70px;
    font-weight: 900;
	color:#FFF;
	padding: 50px 10px 00px 26px;
	}
	
	.left-side p{
    font-weight:600;
	color:#FFF;
	padding:10px 10px 10px 26px;
	font-size: 24px;
	}

	
	
	
	.right-side{
	padding:30px 0px 100px;
	background:#FFF;
	background-size:cover;
	min-height:514px;
}
	.right-side h1{
	font-size: 100px;
    font-weight: 700;
	color:#000;
	padding: 50px 10px 00px 50px;
	}
	.right-side p{
    font-weight:600;
	color:#000;
	padding:10px 50px 10px 50px;
	font-size: 30px;
	}
	.form{padding:10px 50px 10px 50px;}
    .form-control{box-shadow: none !important;
    border-radius: 0px !important;
    border-bottom: 1px solid #9100ff !important;
    border-top: none !important;
    border-left: none !important;
    border-right: none !important;}
        .btn-deep-purple {
            background: #84d14e;
            border-radius: 18px;
            padding: 5px 19px;
            color: #FFF;
            font-weight: 600;
            float: right;
            -webkit-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
            -moz-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
            box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.24);
        }
 .footer
        {
            background: #152F4F;
            color: white;
        
  .links{
    ul {list-style-type: none;}
    li a{
      color: white;
      transition: color .2s;
      &:hover{
        text-decoration:none;
        color:#4180CB;
        }
    }
  }  
  .about-company{
    i{font-size: 25px;}
    a{
      color:white;
      transition: color .2s;
      &:hover{color:#4180CB}
    }
  } 
  .location{
    i{font-size: 18px;}
  }
  .copyright p{border-top:1px solid rgba(255,255,255,.1);} 
}

        .background{
            background-color:#33475b;
        }

}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div class="navbar navbar-default navbar-fixed-top " role="navigation">
                    <div class="container">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle " data-toggle="collapse" data-target=" .navbar-collapse">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="SignIn.aspx" ><span ><img src="Icon/Company Logo.png" alt="TXH Elektronic E-commerce" height="30" /></span>Skyer Technology</a>
                        </div>
                        <div class="navbar-collapse collapse">
                            <ul class="nav navbar-nav navbar-right">
                                
                                 <li><a href="SignIn.aspx">Sign In</a></li>
                                 
                               
                            </ul>
                        </div>
                    </div>
                </div>
        </div>
            </div>

        <!-- SignIn form start-->
        <div class="container">
	    
		<div class="col-sm-8 col-sm-offset-2 main">
		<div class="col-sm-6 left-side">
		<h1>Welcome Login</h1>
		<p>Welcome to our Website! We are glad to have you here. In order to access all the exciting features and functionalities we offer, please login with your credentials. Once you've logged in, you'll be able to explore and utilize all the resources available to you.</p>
		</div><!--col-sm-6-->
		
		<div class="col-sm-6 right-side">
		<h1>Login</h1>
		<p></p>
		
<!--Form with header-->
<div class="form">


        <div class="form-group">
		    <asp:Label ID="Label1" for="txtUsername" runat="server" Text="Username" Font-Size="Large"></asp:Label>
            <br />
            <asp:TextBox ID="txtUsername"  runat="server" Height="50" Width="300" Font-Size="X-Large"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter the Username" ForeColor="Red" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
            
        </div>

        <div class="form-group">
		    <asp:Label ID="Label2" for="txtPass" runat="server" Text="Password" Font-Size="Large"></asp:Label>
            <br />
            <asp:TextBox ID="txtPass" Textmode="Password" runat="server" Height="50" Width="300" Font-Size="X-Large"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="Please Enter the Password" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
           
        </div>

    <div class="form-group">
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:Label ID="Label3" for="CheckBox1" runat="server" Text="Remember me"></asp:Label>
        
    </div>
    <div class="form-group">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" ></asp:Label>
    </div>

        <div class="text-xs-center">
            <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Login&raquo;" OnClick="Button1_Click" />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/SignUp.aspx">Sign Up</asp:HyperLink>
        </div>

    




</div>
<!--/Form with header-->

		</div><!--col-sm-6-->
		
		
        </div><!--col-sm-8-->
        
        </div><!--container-->
        <!--SignIn form end-->
    </form>

    <!--Footer Content start here-->
        
        <div class="mt-5 pt-5 pb-5 footer">
<div class="container">
  <div class="row">
    <div class="col-lg-5 col-xs-12 about-company">
      <h2>About</h2>
      <p class="pr-5 text-white-50">Skyer Technologies PLT is a R&D based company that provides multi-solutions to meet customers’ need & desire. We specialize in product development, ideal implementation, prototype manufacturing, in-house hardware & software development, full system development, CNC machining, PCB drawing & manufacturing & Uni-level research project development.
</p>
      <p><a href="#"><i class="fa fa-facebook-square mr-1"></i></a><a href="#"><i class="fa fa-linkedin-square"></i></a></p>
    </div>
    <div class="col-lg-3 col-xs-12 links">
      <h4 class="mt-lg-0 mt-sm-3">Links</h4>
        <ul class="m-0 p-0">
         
            <li>- <a href="SignIn.aspx">Sign In</a></li>
          
        </ul>
    </div>
    <div class="col-lg-4 col-xs-12 location">
      <h4 class="mt-lg-0 mt-sm-4">Location</h4>
      <p>5, Jalan Ekoperniagaan 2/4, Taman Ekoperniagaan, 81100 Johor Bahru, Johor, Malaysia.</p>
      <p class="mb-0"><i class="fa fa-phone mr-3"></i>+6011-5775 9055</p>
      <p><i class="fa fa-envelope-o mr-3"></i>justinkdb@skyertech.com</p>
    </div>
  </div>
  <div class="row mt-5">
    <div class="col copyright">
      <p class=""><small class="text-white-50">© 2019. All Rights Reserved.</small></p>
    </div>
  </div>
</div>
</div>
        

        <!--Footer Content End-->

</body>
</html>

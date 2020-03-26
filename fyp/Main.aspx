<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="fyp.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors"/>
    <meta name="generator" content="Jekyll v3.8.6"/>

    <title>Sign In</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.4/examples/sign-in/"/>

    <!-- Bootstrap core CSS -->
    <link href="/docs/4.4/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>

    <!-- Profile CSS -->
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto'/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <!-- Favicons -->
    <link rel="apple-touch-icon" href="/docs/4.4/assets/img/favicons/apple-touch-icon.png" sizes="180x180"/>
    <link rel="icon" href="/docs/4.4/assets/img/favicons/favicon-32x32.png" sizes="32x32" type="image/png"/>
    <link rel="icon" href="/docs/4.4/assets/img/favicons/favicon-16x16.png" sizes="16x16" type="image/png"/>
    <link rel="manifest" href="/docs/4.4/assets/img/favicons/manifest.json"/>
    <link rel="mask-icon" href="/docs/4.4/assets/img/favicons/safari-pinned-tab.svg" color="#563d7c"/>
    <link rel="icon" href="/docs/4.4/assets/img/favicons/favicon.ico"/>
    <meta name="msapplication-config" content="/docs/4.4/assets/img/favicons/browserconfig.xml"/>
    <meta name="theme-color" content="#563d7c"/>


    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>

    <!-- Custom styles for this template -->
    <link href="~/CSS/signin.css" rel="stylesheet"/>
    <link rel="stylesheet" href="~/bootstrap.min.css"/>

    <script src="./Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#<%= ddl1.ClientID%>").change(function () {
                ToggleDropdown();
            });
            ToggleDropdown(); // Done to ensure correct hiding/showing on page reloads due to validation errors
        });

        function ToggleDropdown() {
            if ($("#ddl1").val() == "ap") {
                $("#p").show();
                $("#ap").show();
                $("#l").hide();
                $("#m").hide();
                $("#ad").hide();
            }
            if ($("#ddl1").val() == "l") {
                $("#p").show();
                $("#ap").hide();
                $("#l").hide();
                $("#m").hide();
                $("#ad").hide();
            }
            if ($("#ddl1").val() == "m") {
                $("#p").show();
                $("#ap").hide();
                $("#l").hide();
                $("#m").hide();
                $("#ad").hide();
            }
            else if ($("#ddl1").val() == "ad") {
                $("#p").hide();
                $("#ap").hide();
                $("#l").hide();
                $("#m").hide();
                $("#ad").show();
            }
        };
    </script>
</head>
<body class="text-center" style="background-color: #cccccc">
    <form id="form1" runat="server" class="form-signin">
        <img class="mb-4" src="../\Images\assets\simnavlogo-white.png" alt="" width="100" height="100" title="simlogo" />

        <h1 class="h3 mb-3 font-weight-normal">Sign In</h1>
    
        <asp:dropdownlist ID="ddl1" runat="server" onchange="showBox" Height="40px" CssClass="form-control"> 
            <asp:listitem text="Applicant" value="ap"></asp:listitem>
            <asp:listitem text="Lecturer" value="l"></asp:listitem>
            <asp:listitem text="SIM Management" value="m"></asp:listitem>
            <asp:listitem text="Admin" value="ad"></asp:listitem>
        </asp:dropdownlist>
        <br />
        <br />

        <label for="TextBox1" class="sr-only">Email address</label>
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Email address" required="" autofocus="" CssClass="form-control"></asp:TextBox>

        <label for="TextBox2" class="sr-only">Password</label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Password" required="" CssClass="form-control"></asp:TextBox>

        <div class="checkbox mb-3">
          <label>
            <input type="checkbox" value="remember-me"/> Remember me
          </label>
        </div>       

        <asp:Button ID="Button" runat="server" OnClick="Login_Button" Text="Login" class="btn btn-lg btn-primary btn-block"/>
        <br />
        <div id="p" class="checkbox mb-3">
          <label>
            <a href="ResetPassword.aspx">Click here</a> to reset password.
          </label>
        </div>

        <div id="ap" style="padding: 35px">
            <div class="row">
                <h2>&nbsp<u>Apply To Teach</u></h2><br />
            </div>
            <br />
            <div class="row">
                <p>&nbsp<a href="Applicant/applicantregister.aspx">Click here</a> to create an account</p>
            </div>
            <div class="row">
                <p>&nbsp<a href="Jobpostviewing.aspx">Click here</a> for a list of available jobs.</p>
            </div>
        </div>       
        <div id="ad" style="padding: 35px">
            <div class="row">
                <h2>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<u>Admin</u></h2><br />
            </div>
            <br />
            <div class="row">
                <p>Your Windows Domain ID is your login ID. If you would like to change your password, please perform a password change in your windows machine.</p>
            </div>
        </div>

        <p class="mt-5 mb-3 text-muted">&copy; 2020</p>
        <hr />
    </form>   
</body>
</html>

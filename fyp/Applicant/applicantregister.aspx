<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applicantregister.aspx.cs" Inherits="fyp.Applicant.applicantregister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>

    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
       
    <!-- Profile CSS -->
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto'/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body style="background-color: #cccccc">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />

        <div class="container w3-white w3-card-4">
                    <br />
                    <div class="row">
                        <h1 class="h2">&nbsp Applicant Registration:</h1>
                    </div>
                    <br />
                    <br />
    
                    <div class="row">
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <div class="col">
                            <asp:Label ID="passwordvaliate" runat="server"></asp:Label><br /><br />

                            First Name:<br />
                            <asp:TextBox ID="TextBox1" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Last Name:<br />
                            <asp:TextBox ID="TextBox2" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Email:<br />
                            <asp:TextBox ID="TextBox3" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Password:<br />
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Date Of Birth:<br />
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" Width="155px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Gender (m or f):<br />
                            <asp:dropdownlist ID="TextBox6" runat="server" Width="130px" Height="40px" CssClass="form-control"> 
                                <asp:listitem text="Male" value="m"></asp:listitem>
                                <asp:listitem text="Female" value="f"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Contact:<br />
                            <asp:TextBox ID="TextBox7" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Upload your CV: <br />
                            <asp:FileUpload id="FileUploadControl" runat="server" />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="Button" runat="server" Text="Submit" OnClick="Register_Button" Width="150px" class="btn btn-secondary"/>
                            <asp:Button ID="Button1" runat="server" Text="Back" Width="150px" class="btn btn-secondary"/>
                       </div>
                   </div>
 
                                    <br /><br />
                                    <footer class="w3-container w3-teal w3-center w3-margin-top">
                                        <br />
                                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Images/assets/simlogo-white.PNG" Width="160px" />
                                        <br />
                                        <br />
                                    </footer>
            <br />
        </div> 

        <!-- Optional JavaScript -->
        <!-- jQuery first, then Popper.js, then Bootstrap JS -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>
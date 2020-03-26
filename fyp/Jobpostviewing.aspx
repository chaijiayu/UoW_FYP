<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobpostviewing.aspx.cs" Inherits="fyp.Jobpostviewing" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>View Jobs</title>

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content=""> 
    <link rel="icon" href="/docs/4.0/assets/img/favicons/favicon.ico">

    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/dashboard/">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
       
    <!-- Profile CSS -->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Custom styles for this Dashboard -->
    <link href="../\CSS\dashboard.css" rel="stylesheet">  
    
    <style type="text/css">
    li {
      float: left;  
    }

    li a {
      display: block;
      color: white;
      text-align: center;
      padding: 14px 16px;
      text-decoration: none;
    }

    ul {
      list-style-type: none;
      margin: 0;
      padding: 0;
      overflow: hidden;
      background-color: teal;
    }
    li a:hover {
      background-color: white;
    }
    html,body,h1,h2,h3,h4,h5,h6 {font-family: "Roboto", sans-serif}
    </style>
</head>
<body style="background-color: #cccccc">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />

        <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp View Job Postings in SIM:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Search by job name:
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:TextBox ID="tbSearch" runat="server" Width="300px" Height="40px"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" class="btn btn-secondary"/>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="postingID" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>   
                                    <asp:BoundField DataField="positionName" HeaderText="Job Name" />
                                    <asp:BoundField DataField="qualification" HeaderText="Qualification" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="status" HeaderText="Availability" />                          
                                </Columns>
                                <EmptyDataTemplate>No Jobs Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
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
    </form>

        <!-- Bootstrap core JavaScript
        ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
        <script src="../../assets/js/vendor/popper.min.js"></script>
        <script src="../../dist/js/bootstrap.min.js"></script>

        <!-- Icons -->
        <script src="https://unpkg.com/feather-icons/dist/feather.min.js"></script>
        <script>
            feather.replace()
        </script>

        <!-- jQuery first, then Popper.js, then Bootstrap JS -->
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
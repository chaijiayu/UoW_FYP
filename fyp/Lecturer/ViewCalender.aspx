<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/lecturer.Master" AutoEventWireup="true" CodeBehind="ViewCalender.aspx.cs" Inherits="fyp.Lecturer.ViewCalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp View Calendar</h1>
                    </div>
                    <br />

    <hr />  

    <body>  
        <div>  
            <p style="text-align: center">  
            <b></b>  
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Medium"  
                ForeColor="#0066FF">Lesson Time</asp:Label><br /></b>  
            </p>  
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"  
                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt"  
                ForeColor="#663399" ShowGridLines="True" OnDayRender="Calendar1_DayRender" >  
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />  
                <SelectorStyle BackColor="#FFCC66" />  
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />  
                <OtherMonthDayStyle ForeColor="#CC9966" />  
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />  
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="2px" />  
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />  
            </asp:Calendar>  
            <br />  
            <b></b>  
            <asp:Label ID="LabelAction" runat="server"></asp:Label><br />  
            </b>  
        </div>  
    </body>  

    <hr />
                    <br /><br />
                </div>
              </div>
            </main>
    <div>
        <h2>&nbsp;</h2>
    </div>
</asp:Content>

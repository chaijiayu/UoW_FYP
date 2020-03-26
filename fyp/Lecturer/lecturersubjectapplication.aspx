<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/lecturer.Master" AutoEventWireup="true" CodeBehind="lecturersubjectapplication.aspx.cs" Inherits="fyp.Lecturer.lecturersubjectapplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Subject Applications:</h1>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="subjectApplicationID" ShowHeaderWhenEmpty="True" CssClass="table">
                    <headerstyle cssclass="thead-dark"/>
                    <Columns>
                        <asp:BoundField DataField="subjectApplicationID" HeaderText="Application ID" />
                        <asp:BoundField DataField="subject_Code" HeaderText="Subject Code" />
                        <asp:BoundField DataField="subject_Name" HeaderText="Subject Name" />
                        <asp:BoundField DataField="subject_Venue" HeaderText="Venue" />
                        <asp:BoundField DataField="subject_Date" HeaderText="Subject Date" />
                        <asp:BoundField DataField="subject_StartTime" HeaderText="Subject Start Time" />
                        <asp:BoundField DataField="subject_EndTime" HeaderText="Subject End Time" />
                        <asp:BoundField DataField="university" HeaderText="University" />
                        <asp:BoundField DataField="subjectApp_status" HeaderText="Application Status" />
                        <asp:BoundField DataField="SubjectApp_submit_date" HeaderText="Application Submit Date" />
                     </Columns>
                     <EmptyDataTemplate>No Applications Available</EmptyDataTemplate> 
                 </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantapplication.aspx.cs" Inherits="fyp.Applicant.applicantapplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Job Application:</h1>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" ShowHeaderWhenEmpty="True" CssClass="table">
                    <headerstyle cssclass="thead-dark"/>
                    <Columns>
                       <asp:BoundField DataField="applicationID" HeaderText="Application ID" />
                       <asp:BoundField DataField="application_status" HeaderText="Application Status" />
                       <asp:BoundField DataField="submit_date" HeaderText="Application Submit Date" />
                    </Columns>
                    <EmptyDataTemplate>No Applications Available</EmptyDataTemplate> 
                </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>

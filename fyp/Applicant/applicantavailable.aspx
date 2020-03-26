<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantavailable.aspx.cs" Inherits="fyp.Applicant.applicantavailable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Jobs Available:</h1>
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="postingID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True" CssClass="table">
                        <headerstyle cssclass="thead-dark"/>
                        <Columns>
                            <asp:BoundField DataField="postingID" HeaderText="Posting ID" />
                            <asp:BoundField DataField="jobID" HeaderText="Job ID" />
                            <asp:BoundField DataField="positionName" HeaderText="Job Name" />
                            <asp:BoundField DataField="qualification" HeaderText="Qualification" />
                            <asp:BoundField DataField="description" HeaderText="Description" />
                            <asp:BoundField DataField="status" HeaderText="Availability" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="deletebtn" runat="server" CommandName="Select"
                                                class="btn btn-warning" Text="Apply" OnClientClick="return confirm('Do you want to apply to teach this job?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Jobs Available</EmptyDataTemplate> 
                 </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>

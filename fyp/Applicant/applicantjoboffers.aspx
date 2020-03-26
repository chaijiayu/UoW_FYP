<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantjoboffers.aspx.cs" Inherits="fyp.Applicant.applicantjoboffers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Job Offers:</h1>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" OnRowCommand="OnRowCommand" ShowHeaderWhenEmpty="True" CssClass="table">
                    <headerstyle cssclass="thead-dark"/>
                    <Columns>
                        <asp:BoundField DataField="applicationID" HeaderText="Application ID" />
                        <asp:BoundField DataField="jobID" HeaderText="Job ID" />
                        <asp:BoundField DataField="positionName" HeaderText="Job Name" />
                        <asp:BoundField DataField="submit_date" HeaderText="Application date" />    
                        <asp:BoundField DataField="application_status" HeaderText="Application Status" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="approvebtn" runat="server" CommandName="Approve"
                                            class="btn btn-secondary" Text="Accept" OnClientClick="return confirm('Do you want to accept this job offer?');" />
                                <asp:Button ID="rejectbtn" runat="server" CommandName="Reject"
                                            class="btn btn-secondary" Text="Reject" OnClientClick="return confirm('Do you want to reject this job offer?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Offers Available</EmptyDataTemplate> 
                </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>

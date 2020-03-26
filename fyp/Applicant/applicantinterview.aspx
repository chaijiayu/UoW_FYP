<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantinterview.aspx.cs" Inherits="fyp.Applicant.applicantinterview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Interview Schedule:</h1>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" ShowHeaderWhenEmpty="True" CssClass="table">
                    <headerstyle cssclass="thead-dark"/>
                    <Columns>    
                        <asp:TemplateField HeaderText="Interview Date" >
                            <ItemTemplate>
                                <asp:Label ID="lblintvDate" runat="server" Text='<%# Eval("interviewDate", "{0:dd/M/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtintvDate" runat="server" Text='<%# Eval("interviewDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="interviewVenue" HeaderText="Interview Venue" />
                        <asp:BoundField DataField="startTime" HeaderText="Time" />               
                    </Columns>
                    <EmptyDataTemplate>No Interviews Available</EmptyDataTemplate> 
                </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>
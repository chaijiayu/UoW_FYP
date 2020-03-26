<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtinterview.aspx.cs" Inherits="fyp.SIM.mgmtinterview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Interview Applicants:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" OnRowCommand="Gridview1_RowCommand" OnSelectedIndexChanged="OnRowSelected" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>
                                    <asp:BoundField DataField="applicationID" HeaderText="Application ID" />
                                    <asp:BoundField DataField="applicantID" HeaderText="Applicant ID" />
                                    <asp:BoundField DataField="jobID" HeaderText="Job ID" />
                                    <asp:BoundField DataField="positionName" HeaderText="Job Name" />
                                    <asp:BoundField DataField="submit_date" HeaderText="Application date" />
                                    <asp:BoundField DataField="fName" HeaderText="First Name" />
                                    <asp:BoundField DataField="lName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                    <asp:BoundField DataField="contact" HeaderText="Contact" /> 
                                    <asp:TemplateField HeaderText="Resume">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCV" runat="server" 
                                            Text='<%# Eval("CVName") %>'
                                            CommandName="CVDownload" 
                                            CommandArgument='<%#Bind("CVName") %>'>
                                    </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="interviewbtn" runat="server" CommandName="Select" 
                                                        class="btn btn-warning" Text="Interview" OnClientClick="return confirm('Do you want to schedule an interview with this applicant?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Interviews Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="adminconvert.aspx.cs" Inherits="fyp.Admin.adminconvert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1></h1>
    <div>
        <h1>&nbsp;</h1>
    </div>

    <hr />

    <div>
        
    </div>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Convert Applicant Accounts:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" OnSelectedIndexChanged="OnRowSelected" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>   
                                    <asp:BoundField DataField="applicantID" HeaderText="Applicant ID" />
                                    <asp:BoundField DataField="userID" HeaderText="User ID" />
                                    <asp:BoundField DataField="jobID" HeaderText="Job ID" />
                                    <asp:BoundField DataField="positionName" HeaderText="Job Name" />
                                    <asp:BoundField DataField="submit_date" HeaderText="Application Date" />    
                                    <asp:BoundField DataField="fName" HeaderText="First Name" />
                                    <asp:BoundField DataField="lName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                    <asp:BoundField DataField="contact" HeaderText="Contact" />        
                                    <asp:BoundField DataField="application_status" HeaderText="Application Status" />     
                                    <asp:BoundField DataField="response" HeaderText="Applicant Response" /> 
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="interviewbtn" runat="server" CommandName="Select" 
                                                        class="btn btn-warning" Text="Convert" OnClientClick="return confirm('Do you want to convert this account to lecturer?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Applicants Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

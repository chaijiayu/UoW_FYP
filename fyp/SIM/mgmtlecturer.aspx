<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtlecturer.aspx.cs" Inherits="fyp.SIM.mgmtlecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Approve Subjects:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="subjectApplicationID" OnRowCommand="OnRowCommand" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>
                                    <asp:BoundField DataField="subjectApplicationID" HeaderText="Subject Application ID" />
                                    <asp:BoundField DataField="subjectID" HeaderText="Subject ID" />
                                    <asp:BoundField DataField="lecturerID" HeaderText="Lecturer ID" />
                                    <asp:BoundField DataField="fName" HeaderText="First Name" />
                                    <asp:BoundField DataField="lName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                    <asp:BoundField DataField="subject_Code" HeaderText="Subject Code" />
                                    <asp:BoundField DataField="subject_Name" HeaderText="Subject Name" />
                                    <asp:BoundField DataField="university" HeaderText="University" />
                                    <asp:BoundField DataField="subjectApp_status" HeaderText="Status" />
                                    <asp:BoundField DataField="subjectApp_submit_date" HeaderText="Application Date" />               
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="approvebtn" runat="server" CommandName="Approve"
                                                        class="btn btn-warning" Text="Approve" OnClientClick="return confirm('Do you want to approve this applicant?');" />
                                            <asp:Button ID="rejectbtn" runat="server" CommandName="Reject"
                                                        class="btn btn-warning" Text="Reject" OnClientClick="return confirm('Do you want to reject this applicant?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No subject approval Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>
                    <br />
                </div>
              </div>
            </main>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtsubjects.aspx.cs" Inherits="fyp.SIM.mgmtsubjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp View Subject Position Listed:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Search by subject code, subject name or venue:
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:TextBox ID="tbSearch" runat="server" Width="300px" Height="40px"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" class="btn btn-secondary"/>
                        </div>
                        <div class="col">
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Button ID="addbtn" runat="server" Text="Add Subject" OnClick="Add" class="btn btn-secondary"/>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="subjectID" OnRowDeleting="GridView1_RowDeleting" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>               
                                    <asp:BoundField DataField="subjectID" HeaderText="Subject ID" />
                                    <asp:BoundField DataField="subject_Code" HeaderText="Subject Code" />
                                    <asp:BoundField DataField="subject_Name" HeaderText="Subject Name" />
                                    <asp:BoundField DataField="subject_Venue" HeaderText="Subject Venue" />
                                    <asp:BoundField DataField="subject_Date" HeaderText="Subject Date" />
                                    <asp:BoundField DataField="subject_StartTime" HeaderText="Subject Start Time" />
                                    <asp:BoundField DataField="subject_EndTime" HeaderText="Subject End Time" />
                                    <asp:BoundField DataField="university" HeaderText="University" />
                                    <asp:BoundField DataField="status" HeaderText="Status" />
                                    <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="deletebtn" runat="server" CommandName="Delete" 
                                                            class="btn btn-warning" Text="Delete" OnClientClick="return confirm('Do you want to delete this job?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Subjects Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtjobs.aspx.cs" Inherits="fyp.SIM.mgmtjobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp View Job Postings:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Search by job position name:
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:TextBox ID="tbSearch2" runat="server" Width="300px" Height="40px"></asp:TextBox>
                            <asp:Button ID="btnSearch2" runat="server" onclick="btnSearch_Click2" Text="Search" class="btn btn-secondary"/>
                        </div>
                        <div class="col">
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Button ID="Button2" runat="server" Text="Add Job Posting" OnClick="Addposting" class="btn btn-secondary"/>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="postingID" OnRowDeleting="GridView2_RowDeleting" ShowHeaderWhenEmpty="True" CssClass="table">
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
                                                    <asp:Button ID="deletebtn1" runat="server" CommandName="Delete" 
                                                                class="btn btn-warning" Text="Delete" OnClientClick="return confirm('Do you want to delete this job listing?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>No Jobs Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

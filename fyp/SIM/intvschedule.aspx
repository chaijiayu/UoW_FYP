<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="intvschedule.aspx.cs" Inherits="fyp.SIM.intvschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Schedule Interview:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Interview Date:<br />
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Width="155px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Interview Venue:<br />
                            <asp:TextBox ID="TextBox2" runat="server" Width="400px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Timeslot:<br />
                            <asp:dropdownlist ID="ddl3" runat="server" width="150px" CssClass="form-control"> 
                                <asp:listitem text="10:00:00" value="10:00"></asp:listitem>
                                <asp:listitem text="11:00:00" value="11:00"></asp:listitem>
                                <asp:listitem text="14:00:00" value="14:00"></asp:listitem>
                                <asp:listitem text="15:00:00" value="15:00"></asp:listitem>
                                <asp:listitem text="16:00:00" value="16:00"></asp:listitem>
                                <asp:listitem text="17:00:00" value="17:00"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="AddInterview" 
                                        width="100px" class="btn btn-secondary" OnClientClick="return confirm('Do you want to confirm this schedule?');" />
                            <br />
                            <br />
                            <hr />

                            <h1>Applicant Details</h1>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="applicationID" ShowHeaderWhenEmpty="True" CssClass="table">
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

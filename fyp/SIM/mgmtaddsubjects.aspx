<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtaddsubjects.aspx.cs" Inherits="fyp.SIM.mgmtaddsubjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Add Subject:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Subject Code:<br />
                            <asp:TextBox ID="subjectCode" runat="server" Width="400px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Subject Name:<br />
                            <asp:TextBox ID="TextBox1" runat="server" Width="400px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Subject Venue:<br />
                            <asp:TextBox ID="TextBox2" runat="server" Width="400px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Subject Date:<br />
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" Width="155px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Subject Start Time: (HH:MM:SS)<br />
                            <asp:dropdownlist ID="ddl4" runat="server" Width="150px" CssClass="form-control"> 
                                    <asp:listitem text="08:30:00" value="08:30"></asp:listitem>
                                    <asp:listitem text="12:00:00" value="12:00"></asp:listitem>
                                    <asp:listitem text="15:30:00" value="15:30"></asp:listitem>
                                    <asp:listitem text="19:00:00" value="19:00"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Subject End Time: (HH:MM:SS)<br />
                            <asp:dropdownlist ID="ddl5" runat="server" width="150px" CssClass="form-control"> 
                                    <asp:listitem text="11:30:00" value="11:30"></asp:listitem>
                                    <asp:listitem text="15:00:00" value="15:00"></asp:listitem>
                                    <asp:listitem text="18:30:00" value="18:30"></asp:listitem>
                                    <asp:listitem text="22:00:00" value="22:00"></asp:listitem>
                            </asp:dropdownlist>
                             <br />
                            <br />
                            University<br />
                            <asp:dropdownlist ID="uni_ddl" runat="server" width="300px" CssClass="form-control"> 
                                    <asp:listitem text="University of Wollongong" value="UOW"></asp:listitem>
                                    <asp:listitem text="RMIT University" value="RMIT"></asp:listitem>
                                    <asp:listitem text="University of London" value="UOL"></asp:listitem>
                                    <asp:listitem text="University of Birmingham" value="UOB"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Availability:<br />
                                <asp:dropdownlist ID="TextBox6" runat="server" width="150px" CssClass="form-control"> 
                                    <asp:listitem text="Available" value="Available"></asp:listitem>
                                    <asp:listitem text="Unavailable" value="Unavailable"></asp:listitem>
                                </asp:dropdownlist>
                            <br />
                            <br />
                            <asp:Button ID="Button" runat="server" Text="Add" OnClick="AddSubject_Button" width="100px" class="btn btn-secondary"/>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

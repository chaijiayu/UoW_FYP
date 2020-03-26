<%@ Page Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtaddlessons.aspx.cs" Inherits="fyp.SIM.AddLessons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Create lessons:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">

                            Subject Code:<br />
                            <asp:TextBox ID="subjectCode" class="form-control" Width="300px" runat="server" AutoPostBack="true" OnTextChanged="subjectCode_TextChanged"></asp:TextBox>
                            <br />
                            <br />
                            Lecturer:<br />
                            <asp:TextBox ID="lecturer" class="form-control" Width="300px" runat="server" ReadOnly="true"></asp:TextBox>
                            <br />
                            <br />
                            Subject Venue:<br />
                            <asp:TextBox ID="subjectVenue" class="form-control" Width="300px" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            University<br />
                            <asp:dropdownlist ID="uni_ddl" class="form-control" Width="300px" runat="server"> 
                                    <asp:listitem text="University of Wollongong" value="UOW"></asp:listitem>
                                    <asp:listitem text="RMIT University" value="RMIT"></asp:listitem>
                                    <asp:listitem text="University of London" value="UOL"></asp:listitem>
                                    <asp:listitem text="University of Birmingham" value="UOB"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Subject Date:<br />
                            <asp:TextBox ID="subjectDate" class="form-control" Width="300px" runat="server" TextMode="Date"></asp:TextBox>
                            <br />
                            <br />
                            Subject Start Time: (HH:MM:SS)<br />
                            <asp:dropdownlist ID="ddl4" class="form-control" Width="300px" runat="server"> 
                                    <asp:listitem text="08:30:00" value="08:30:00"></asp:listitem>
                                    <asp:listitem text="12:00:00" value="12:00:00"></asp:listitem>
                                    <asp:listitem text="15:30:00" value="15:30:00"></asp:listitem>
                                    <asp:listitem text="19:00:00" value="19:00:00"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Subject End Time: (HH:MM:SS)<br />
                            <asp:dropdownlist ID="ddl5" class="form-control" Width="300px" runat="server"> 
                                    <asp:listitem text="11:30:00" value="11:30:00"></asp:listitem>
                                    <asp:listitem text="15:00:00" value="15:00:00"></asp:listitem>
                                    <asp:listitem text="18:30:00" value="18:30:00"></asp:listitem>
                                    <asp:listitem text="22:00:00" value="22:00:00"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            <asp:Button ID="Button" runat="server" width="100px" class="btn btn-secondary" Text="Add" OnClick="AddLesson_Button"/>

                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

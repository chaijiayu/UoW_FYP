<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="adminregister.aspx.cs" Inherits="fyp.Admin.adminregister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Register Manager:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            First Name:<br />
                            <asp:TextBox ID="TextBox1" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Last Name:<br />
                            <asp:TextBox ID="TextBox2" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Email:<br />
                            <asp:TextBox ID="TextBox3" runat="server" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Password:<br />
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="300px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Date Of Birth:<br />
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" Width="155px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Gender (m or f):<br />
                            <asp:dropdownlist ID="TextBox6" runat="server" Width="130px" CssClass="form-control"> 
                                <asp:listitem text="Male" value="m"></asp:listitem>
                                <asp:listitem text="Female" value="f"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            Contact:<br />
                            <asp:TextBox ID="TextBox7" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Status (active/inactive):<br />
                            <asp:dropdownlist ID="TextBox9" runat="server" Width="150px" CssClass="form-control"> 
                                <asp:listitem text="Active" value="active"></asp:listitem>
                                <asp:listitem text="Inactive" value="inactive"></asp:listitem>
                            </asp:dropdownlist>
                            <br />
                            <br />
                            <asp:Button ID="Button" runat="server" Text="Submit" OnClick="Register_Button" class="btn btn-secondary"/>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
    </asp:Content>

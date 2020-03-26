<%@ Page Title="" Language="C#" MasterPageFile="~/SIM/mgmt.Master" AutoEventWireup="true" CodeBehind="mgmtaddjobpostings.aspx.cs" Inherits="fyp.SIM.mgmtaddjobpostings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Add Job Position and Posting:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Job Position:<br />
                            <asp:TextBox ID="jpTB" width="330px" wrap="true" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Qualification:<br />
                            <asp:TextBox ID="TextBox2" TextMode="multiline" style="resize:none" width="330px" Height="50px" wrap="true" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Description:<br />
                            <asp:TextBox ID="TextBox3" TextMode="multiline" style="resize:none" width="330px" Height="50px" wrap="true" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            Availability:<br />
                                <asp:dropdownlist ID="TextBox4" runat="server" width="150px" CssClass="form-control"> 
                                    <asp:listitem text="Available" value="Available"></asp:listitem>
                                    <asp:listitem text="Unavailable" value="Unavailable"></asp:listitem>
                                </asp:dropdownlist>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="Button" runat="server" Text="Add" OnClick="AddJobPost_Button" width="100px" class="btn btn-secondary"/>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

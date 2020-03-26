<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="viewrepoedit.aspx.cs" Inherits="fyp.Admin.viewrepoedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Edit Account:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                          <asp:image id="profpic" runat="server" Width="50%"/><br />
                            Upload Profile Picture:<br />
                          <asp:FileUpload id="FileUploadControl" runat="server" class="btn btn-secondary" />
                        </div>
                        <div class="col">
                          <table class="style1" >
                            <tr>
                                <td class="style2"></td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                <td class="style2">First Name:</td>
                                <td>
                                        <asp:TextBox ID="fsName" runat="server" CssClass="form-control" ></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="style2">Last Name:</td>
                                <td>
                                        <asp:TextBox ID="lsName" runat="server" CssClass="form-control" ></asp:TextBox>
  
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">Gender: </td>
                                <td>
                                       <asp:dropdownlist ID="gender" runat="server" Width="100px" CssClass="form-control"> 
                                            <asp:listitem text="Male" value="m"></asp:listitem>
                                            <asp:listitem text="Female" value="f"></asp:listitem>
                                        </asp:dropdownlist>

                                </td>
                            </tr>
                            <tr>
                                <td class="style2">Date Of Birth:</td>
                                <td style="margin-left: 40px">
                                        <asp:TextBox ID="dob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="style2" style="height: 31px">Email:</td>
                                <td style="height: 31px">
                                        <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" style="height: 31px">Password:</td>
                                <td style="height: 31px">
                                        <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">Phone:</td>
                                <td>
                                        <asp:TextBox ID="phoneNum" runat="server" CssClass="form-control" ></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="style2">User Type:</td>
                                <td>
                                        <asp:dropdownlist ID="userType" runat="server" Width="150px" CssClass="form-control"> 
                                            <asp:listitem text="Applicant" value="ap"></asp:listitem>
                                            <asp:listitem text="Lecturer" value="l"></asp:listitem>
                                            <asp:listitem text="Manager" value="m"></asp:listitem>
                                        </asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">Status:</td>
                                <td>
                                        <asp:dropdownlist ID="status" runat="server" Width="150px" CssClass="form-control"> 
                                            <asp:listitem text="Active" value="active"></asp:listitem>
                                            <asp:listitem text="Inactive" value="inactive"></asp:listitem>
                                        </asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td><br /></td>
                            </tr>
                        </table>

                          <asp:Button ID="update" runat="server" OnClick="update_Click" Text="Update Profile" Width="197px" class="btn btn-secondary"/>   
                          <br />
                          <br />

                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>

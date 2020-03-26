<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantprofile.aspx.cs" Inherits="fyp.Applicant.applicantprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="container w3-white w3-text-grey w3-card-4">
        <div class="row">
            <h1>&nbsp My Profile</h1>
        </div>
        <br />
        <div class="row">
            <div class="col">
              <asp:image id="profpic" runat="server" Width="50%"/><br />
                Upload Profile Picture:<br />
              <asp:FileUpload id="FileUploadControl" runat="server" class="btn btn-secondary"/>
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
                           <asp:TextBox ID="gender" runat="server" CssClass="form-control" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="style2">Date Of Birth:</td>
                    <td style="margin-left: 40px">
                            <asp:TextBox ID="dob" runat="server" CssClass="form-control" TextMode="Date" ReadOnly="true"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="style2" style="height: 31px">Email:</td>
                    <td style="height: 31px">
                            <asp:TextBox ID="email" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">Phone:</td>
                    <td>
                            <asp:TextBox ID="phoneNum" runat="server" CssClass="form-control" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="style2">Your Resume/CV:</td>
                    <td>
                            <asp:TextBox ID="cv" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>

                    </td>
                    <td><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Download" class="btn btn-secondary"/></td>
                </tr>
                <tr>
                    <td class="style2">Work Experience:</td>
                    <td>
                            <asp:TextBox ID="work" TextMode="multiline" style="resize:none" width="330px" Height="50px" wrap="true" runat="server" CssClass="form-control" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="style2">Education:</td>
                    <td>
                            <asp:TextBox ID="edu" TextMode="multiline" style="resize:none" width="330px" Height="50px" wrap="true" runat="server" CssClass="form-control" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
            </table>

              <asp:Button ID="update" runat="server" OnClick="update_Click" Text="Update Profile" Width="197px" class="btn btn-secondary" />
              <asp:Button ID="pwdChange" runat="server" Text="Change Password" Width="197px" OnClick="pwdChange_Click" class="btn btn-secondary" />    
               
              <br />
              <br />

            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/lecturer.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="fyp.Lecturer.changePassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <h1>Change Password Form:</h1>
            </td>
        </tr>
        <tr>
            <td>Old Password:
            </td>
            <td>
                <asp:TextBox ID="oldPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>New Password:
            </td>
            <td>
                <asp:TextBox ID="newPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Confirm new Password:
            </td>
            <td>
                <asp:TextBox ID="cfmNewPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="changePwd" runat="server" Text="Change Password" Width="197px" OnClick="changePwd_Click" />
                <asp:Button ID="resetForm" runat="server" OnClick="update_Click" Text="Reset" Width="197px" />

            </td>
        </tr>
    </table>
</asp:Content>


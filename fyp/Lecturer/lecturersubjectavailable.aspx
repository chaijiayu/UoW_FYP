<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/lecturer.Master" AutoEventWireup="true" CodeBehind="lecturersubjectavailable.aspx.cs" Inherits="fyp.Lecturer.lecturersubjectavailable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container w3-white w3-card-4">
        <div class="row">
            <h1>&nbsp View Subject available:</h1>
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
                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" class="btn btn-secondary" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="subjectID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True" CssClass="table">
                    <headerstyle cssclass="thead-dark"/>
                    <Columns>
                       <asp:BoundField DataField="subjectID" HeaderText="Subject ID" />
                        <asp:BoundField DataField="subject_Code" HeaderText="Subject Code" />
                        <asp:BoundField DataField="subject_Name" HeaderText="Subject Name" />
                        <asp:BoundField DataField="subject_Venue" HeaderText="Venue" />
                        <asp:BoundField DataField="subject_Date" HeaderText="Subject Date" DataFormatString="{0:dd/MM/yy}"/>
                        <asp:BoundField DataField="subject_StartTime" HeaderText="Subject Start Time" />
                        <asp:BoundField DataField="subject_EndTime" HeaderText="Subject End Time" />
                        <asp:BoundField DataField="university" HeaderText="University" />
                        <asp:BoundField DataField="status" HeaderText="Availability" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="deletebtn" runat="server" CommandName="Select"
                                            class="btn btn-warning" Text="Select" OnClientClick="return confirm('Do you want to apply to teach this subject?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Subjects Available</EmptyDataTemplate> 
                 </asp:GridView>
            </div>
        </div>                
    </div>
</asp:Content>

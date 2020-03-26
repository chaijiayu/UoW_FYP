<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="viewrepo.aspx.cs" Inherits="fyp.Admin.viewrepo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4">
              <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pb-2 mb-3 border-bottom">           
                <br /><br />

                <div class="container w3-white w3-card-4">
                    <div class="row">
                        <h1 class="h2">&nbsp Human Resource List:</h1>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col">
                            Search by name or email:
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:TextBox ID="tbSearch" runat="server" Width="300px" Height="40px"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" class="btn btn-secondary"/>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="OnRowSelected" AutoGenerateColumns="False" DataKeyNames="userID" ShowHeaderWhenEmpty="True" CssClass="table">
                                <headerstyle cssclass="thead-dark"/>
                                <Columns>
                                    <asp:BoundField DataField="userID" HeaderText="User ID" />
                                    <asp:TemplateField HeaderText="First Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblfName" runat="server" Text='<%# Eval("fName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtfName" runat="server" Text='<%# Eval("fName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbllName" runat="server" Text='<%# Eval("lName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtlName" runat="server" Text='<%# Eval("lName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtemail" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblpass" runat="server" Text='<%# Eval("password") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtpass" runat="server" Text='<%# Eval("password") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOB" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbldob" runat="server" Text='<%# Eval("DOB", "{0:dd/M/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdob" runat="server" Text='<%# Eval("DOB") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gender" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblgender" runat="server" Text='<%# Eval("gender") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgender" runat="server" Text='<%# Eval("gender") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("contact") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtcontact" runat="server" Text='<%# Eval("contact") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Type" >
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("userType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txttype" runat="server" Text='<%# Eval("userType") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="editbtn" runat="server" CommandName="Select" 
                                                        class="btn btn-warning" Text="Edit" OnClientClick="return confirm('Do you want to edit this account?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="deletebtn" runat="server" CommandName="Delete" 
                                                        class="btn btn-warning" Text="Delete" OnClientClick="return confirm('Do you want to delete this account?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Accounts Available</EmptyDataTemplate> 
                            </asp:GridView>
                        </div>
                        <br />                                             
                    </div>   
                    <br /><br />
                </div>
              </div>
            </main>
</asp:Content>


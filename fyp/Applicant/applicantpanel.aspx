<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/applicant.Master" AutoEventWireup="true" CodeBehind="applicantpanel.aspx.cs" Inherits="fyp.Applicant.applicantpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Container -->
    <div class="w3-content w3-margin-top" style="max-width:1400px;">

      <!-- The Grid -->
      <div class="w3-row-padding">
  
        <!-- Left Column -->
        <div class="w3-third">
    
          <div class="w3-white w3-text-grey w3-card-4">
            <div class="w3-display-container">
              <asp:image id="profpic" runat="server" Width="100%"/>  
            </div>

            <div class="w3-container">
              <div >
                <h2><asp:Label ID="lblfName" runat="server"></asp:Label>&nbsp;<asp:Label ID="lbllName" runat="server"></asp:Label></h2>
              </div>
              <p><i class="fa fa-home fa-fw w3-margin-right w3-large w3-text-teal"></i>Singapore, SG</p>
              <p><i class="fa fa-envelope fa-fw w3-margin-right w3-large w3-text-teal"></i><asp:Label ID="lblEmail" runat="server"></asp:Label></p> 
              <p><i class="fa fa-phone fa-fw w3-margin-right w3-large w3-text-teal"></i><asp:Label ID="lblPhone" runat="server"></asp:Label></p>       
              <br />
            </div>
          </div><br>

        <!-- End Left Column -->
        </div>

        <!-- Right Column -->
        <div class="w3-twothird">
    
          <!--Work Experience -->
          <div class="w3-container w3-card w3-white w3-margin-bottom">
            <h2 class="w3-text-grey w3-padding-16"><i class="fa fa-suitcase fa-fw w3-margin-right w3-xxlarge w3-text-teal"></i>Work Experience</h2>
            <div class="w3-container">
              <h5 class="w3-opacity"><b><asp:Label ID="lblWork" runat="server"></asp:Label></b></h5> 
              <hr>
            </div>
          </div>

          <!--Education-->
          <div class="w3-container w3-card w3-white">
            <h2 class="w3-text-grey w3-padding-16"><i class="fa fa-certificate fa-fw w3-margin-right w3-xxlarge w3-text-teal"></i>Education</h2>
            <div class="w3-container">
              <h5 class="w3-opacity"><b><asp:Label ID="lblEdu" runat="server"></asp:Label></b></h5>
              <hr>
            </div>
          </div>

        <!-- End Right Column -->
        </div>
    
      <!-- End Grid -->
      </div>
  
      <!-- End Page Container -->
    </div>
</asp:Content>

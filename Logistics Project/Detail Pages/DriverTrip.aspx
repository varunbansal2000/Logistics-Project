<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DriverTrip.aspx.cs" Inherits="Logistics_Project.Detail_Pages.DriverTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Your Trips</h1>
    <div class="container">
        <div class="form-group">
            <asp:Label runat="server">Choose your name and ID </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstname" runat="server" OnTextChanged="lstname_TextChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select your Details" runat="server" ControlToValidate="lstname" ErrorMessage="Please choose id!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <h3>Assigned Trip Details</h3>
        <asp:GridView ID="tripAssigned" runat="server"></asp:GridView>

        <hr />
        <h3>Fill after completion</h3>

         <div class="form-group">
            <asp:Label runat="server">End Date</asp:Label>
            <asp:TextBox runat="server" ID="txtdate" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtdate"
                ErrorMessage="Please enter a  date!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>

            <div class="form-group">
            <asp:Label runat="server">Extra Distance</asp:Label>
            <asp:TextBox runat="server" ID="txtDis" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThanEqual" ControlToValidate="txtDis" runat="server" ErrorMessage="Should be greater than equal to 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDis"
                ErrorMessage="Please enter extra Distance!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

            <div class="form-group">
            <asp:Label runat="server">Toll Charges</asp:Label>
            <asp:TextBox runat="server" ID="txtToll" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThanEqual" ControlToValidate="txtToll" runat="server" ErrorMessage="Should be greater than equal to 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtToll"
                ErrorMessage="Please enter Toll Charges!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

            <div class="form-group">
            <asp:Label runat="server">Maintanence Charges</asp:Label>
            <asp:TextBox runat="server" ID="txtMaintainece" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThanEqual" ControlToValidate="txtMaintainece" runat="server" ErrorMessage="Should be greater than equal to 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMaintainece"
                ErrorMessage="Please enter Maintainece Charges!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

            <div class="form-group">
            <asp:Label runat="server">Extra Charges</asp:Label>
            <asp:TextBox runat="server" ID="txtExtra" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThanEqual" ControlToValidate="txtExtra" runat="server" ErrorMessage="Should be greater than equal to 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtExtra"
                ErrorMessage="Please enter Extra Charges!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

          <div class="form-group">
            
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success"
                OnClick="btnSave_Click" />
        </div>

        <br />
        <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>

        <hr />
    </div>



</asp:Content>

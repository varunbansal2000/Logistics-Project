<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DriverDetails.aspx.cs" Inherits="Logistics_Project.Detail_Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Driver Details</h1>
    <div class="container">

        <div class="form-group">
            <asp:Label runat="server">Name</asp:Label>
            <asp:TextBox runat="server" ID="txtname" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtname"
                ErrorMessage="Please enter a user name!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Contact No.</asp:Label>
            <asp:TextBox runat="server" ID="txtcontact" CssClass="form-control" AutoPostBack="false"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="txtcontact" ErrorMessage="Enter correct contact number of 10 digits!!" ForeColor="Red"
                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcontact"
                ErrorMessage="Please enter contact details!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Charges</asp:Label>
            <asp:TextBox runat="server" ID="txtcharges" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThan" ControlToValidate="txtcharges" runat="server" ErrorMessage="Should be greater than 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcharges"
                ErrorMessage="Please enter charges!!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnNew" runat="server" CausesValidation="false" Text="New" CssClass="btn btn-warning"
                OnClick="btnNew_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success"
                OnClick="btnSave_Click" />
        </div>
    </div>

    <br/>
    <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>

    <hr />

    <hr />
    <asp:GridView ID="details" runat="server" BackColor="White"
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        GridLines="Vertical" AutoGenerateColumns="True">
       
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>


</asp:Content>

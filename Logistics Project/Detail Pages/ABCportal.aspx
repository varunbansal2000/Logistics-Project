<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABCportal.aspx.cs" Inherits="Logistics_Project.Detail_Pages.ABCportal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>New Trip Portal (30 RS per KM)</h1>
    <div class="container">
        <div class="form-group">
            <asp:Label runat="server">Choose Destination </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstDest" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select Destination" runat="server" ControlToValidate="lstDest" ErrorMessage="Please choose destination!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Start Date</asp:Label>
            <asp:TextBox runat="server" ID="txtdate" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtdate"
                ErrorMessage="Please enter a  date!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Button ID="btnNew" runat="server" CausesValidation="false" Text="New" CssClass="btn btn-warning"
                OnClick="btnNew_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success"
                OnClick="btnSave_Click" />
        </div>
        <br />
        <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>

        <hr />
        <h3>Trip Details</h3>
        <asp:GridView ID="details" runat="server" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"
            GridLines="Vertical" AutoGenerateColumns="True">

            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="LemonChiffon" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>

        <hr />
        <h3>Available Destinations</h3>
        <asp:GridView ID="DestDetails" runat="server"></asp:GridView>
    </div>
</asp:Content>

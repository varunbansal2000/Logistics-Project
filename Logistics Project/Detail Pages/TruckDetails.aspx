<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TruckDetails.aspx.cs" Inherits="Logistics_Project.Detail_Pages.TruckDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Truck Details</h1>
    <div class="container">

        <div class="form-group">
            <asp:Label runat="server">Truck No.</asp:Label>
            <asp:TextBox runat="server" ID="txtname" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtname"
                ErrorMessage="Please enter a valid number!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Choose Vendor </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstVendors" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select Vendor" runat="server" ControlToValidate="lstVendors" ErrorMessage="Please choose vendor!!" ForeColor="Red"></asp:RequiredFieldValidator>

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
        <HeaderStyle BackColor="LemonChiffon" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>


</asp:Content>

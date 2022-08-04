<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DestinationDetails.aspx.cs" Inherits="Logistics_Project.Detail_Pages.DestinationDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Destinaion Details</h1>
    <div class="container">

        <div class="form-group">
            <asp:Label runat="server">Destination State</asp:Label>
            <asp:TextBox runat="server" ID="txtdstS" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtdstS"
                ErrorMessage="Please enter a State name!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Destination City</asp:Label>
            <asp:TextBox runat="server" ID="txtdstC" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdstC"
                ErrorMessage="Please enter a City name!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
       
        <div class="form-group">
            <asp:Label runat="server">Distance</asp:Label>
            <asp:TextBox runat="server" ID="txtDis" CssClass="form-control" TextMode="Number" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ValueToCompare="0" Operator="GreaterThan" ControlToValidate="txtDis" runat="server" ErrorMessage="Should be greater than 0!!" ForeColor="Red"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDis"
                ErrorMessage="Please enter Distance!!" ForeColor="Red"></asp:RequiredFieldValidator>
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

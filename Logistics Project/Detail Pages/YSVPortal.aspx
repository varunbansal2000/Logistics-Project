<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YSVPortal.aspx.cs" Inherits="Logistics_Project.Detail_Pages.YSVPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Creating Trips</h1>
    <div class ="container">
        <div class="form-group">
            <asp:Label runat="server">Choose Trip ID </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstTripID" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select Trip" runat="server" ControlToValidate="lstTripID" ErrorMessage="Please choose Trip!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Choose Driver </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstDriverName" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select Driver" runat="server" ControlToValidate="lstDriverName" ErrorMessage="Please choose Driver!!" ForeColor="Red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label runat="server">Choose Truck </asp:Label>
            <asp:DropDownList CssClass="form-control" ID="lstTrucks" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="Select Truck" runat="server" ControlToValidate="lstTrucks" ErrorMessage="Please choose Truck!!" ForeColor="Red"></asp:RequiredFieldValidator>

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
        <div>
            <h3>New Trips</h3>
            <asp:GridView ID="Gridtrips" runat="server"></asp:GridView>
            <h3>Available Drivers</h3>
            <asp:GridView ID="GridDrivers" runat="server"></asp:GridView>
            <h3>Available Trucks</h3>
            <asp:GridView ID="GridTrucks" runat="server"></asp:GridView>
        </div>

    </div>

</asp:Content>

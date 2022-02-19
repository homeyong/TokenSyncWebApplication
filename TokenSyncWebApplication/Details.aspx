<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Details.aspx.vb" Inherits="TokenSyncWebApplication.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <asp:Label ID="contractAddressData" runat="server" class="col-sm-3 col-form-label font-weight-bold" Text="Address"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="lblPrice" runat="server" class="col" Text="Price:"></asp:Label>
            <asp:Label ID="priceData" runat="server" class="col font-weight-bold" Text="$ 0.00"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="lbltotalSupply" runat="server" class="col" Text="Total Supply:"></asp:Label>
            <asp:Label ID="totalSupplyData" runat="server" class="col" Text="Total Supply"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="lbltotalHolders" runat="server" class="col" Text="Total Holders:"></asp:Label>
            <asp:Label ID="totalHoldersData" runat="server" class="col" Text="Total Holders Data"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="lblname" runat="server" class="col" Text="Name:"></asp:Label>
            <asp:Label ID="nameData" runat="server" class="col" Text="Name"></asp:Label>
        </div>
    </div>
</asp:Content>


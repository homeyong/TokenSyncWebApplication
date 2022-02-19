<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.vb" Inherits="TokenSyncWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <form id="token">
                    <h4>Save / Update Token </h4>
                    <div class="form-group row">
                        <label for="name" class="col-sm-3 col-form-label">Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name" />
                        <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="txtName" ErrorMessage="Please enter a name!" />
                    </div>
                    <div class="form-group row">
                        <label for="name" class="col-sm-3 col-form-label">Symbol</label>
                        <asp:TextBox ID="txtSymbol" runat="server" CssClass="form-control" placeholder="Symbol" />
                        <asp:RequiredFieldValidator runat="server" ID="reqSymbol" ControlToValidate="txtSymbol" ErrorMessage="Please enter a symbol!" />
                    </div>
                    <div class="form-group row">
                        <label for="name" class="col-sm-3 col-form-label">Contract Address</label>
                        <asp:TextBox ID="txtContractAddress" runat="server" CssClass="form-control" placeholder="Contract Address" />
                        <asp:RequiredFieldValidator runat="server" ID="reqContact" ControlToValidate="txtContractAddress" ErrorMessage="Please enter a Contract Address!" />
                    </div>
                    <div class="form-group row">
                        <label for="name" class="col-sm-3 col-form-label">Total Supply</label>
                        <asp:TextBox ID="txtTotalSupply" runat="server" CssClass="form-control" placeholder="Total Supply" />
                        <asp:RequiredFieldValidator runat="server" ID="reqTotalSupply" ControlToValidate="txtTotalSupply" ErrorMessage="Please enter a Total Supply!" />
                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtTotalSupply" ErrorMessage="Value must be a whole number" />
                    </div>
                    <div class="form-group row">
                        <label for="name" class="col-sm-3 col-form-label">Total Holders</label>
                        <asp:TextBox ID="txtTotalHolders" runat="server" CssClass="form-control" placeholder="Total Holders" />
                        <asp:RequiredFieldValidator runat="server" ID="reqTotalHolders" ControlToValidate="txtTotalHolders" ErrorMessage="Please enter a Total Holders!" />
                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtTotalHolders" ErrorMessage="Value must be a whole number" />
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnSave" Text="Save" runat="server" Class="btn btn-primary" />
                        <asp:Button ID="btnReset" Text="Reset" runat="server" Class="btn btn-info" CausesValidation="False" />
                    </div>
                </form>
            </div>
            <div class="col">
                TESTING
            </div>
        </div>
        <div class="row mb-5">
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" class="table table-bordered table-responsive table-hover " runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChanging" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Rank" />
                        <asp:HyperLinkField DataTextField="symbol" DataNavigateUrlFields="symbol" DataNavigateUrlFormatString="~/Details.aspx?Id={0}" HeaderText="Symbol" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="contract_address" HeaderText="Contract Address" />
                        <asp:BoundField DataField="total_holders" HeaderText="Total Holders" />
                        <asp:BoundField DataField="total_supply" HeaderText="Total Supply" />
                        <asp:BoundField DataField="totalPercent" HeaderText="Total Supply %" />
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="Edit" CommandArgument='<%#Eval("Symbol") %>' CommandName="EditToken" CausesValidation="False">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-right">
                <asp:Button ID="btnExport" Text="Export" runat="server" Class="btn btn-success" CausesValidation="False" />
            </div>
        </div>
    </div>

</asp:Content>

<%@ Page Title="Calculator" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Calculator.aspx.vb" Inherits="Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Calculator</h2>

    <div class="form-group">
        <label>Number 1</label>
        <asp:TextBox runat="server" ID="txtNum1" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Number 2</label>
        <asp:TextBox runat="server" ID="txtNum2" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Unnamed1_Click" />

    <div class="form-group">
        <label>Result</label>
        <asp:TextBox runat="server" ID="txtResult" CssClass="form-control"></asp:TextBox>
    </div>
</asp:Content>


<%@ Page Title="Signin" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Signin.aspx.vb" Inherits="Signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Sign in</h2>

    <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>

    <div class="form-group">
        <label>Username</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Password</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" />
</asp:Content>

<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h1>Hello World</h1>
        </div>
        <div class="col-12">
            <%If Session("Authenticated") = True Then%>
            <h2>Username: <%=Session("Username")%></h2>
            <%End If%>
        </div>
        <div class="col-12 bg-dark p-4">
            <img class="mb-2" src="https://dotnet.microsoft.com/static/images/anniversary/anniversary-logo.svg?v=V8TPY1YgibD7PgDQbNZhkXN6hZYp7ZpLSPvK3rYRt14" alt="" width="120" height="120">
            <small class="d-block mb-3 text-muted">&copy; 2017-2021</small>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetRedisCacheDetails._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Demo Application</h1>
        <p class="lead">This application gets the details of a shopping cart based on an entered User ID.</p>
        <p class="lead"><asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></p>
        <p><asp:Button ID="btnGet" class="btn btn-primary btn-lg" runat="server" Text="Get Shopping Cart &raquo;" OnClick="btnGet_Click" /></p>
    
    </div>

    <div class="row">
       <p class="lead"><asp:Label ID="lblResults" runat="server"></asp:Label></p>
    </div>

</asp:Content>

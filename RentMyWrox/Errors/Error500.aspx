<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error500.aspx.cs" Inherits="RentMyWrox.Errors.Error500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Other Error</h1>
	<p>
		There was an error on the server. Either return to the 
		<a href="~/Item/Index" runat="server">Homepage</a>
		or choose a different selection from the menu.
		We have been notified about the problem and will work 
		on it immediately.
	</p>
</asp:Content>

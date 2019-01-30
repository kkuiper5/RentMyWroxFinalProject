<%@ Page Title="" Language="C#" 
	MasterPageFile="~/WebForms.Master" 
	AutoEventWireup="true" 
	CodeBehind="Default.aspx.cs" 
	Inherits="RentMyWrox.Admin.Default" %>

<%@ Register Src="~/Controls/NotificationsControl.ascx" TagName="Notifications" TagPrefix="rmw"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<rmw:Notifications runat="server" ID="BaseId" Display="AdminOnly"/>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms.Master" AutoEventWireup="true" CodeBehind="ManageHobby.aspx.cs" Inherits="RentMyWrox.Admin.ManageHobby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:DetailsView ID="DetailsView1" AutoGenerateRows="false" runat="server"
	                 DataKeyNames="Id" DefaultMode="Insert" 
	                 InsertMethod="DetailsView1_InsertItem"
	                 SelectMethod="DetailsView1_GetItem">
		<Fields>
			<asp:BoundField DataField="Name" HeaderText="Name" />
			<asp:CheckBoxField DataField="IsActive" HeaderText="Active ?" />
			<asp:CommandField ShowInsertButton="True" ShowCancelButton="false" />
		</Fields>
	</asp:DetailsView>
</asp:Content>

<%@ Page
	Title=""
	Language="C#"
	MasterPageFile="~/WebForms.Master"
	AutoEventWireup="true"
	CodeBehind="ManageItem.aspx.cs"
	Inherits="RentMyWrox.Admin.ManageItem"
	MetaTagDescription="Manage the items that are available to be checked out from the library"
	MetaTagKeywords="Tools, Lending Library, Manage Items, actual useful keywords here" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<RMW:NotificationsControl runat="server" />
	<div>
		<div>
			<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Name" AssociatedControlID="tbName" />
			<asp:TextBox runat="server" ID="tbName" />
			<asp:RequiredFieldValidator ID="rfName" ControlToValidate="tbName" runat="server" ErrorMessage="Name is Required" Text="*" Display="Dynamic" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Description" AssociatedControlID="tbDescription" />
			<asp:TextBox runat="server" ID="tbDescription" TextMode="MultiLine" Rows="5" />
			<asp:RequiredFieldValidator ID="rfDescription" ControlToValidate="tbDescription" runat="server"
				ErrorMessage="Description is Required" Text="*" Display="Dynamic" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Cost" AssociatedControlID="tbCost" />
			<asp:TextBox runat="server" ID="tbCost" />
			<asp:RequiredFieldValidator ID="rfCost" ControlToValidate="tbCost" runat="server" ErrorMessage="Cost is Required" Text="*" Display="Dynamic" />
			<asp:CompareValidator ID="cCost" ControlToValidate="tbCost" runat="server"
				ErrorMessage="Cost does not appear to be the correct format" Text="*" Type="Currency" Operator="DataTypeCheck" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Item Number" AssociatedControlID="tbItemNumber" />
			<asp:TextBox runat="server" ID="tbItemNumber" />
			<asp:RequiredFieldValidator ID="rfItemNumber" ControlToValidate="tbItemNumber" runat="server" ErrorMessage="Item Number is Required" Text="*" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Picture" AssociatedControlID="fuPicture" />
			<asp:FileUpload ID="fuPicture" ClientIDMode="Static" runat="server" />
		</div>
		<div class="dataentry">
			<asp:Label runat="server" Text="Acquired Date" AssociatedControlID="tbAcquiredDate" />
			<asp:TextBox runat="server" ID="tbAcquiredDate" />
			<asp:RequiredFieldValidator ID="rfAcquiredDate" ControlToValidate="tbAcquiredDate" runat="server" 
				ErrorMessage="Acquired Date is Required" Text="*" Display="Dynamic"/> 
			<asp:CompareValidator ID="cAcquiredDate" ControlToValidate="tbAcquiredDate" runat="server" 
				ErrorMessage="Acquired Date does not appear to be the correct format" Text="*" Type="Date" Operator="DataTypeCheck"/>
		</div>
		<asp:Button Text="Save Item" runat="server" OnClick="SaveItem_Clicked" />
	</div>
</asp:Content>

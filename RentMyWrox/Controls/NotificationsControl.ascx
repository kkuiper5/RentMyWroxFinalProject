<%@ Control Language="C#" AutoEventWireup="true"
	CodeBehind="NotificationsControl.ascx.cs"
	Inherits="RentMyWrox.Controls.NotificationsControl" %>
<asp:ScriptManager ID="smNotifications" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="upNotifications" runat="server">
	<ContentTemplate>
		<asp:HiddenField runat="server" ID="hfNumberToSkip" />
		
		<asp:Label runat="server" ID="NotificationTitle" CssClass="NotificationTitle" />
		<br/>
		<asp:Label runat="server" ID="NotificationDetail" CssClass="NotificationDetail" />
		
		<div class="paginationline">
			<span class="leftside">
				<asp:LinkButton runat="server" ID="lbPrevious" Text="<<"
				                ToolTip="Previous Item" OnClick="Previous_Click" />
			</span>
			<span class="rightside">
				<asp:LinkButton runat="server" ID="lbNext" Text=">>" 
				                ToolTip="Next Item" OnClick="Next_Click"/>
			</span>
		</div>
		<asp:Timer runat="server" ID="tmrNotifications" Interval="5000" OnTick="Notifications_Tick"></asp:Timer>
	</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="uprogNotifications" DisplayAfter="500" runat="server" AssociatedUpdatePanelID="upNotifications">
	<ProgressTemplate>
		<div class="progressnotification">
			Updating...
		</div>
	</ProgressTemplate>
</asp:UpdateProgress>

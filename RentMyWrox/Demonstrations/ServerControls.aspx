<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerControls.aspx.cs" Inherits="RentMyWrox.Demonstrations.ServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="demoToolBox" runat="server" />
        <asp:Label ID="displayLabel" runat="server" />
        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Display Text" />

        <input type="text" runat="server" id="htmlText" />

<asp:CheckBoxList ID="availableColors" runat="server"  >
    <asp:ListItem Text="Red" Value="red" />
    <asp:ListItem Text="Green" Value="green" />
    <asp:ListItem Text="Blue" Value="blue" />
</asp:CheckBoxList>

    </div>
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:FormView ID="FormView1" runat="server"></asp:FormView>
    </form>
</body>
<asp:hyperlink runat="server">HyperLink</asp:hyperlink>
</html>

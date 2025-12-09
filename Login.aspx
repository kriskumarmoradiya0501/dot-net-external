<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="practiceDB2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login Form</h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me?"/> 
        </div>
        <div>
            <asp:Button ID="login" runat="server" Text="login" OnClick="login_Click" />
        </div>
        <div>
            <a href="Registration.aspx">Registre first..</a>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="practiceDB2.update" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Record</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Form</h1>

        <!-- Hidden values stored in Labels -->
        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblOldImagePath" runat="server" Visible="false"></asp:Label>

        Username:
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />

        Password:
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />

        Gender:
        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:RadioButtonList>
        <br />

        Qualification:
        <asp:DropDownList ID="ddlQualification" runat="server">
            <asp:ListItem Text="BCA" Value="BCA"></asp:ListItem>
            <asp:ListItem Text="MCA" Value="MCA"></asp:ListItem>
            <asp:ListItem Text="MScIT" Value="MScIT"></asp:ListItem>
            <asp:ListItem Text="BScIT" Value="BScIT"></asp:ListItem>
        </asp:DropDownList>
        <br />

        Mobile:
        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
        <br />

        Current Image:
        <asp:Image ID="imgCurrent" runat="server" Height="50" Width="50" />
        <br />

        New Image (Optional):
        <asp:FileUpload ID="fuProfilePhoto" runat="server" />
        <br />

        <h3>Marks</h3>

        Maths:
        <asp:TextBox ID="txtMaths" runat="server"></asp:TextBox>
        <br />

        Science:
        <asp:TextBox ID="txtScience" runat="server"></asp:TextBox>
        <br />

        English:
        <asp:TextBox ID="txtEnglish" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnUpdate" runat="server" Text="Update Record" OnClick="btnUpdate_Click" />
        <br /><br />
        <a href="display.aspx">Cancel / Back to List</a>
    </form>
</body>
</html>

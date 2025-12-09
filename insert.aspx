<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="practiceDB2.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Marks Entry</title>
</head>
<body>
    <form id="form1" runat="server">
            <h1>Insert Marks</h1>
            
            <h3><asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label></h3><br />

                <label>Maths:</label>
                <asp:TextBox ID="txtMaths" runat="server"></asp:TextBox><br />

                <label>Science:</label>
                <asp:TextBox ID="txtScience" runat="server"></asp:TextBox><br />

                <label>English:</label>
                <asp:TextBox ID="txtEnglish" runat="server"></asp:TextBox><br />

                <asp:Button ID="btnCalculateSave" runat="server" Text="Calculate & Save" OnClick="btnCalculateSave_Click"
                    /><br />
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Bold="true"></asp:Label>

    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="display.aspx.cs" Inherits="practiceDB2.display" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Data</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>All Student Records</h1>
            <a href="main.aspx">Back to Menu</a>
            <br /><br />

            <table border="1">
                <tr>
                    <th>ID</th>
                    <th>Username</th>
                    <th>Password</th>
                    <th>Gender</th>
                    <th>Qualification</th>
                    <th>Mobile</th>
                    <th>Image</th>
                    <th>Maths</th>
                    <th>Science</th>
                    <th>English</th>
                    <th>Total</th>
                    <th>%</th>
                    <th>Grade</th>
                    <th>Delete</th>
                    <th>Update</th>
                </tr>
                <asp:Literal ID="litTableRows" runat="server"></asp:Literal>
            </table>
        </div>
    </form>
</body>
</html>

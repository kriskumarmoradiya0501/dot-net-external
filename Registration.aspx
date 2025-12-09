<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="practiceDB2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Profile Registration</h2>
            
            <div>
                <asp:FileUpload ID="fuProfilePhoto" runat="server" />
            </div>

            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Username:" />
                <asp:TextBox ID="txtUsername" runat="server" />
            </div>

            <div>
                <asp:Label ID="lblPassword" runat="server" Text="Password:" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>
            
            <div>
                <asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            
            <div>
                <asp:Label ID="lblQualification" runat="server" Text="Qualification:" />
                <asp:DropDownList ID="ddlQualification" runat="server">
                    <asp:ListItem Text="BCA" Value="BCA"></asp:ListItem>
                    <asp:ListItem Text="MCA" Value="MCA"></asp:ListItem>
                    <asp:ListItem Text="MScIT" Value="MScIT"></asp:ListItem>
                    <asp:ListItem Text="BScIT" Value="BScIT"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label ID="lblMobile" runat="server" Text="Mobile Number:" />
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" />
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>

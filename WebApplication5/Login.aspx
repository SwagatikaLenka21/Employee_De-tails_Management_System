<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 165px;
        }
        .auto-style3 {
            margin-left: 80px;
        }
        .auto-style4 {
            background-color: #00FFFF;
        }
        .auto-style5 {
            width: 165px;
            background-color: #00FFFF;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">USERNAME</td>
                    <td>
                        <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_UserName" runat="server" ControlToValidate="txt_UserName" ErrorMessage="Enter UserName" Font-Bold="True" ForeColor="Black" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">PASSWORD</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_Pwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Pwd" runat="server" ControlToValidate="txt_Pwd" ErrorMessage="Enter Password" Font-Bold="True" ForeColor="Black" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="Btn_SignIn" runat="server" OnClick="Btn_SignIn_Click" Text="SIGNIN"/>
                        <asp:LinkButton ID="Link_ForgetPwd" runat="server" CausesValidation="False" ForeColor="Black" OnClick="Link_ForgetPwd_Click">FORGET PASSWORD</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:LinkButton ID="Link_SignUp" runat="server" CausesValidation="False" ForeColor="Black" OnClick="Link_SignUp_Click">SIGNUP</asp:LinkButton>
                    &nbsp;
                        <asp:LinkButton ID="Lnk_Reset_Pwd" runat="server" CausesValidation="False" ForeColor="Black" OnClick="Lnk_Reset_Pwd_Click">RESET PASSWORD</asp:LinkButton>
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>

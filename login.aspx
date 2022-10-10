<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ExamSuperDigit.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="Resources/CSS/Styles.css" rel="stylesheet" />
        <title>Login</title>
    </head>
    <body class="bg-light">
        <div class="wrapper">
            <div class="col-md-6 text-center mb-5">
                <asp:Label CssClass="h1" ID="labelTitle" runat="server" Text="Súper Dígito"></asp:Label>
            </div>
            <form class="formcontent" runat="server">
                <div>
                    <asp:TextBox CssClass="form-control" ID="TextBoxUser" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="TextBoxPassword" runat="server" placeholder="Password"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="labelError" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-6">
                        <asp:Button CssClass="btn btn-primary" ID="ButtonRegister" runat="server" Text="Registro" OnClick="ButtonRegister_Funcion"/>
                    </div>
                    <div class="col-6">
                        <asp:Button CssClass="btn btn-primary" ID="ButtonLogin" runat="server" Text="Entrar" OnClick="ButtonLogin_Funcion"/>
                    </div>
                </div>
            </form>
        </div>
        <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>

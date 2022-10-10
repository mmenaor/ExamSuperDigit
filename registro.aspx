<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="ExamSuperDigit.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="Resources/CSS/Styles.css" rel="stylesheet" />
        <title>Registro</title>
    </head>
    <body class="bg-light">
        <div class="wrapper">
            <form class="formcontent" runat="server">
                <div>
                    <asp:TextBox CssClass="form-control" ID="TextBoxUser" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="TextBoxPassword" runat="server" placeholder="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="TextBoxConfirmPass" runat="server" placeholder="Confirma Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="labelError" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary" ID="ButtonSave" runat="server" Text="Guardar" OnClick="ButtonSave_Funcion"/>
                </div>
            </form>
        </div>
        <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>
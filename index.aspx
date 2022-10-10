<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExamSuperDigit.index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="Resources/CSS/Styles.css" rel="stylesheet" />
        <title>Calcular</title>
    </head>
    <body>
        <div class="wrapper">
            <form class="formcontent" runat="server">
                <div class="number-wrapper">
                    <asp:TextBox CssClass="form-control" ID="TextBoxNumber" runat="server" placeholder="Número"></asp:TextBox>
                    <asp:TextBox CssClass="form-control" ID="TextBoxResult" runat="server" placeholder="Resultado" ReadOnly="true" Enabled="False"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="labelError" runat="server"></asp:Label>
                </div>
                <asp:Button CssClass="btn btn-primary" ID="ButtonCalculate" runat="server" Text="Calcular" OnClick="ButtonCalculate_Funcion"/>
                <asp:Label CssClass="h4" runat="server" Text="Historial"></asp:Label>
                <asp:GridView ID="DigitsTable" runat="server" class="table table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-danger form-control-sm" ID="ButtonDeleteDigit" runat="server" Text="Borrar" OnClick="ButtonDeleteDigit_Funcion"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-primary" ID="ButtonDeleteAll" runat="server" Text="Borrar Historial" OnClick="ButtonDeleteAll_Funcion"/>
            </form>
        </div>
        <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>

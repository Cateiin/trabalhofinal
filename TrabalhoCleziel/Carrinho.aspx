<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="TrabalhoCleziel.Carrinho" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrinho de Compras</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4 text-center">🛒 Seu Carrinho</h2>

            <asp:Repeater ID="rptCarrinho" runat="server" OnItemCommand="rptCarrinho_ItemCommand">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="row g-0">
                            <div class="col-md-3">
                                <img src='<%# Eval("ImagemUrl") %>' class="img-fluid rounded-start" />
                            </div>
                            <div class="col-md-9">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("NomeProduto") %></h5>
                                    <p class="card-text">R$ <%# Eval("Preco", "{0:F2}") %></p>
                                    <asp:Button runat="server" CssClass="btn btn-danger btn-sm"
                                        Text="Remover"
                                        CommandName="Remover"
                                        CommandArgument='<%# Eval("IdProduto") %>' />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <h4 class="mt-4 text-end">Total: R$ <asp:Label ID="lblTotal" runat="server" /></h4>
            <div class="text-end mt-3">
                <asp:Button runat="server" ID="btnFinalizar" Text="Finalizar Compra" CssClass="btn btn-success btn-lg" />
            </div>
        </div>
    </form>
</body>
</html>

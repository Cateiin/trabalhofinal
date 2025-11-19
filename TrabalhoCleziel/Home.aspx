<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TrabalhoCleziel.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />


    <link href="CSS/Home.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" runat="server">
        <div>

            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="Home.aspx">FastFood</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">

                            <li class="nav-item">
                                <a class="nav-link" href="#">Alimentos</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Bebidas</a>
                            </li>
                            <li id="FAvela1" runat="server" class="nav-item">
                                <a class="nav-link" href="#">Clientes</a>
                            </li>

                            <li id="FAvela2" runat="server" class="nav-item">

                                <a class="nav-link" href="ProdutosCadastrados.aspx">Produtos</a>

                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <section>

                <div class="container mt-5">
                    <div class="row g-4">
                        <!-- G-4 dá espaçamento entre colunas -->
                        <asp:Repeater ID="rptProdutos" runat="server" OnItemCommand="rptProdutos_ItemCommand">
                            <ItemTemplate>
                                <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-flex justify-content-center">
                                    <div class="card h-100 shadow-sm" style="width: 18rem;">
                                        <img src='<%# Eval("ImagemURL") %>' class="card-img-top" alt="Imagem do produto" />
                                        <div class="card-body text-center">
                                            <h5 class="card-title fw-bold"><%# Eval("NomeProduto") %></h5>
                                            <p class="card-text text-muted"><%# Eval("Descricao") %></p>
                                            <p class="card-text text-danger fw-bold">
                                                R$ <%# string.Format("{0:N2}", Eval("Preco")) %>
                                            </p>
                                        </div>
                                        <div class="card-body text-center">
                                            <asp:Button CssClass="btn btn-outline-primary w-100"
                                                Text="Mandar ao carrinho"
                                                CommandName="AddCarrinho"
                                                CommandArgument='<%# Eval("IdProduto") %>'
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </section>


            <footer class="footer mt-auto py-3 bg-body-tertiary">
                <div class="container">
                    <h3 class="text-body-secondary">FastFood</h3>
                </div>
            </footer>

        </div>
    </form>
</body>

</html>


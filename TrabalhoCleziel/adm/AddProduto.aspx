<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduto.aspx.cs" Inherits="TrabalhoCleziel.Adm.AddProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/AddProdutos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">FastFood</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">

                            <li class="nav-item">
                                <a class="nav-link" href="../Home.aspx">Início</a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link" href="Clientes.aspx">Clientes</a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link" href="#">Alimentos</a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link" href="#">Bebidas</a>
                            </li>

                        </ul>
                    </div>
                </div>
            </nav>


            <h1>Adicione as caracteristicas do produto</h1>



            <div class="card">



                <div class="card-header">
                    <h3>cadastro de Produtos</h3>
                    <p class="text-muted mb-0">Preencha os dados do produto</p>
                    <label runat="server" id="texto"></label>
                </div>

                <asp:DropDownList ID="ddlCategoria" runat="server">
                </asp:DropDownList>

                <div class="card-body px-4">
                    <div class="mb-3">
                        <label>Nome do produto</label>
                        <input type="text" id="txtNomeProduto" runat="server" class="form-control" />
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label>Descrição do produto</label>
                            <input type="text" id="txtDescricao" runat="server" class="form-control" />
                        </div>
                        <div class="col-md-6 mb-3">
                            <label>Estoque do produto</label>
                            <input type="number" id="txtEstoque" runat="server" class="form-control" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <label>Preço do produto</label>
                        <input type="number" id="txtPreco" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label>URL da imagem</label>
                        <input type="url" id="txtImgURL" runat="server" class="form-control" />
                    </div>


                    <div class="d-flex justify-content-between mt-4">
                        <input class="btn btn-outline-danger btn-lg px-4" type="reset" value="Limpar" />




                        <asp:Button CssClass="btn btn-outline-primary btn-lg px-4" Text="Cadastrar" runat="server" ID="CadastroProduto" OnClick="CadastroProduto_Click" />
                    </div>






                </div>
            </div>
        </div>
    </form>
</body>
</html>

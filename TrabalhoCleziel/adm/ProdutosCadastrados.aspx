<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdutosCadastrados.aspx.cs" Inherits="TrabalhoCleziel.Adm.ProdutosCadastrados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Produtos cadastrados</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

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
                   
                      <a class="nav-link" href="ProdutosCadastrados.aspx">Produtos</a>

                </li>


            </ul>
        </div>
    </div>
</nav>

        <div  class="container mt-4">

     
        <h2 class="mb-4">Lista de Produtos</h2>

        <table class="table table-bordered table-striped">
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Descrição</th>
                <th>Preço</th>
                <th>Estoque</th>
                <th>Imagem</th>
                <th>Ações</th>
            </tr>

            <asp:ListView ID="lvProdutos" runat="server" OnItemCommand="lvProdutos_ItemCommand">

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdProduto") %></td>
                        <td><%# Eval("NomeProduto") %></td>
                        <td><%# Eval("Descricao") %></td>
                        <td>R$ <%# Eval("Preco", "{0:N2}") %></td>
                        <td><%# Eval("Estoque") %></td>

                        <td>
                            <img src='<%# Eval("ImagemUrl") %>' width="60" height="60" style="object-fit:cover; border-radius:5px;" />
                        </td>

                        <td>

                            <asp:ImageButton ImageUrl="~/imgg/edit.svg"
                                CommandName="Editar"
                                CommandArgument='<%# Eval("IdProduto") %>'
                                runat="server" CssClass="me-2" />

                            <asp:ImageButton ImageUrl="~/imgg/delete.svg"
                                CommandName="Excluir"
                                CommandArgument='<%# Eval("IdProduto") %>'
                                OnClientClick="return confirm('Tem certeza que deseja excluir este produto?');"
                                runat="server" />

                        </td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>
        </table>


         <div runat="server" id="DivCard" visible="false" class="card">
              <asp:HiddenField ID="hfIdProduto" runat="server" />


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




             <asp:Button CssClass="btn btn-outline-primary btn-lg px-4" Text="Alterar" runat="server" ID="AlterarProduto" OnClick="AlterarProduto_Click" />
         </div>
         </div>
             </div>
               </div>
    </form>
</body>
</html>

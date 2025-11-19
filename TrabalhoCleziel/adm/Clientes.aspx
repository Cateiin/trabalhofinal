<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TrabalhoCleziel.adm.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Cadastro.css" rel="stylesheet" />
    <title></title>
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
                                <a class="nav-link" href="#">Clientes</a>
                            </li>

                            <li class="nav-item">
                               
                                  <a class="nav-link" href="ProdutosCadastrados.aspx">Produtos</a>

                            </li>


                        </ul>
                    </div>
                </div>
            </nav>

            <table class="table">
                <tr>
                    <th>Código</th>
                    <th>Nome</th>
                    <th>Data de Nascimento</th>
                    <th>Email</th>
                    <th>Ultimo Acesso</th>
                    <th>Rua</th>
                    <th>Ações</th>
                </tr>
                <asp:ListView ID="lvclientes" runat="server" OnItemCommand="lvclientes_ItemCommand" OnItemDeleting="lvclientes_ItemDeleting">

                    <ItemTemplate>

                        <tr>
                            <td><%# Eval("idUsuario") %></td>
                            <td><%# Eval("PrimeiroNome") %> <%# Eval("UltimoNome") %></td>
                            <td><%# Eval("DataNasc") %></td>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("UltimoAcesso") %></td>
                            <td><%# Eval("Rua") %></td>

                            <td>



                                <asp:ImageButton ImageUrl="~/imgg/edit.svg"
                                    CommandName="Editar" CommandArgument='<%# Eval("idUsuario") %>'
                                    runat="server" ID="imbEdit" />


                                <asp:ImageButton Visible="true" ImageUrl="~/imgg/delete.svg"
                                    runat="server" ID="imgBloquear"
                                    CommandName="Bloquear"
                                    CommandArgument='<%# Eval("idUsuario") %>'
                                    OnClientClick="confirm('Tem certeza que deseja Bloquear este Usuario?');" />

                            </td>

                        </tr>

                    </ItemTemplate>
                </asp:ListView>
            </table>





            <div runat="server" id="DivCard" visible="false" class="card">
                <asp:HiddenField ID="hfIdUsuario" runat="server" />

                <div class="card-header">
                    <h3>Cadastro de Usuário</h3>
                    <p class="text-muted mb-0">Preencha seus dados abaixo</p>
                </div>
                <div class="card-body px-4">


                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label>Primeiro Nome</label>
                            <input type="text" id="txtNome" runat="server" class="form-control" placeholder="Ex: João" />

                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Sobrenome</label>
                            <input type="text" id="txtUltimoNome" runat="server" class="form-control" placeholder="Ex: Silva" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <label>Data de Nascimento</label>
                        <input type="date" id="txtDataNasc" runat="server" class="form-control" />
                    </div>

                    <div class="mb-3">
                        <label>E-mail</label>
                        <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="exemplo@email.com" />
                    </div>
                    <div class="mb-3">
                        <label>Rua</label>
                        <input type="text" id="txtRua" runat="server" class="form-control" placeholder="Sebastião Alves de Lima" />
                    </div>

                    <div class="mb-3">
                        <label>Login</label>
                        <input type="text" id="txtLogin" runat="server" class="form-control" placeholder="Nome de usuário" />
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label>Senha</label>
                            <input type="password" id="txtSenha" runat="server" class="form-control" />
                        </div>

                        <div class="col-md-6 mb-3">
                            <label>Repetir Senha</label>
                            <input type="password" id="txtRepetirSenha" runat="server" class="form-control" />
                        </div>
                    </div>

                    <div class="d-flex justify-content-between mt-4">
                        <input class="btn btn-outline-danger btn-lg px-4" type="reset" value="Limpar" />


                        <asp:Button CssClass="btn btn-outline-primary btn-lg px-4" Text="Alterar" ID="Alterar"
                            runat="server" OnClick="Alterar_Click" />

                    </div>

                    <label id="lblMensagem" runat="server"></label>
                </div>





            </div>
        </div>
    </form>
</body>
</html>

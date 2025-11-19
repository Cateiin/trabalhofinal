<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="TrabalhoCleziel.Adm.Cadastrar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Cadastro - FastFood</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />

    <link href="../CSS/Cadastro.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-header">
                <h3>Cadastro de Usuário</h3>
                <p class="text-muted mb-0">Preencha seus dados abaixo</p>
            </div>
            <div class="card-body px-4">
                <div class="mb-3">
                    <label>Perfil Usuário</label>
                    <asp:DropDownList runat="server" ID="ddlPerfil" CssClass="form-select"></asp:DropDownList>
                </div>

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


                    <asp:Button CssClass="btn btn-outline-primary btn-lg px-4" Text="Cadastrar" ID="btnCadastrar"
                        runat="server" OnClick="btnCadastrar_Click" />

                </div>

                <label id="lblMensagem" runat="server"></label>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

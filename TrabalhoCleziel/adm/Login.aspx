<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrabalhoCleziel.Adm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
   
    <link href="../CSS/Cadastro.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
             <div class="card">
     <div class="card-header">
         <h3>Login de Usuário</h3>
         <p class="text-muted mb-0">Preencha seus dados abaixo</p>

         </div>

                  <div class="card-body px-4">
           <div class="mb-3">
                <label>Login</label>
                <input type="text" id="txtLogin" runat="server" class="form-control" placeholder="Nome de usuário" />
            </div>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <label>Senha</label>
                    <input type="password" id="txtSenha" runat="server" class="form-control" />
                </div>

            </div>

            <div class="d-flex justify-content-between mt-4">
                <input class="btn btn-outline-danger btn-lg px-4" type="reset" value="Limpar" />   
                      
                      <asp:Button CssClass="btn btn-outline-primary btn-lg px-4" id="btnLogar" Text="logar" runat="server" OnClick="btnLogar_Click" />    
            </div>

                      <label runat="server" id="texto"></label>
                 </div>
                 </div>

    </form>
</body>
</html>

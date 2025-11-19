using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoCleziel.Adm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {

            
            string Login = txtLogin.Value;
            string Senha = txtSenha.Value;

            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Senha))
            {
                Mensagem("Informe um login e senha válidos");
                return;
            }

            Usuario usuario = UsuarioDAO.SelecionarUsuario(Login);

            if (usuario == null)
            {
                Mensagem("Usuário não encontrado");
                return;
            }

            string senhaCriptografada = Sha1Helper.GerarHashSha1(Senha);

            if (senhaCriptografada.Equals(usuario.Senha))
            {
                FormsAuthentication.SetAuthCookie(usuario.Login, true);
                UsuarioDAO.SetUltimoAcesso(usuario);

                if (usuario.PerfilUsuarioID == 1)
                {

                    Mensagem("bem vindo cliente");
                    Response.Redirect("~/Home.aspx");
                }
                if (usuario.PerfilUsuarioID == 2)
                {
                    Mensagem("bem vindo administrador");
                    Response.Redirect("~/adm/AddProduto.aspx");
                }

                txtLogin.Value = "";
                txtSenha.Value = "";

            }
            else
            {
                Mensagem("Senha incorreta");
            }
        }

        private static void Mensagem(string texto)
        {
            texto = "Informe Informe um login e senha válido";
            return;
        }
    }
}
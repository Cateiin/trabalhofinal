using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoCleziel.Adm
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<PerfilUsuario> Perfis = PerfilUsuarioDAO.ListarPerfis();
                AtualizarDDLPerfis(Perfis);

            }

        }

        private void AtualizarDDLPerfis(List<PerfilUsuario> Perfis)
        {
            ddlPerfil.DataSource = Perfis;
            ddlPerfil.DataTextField = "descricao";
            ddlPerfil.DataValueField = "IdPerfil";

            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, "Selecione");

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int idperfil = ddlPerfil.SelectedIndex;
            string senha = txtSenha.Value;
            string repetirSenha = txtRepetirSenha.Value;

            if (!senha.Equals(repetirSenha))
            {
                return;
            }

            if (!int.TryParse(ddlPerfil.SelectedValue, out idperfil))
            {
                return;
            }

            Usuario user = new Usuario();
            user.PerfilUsuarioID = idperfil;
            user.PrimeiroNome = txtNome.Value;
            user.UltimoNome = txtUltimoNome.Value;

            user.Senha = Sha1Helper.GerarHashSha1(senha);
            user.Email = txtEmail.Value;

            user.Login = txtLogin.Value;
            user.DataNasc = DateTime.Parse(txtDataNasc.Value);
            user.Rua = txtRua.Value;



            string Mensagem = UsuarioDAO.CadastrarUsuario(user);
            lblMensagem.InnerText = Mensagem;
            LimparCampos();
            Response.Redirect("~/adm/Login.aspx");
        }

        private void LimparCampos()
        {
            txtSenha.Value = "";
            txtRepetirSenha.Value = "";
            txtNome.Value = "";
            txtUltimoNome.Value = "";

            txtDataNasc.Value = "";
            txtEmail.Value = "";
            txtLogin.Value = "";
            ddlPerfil.SelectedIndex = 0;
        }
    }
}
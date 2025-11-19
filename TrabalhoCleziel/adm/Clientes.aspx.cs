using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabalhoCleziel.Adm;

namespace TrabalhoCleziel.adm
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<PerfilUsuario> Perfis = PerfilUsuarioDAO.ListarPerfis();
                AtualizarlvUsuario(UsuarioDAO.ListarUsuario());
               
            }
        }


        

        private void AtualizarlvUsuario(List<Usuario> usuarios)
        {
            List<PerfilUsuario> Perfis = PerfilUsuarioDAO.ListarPerfis();
            
            lvclientes.DataSource = usuarios;
            lvclientes.DataBind();
            
        }

        protected void lvclientes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Desbloquear")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);

                Usuario usuario = UsuarioDAO.BuscarID(idUsuario);

                if (usuario != null)
                {
                    int idPerfil = usuario.PerfilUsuarioID;

                    string mensagem = PerfilUsuarioDAO.AlterarStatus(idPerfil, true);

                    lblMensagem.InnerText = mensagem;

                    AtualizarlvUsuario(UsuarioDAO.ListarUsuario());
                }
            }

            if (e.CommandName == "Bloquear")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);

                // chama o método excluir
                string mensagem = UsuarioDAO.Excluir(idUsuario);

                // mostra mensagem na tela
                lblMensagem.InnerText = mensagem;

                // atualiza listview
                AtualizarlvUsuario(UsuarioDAO.ListarUsuario());
            }



            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Usuario usuario = UsuarioDAO.BuscarID(id);

                if (usuario != null) {
                    DivCard.Visible = true;

                    hfIdUsuario.Value = usuario.IdUsuario.ToString(); // <-- IMPORTANTE !!!

                   
                    txtNome.Value = usuario.PrimeiroNome;
                    txtUltimoNome.Value = usuario.UltimoNome;
                    //txtDataNasc.Value = Convert.ToString("yyyy-MM-dd"+usuario.DataNasc);
                    txtDataNasc.Value = usuario.DataNasc?.ToString("yyyy-MM-dd") ?? "";

                    txtEmail.Value = usuario.Email;
                    txtLogin.Value = usuario.Login;
                    txtRua.Value = usuario.Rua;

                }
            }
        }



        protected void lvclientes_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
           

        }



        protected void Alterar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfIdUsuario.Value);
            Usuario usuario = UsuarioDAO.BuscarID(id);

            usuario.PrimeiroNome = txtNome.Value;
            usuario.UltimoNome = txtUltimoNome.Value;
            usuario.DataNasc = DateTime.Parse(txtDataNasc.Value);
            usuario.Email = txtEmail.Value;
            usuario.Rua = txtRua.Value;
            usuario.Login = txtLogin.Value;

            string mensagem = UsuarioDAO.Alterar(usuario);

            lblMensagem.InnerText = mensagem;

            AtualizarlvUsuario(UsuarioDAO.ListarUsuario());
            DivCard.Visible = false;
        }
    }
}
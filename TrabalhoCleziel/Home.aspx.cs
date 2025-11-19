using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabalhoCleziel.Adm;

namespace TrabalhoCleziel
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuarios = UsuarioDAO.VerUsuarioLogado();
                List<Produto> produtos = ProdutoDAO.ListarProdutos();
                CarregarProdutos(produtos);
                VerificarUsuario(usuarios);


            }
        }

        private void VerificarUsuario(Usuario usuarios)
        {

            if (usuarios == null)
            {
                // ninguém logado → esconder menus
                FAvela1.Visible = false;
                FAvela2.Visible = false;
                return;
            }

            if (usuarios.PerfilUsuarioID == 1)
            {
                FAvela1.Visible = false;
                FAvela2.Visible = false;
            }

            if (usuarios.PerfilUsuarioID == 2)
            {
                FAvela1.Visible = true;
                FAvela2.Visible = true;
            }
        }

        private void CarregarProdutos(List<Produto> produtos)
        {
            if (produtos != null && produtos.Count > 0)
            {
                rptProdutos.DataSource = produtos;
                rptProdutos.DataBind();
            }
            else
            {
                // Caso não tenha produtos, você pode mostrar algo opcionalmente
                rptProdutos.DataSource = null;
                rptProdutos.DataBind();
            }


        }

        protected void rptProdutos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddCarrinho")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Produto produto = ProdutoDAO.BuscarPorId(id);

                List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();
                carrinho.Add(produto);

                Session["Carrinho"] = carrinho;

                Response.Redirect("Carrinho.aspx");
            }
        }

    }
}
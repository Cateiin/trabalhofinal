using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TrabalhoCleziel
{
    public partial class Carrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarCarrinho();
        }

        private void CarregarCarrinho()
        {
            var carrinho = Session["Carrinho"] as List<Produto>;

            if (carrinho != null)
            {
                rptCarrinho.DataSource = carrinho;
                rptCarrinho.DataBind();

                decimal total = 0;
                foreach (var item in carrinho)
                    total += (decimal)item.Preco;

                lblTotal.Text = total.ToString("F2");
            }
        }

        protected void rptCarrinho_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remover")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var carrinho = Session["Carrinho"] as List<Produto>;

                carrinho.RemoveAll(p => p.IdProduto == id);
                Session["Carrinho"] = carrinho;

                CarregarCarrinho();
            }
        }

       
    }
}

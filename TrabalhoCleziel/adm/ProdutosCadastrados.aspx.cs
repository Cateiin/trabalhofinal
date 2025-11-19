using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace TrabalhoCleziel.Adm
{
    public partial class ProdutosCadastrados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AtualizarLista();
                CarregarCategorias();
            }
        }

        private void AtualizarLista()
        {
            lvProdutos.DataSource = ProdutoDAO.ListarProdutos();
            lvProdutos.DataBind();
        }

        private void CarregarCategorias()
        {
            ddlCategoria.DataSource = CategoriaDAO.Listarcategorias();
            ddlCategoria.DataTextField = "NomeCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
        }

        protected void lvProdutos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Produto produto = ProdutoDAO.BuscarPorId(id);

                if (produto != null)
                {
                    DivCard.Visible = true;

                    // PREENCHE O CARD COM OS DADOS DO PRODUTO
                    hfIdProduto.Value = produto.IdProduto.ToString();
                    txtNomeProduto.Value = produto.NomeProduto;
                    txtDescricao.Value = produto.Descricao;
                    txtEstoque.Value = produto.Estoque.ToString();
                    txtPreco.Value = produto.Preco?.ToString("0.00", CultureInfo.InvariantCulture) ?? "";
                    txtImgURL.Value = produto.ImagemUrl;

                    // SELECIONA A CATEGORIA DO PRODUTO
                    ddlCategoria.SelectedValue = produto.idCategoria.ToString();
                }
            }

            if (e.CommandName == "Excluir")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                string msg = ProdutoDAO.Excluir(id);

                // opcional: mostrar mensagem no card
                // texto.InnerText = msg;

                AtualizarLista();
            }
        }

        protected void AlterarProduto_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfIdProduto.Value);

            Produto produtoAlterado = new Produto()
            {
                IdProduto = id,
                NomeProduto = txtNomeProduto.Value,
                Descricao = txtDescricao.Value,
                Estoque = int.Parse(txtEstoque.Value),
                Preco = decimal.Parse(txtPreco.Value),
                ImagemUrl = txtImgURL.Value,
                idCategoria = int.Parse(ddlCategoria.SelectedValue)
            };

            string msg = ProdutoDAO.Atualizar(produtoAlterado);

            texto.InnerText = msg;

            AtualizarLista();
            DivCard.Visible = false;
        }
    }
}

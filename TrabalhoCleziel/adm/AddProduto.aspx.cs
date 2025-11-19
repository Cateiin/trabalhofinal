using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoCleziel.Adm
{
    public partial class AddProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){

              List<Categoria> categorias = CategoriaDAO.Listarcategorias();
              AtualizarDDLCategoria(categorias);
            }
        }

        private void AtualizarDDLCategoria(List<Categoria> categorias)
        {
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "NomeCategoria";
            ddlCategoria.DataValueField = "IdCategoria";

            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "Selecione");
        }

        protected void CadastroProduto_Click(object sender, EventArgs e)
        {

            if (ddlCategoria.SelectedIndex == 0)
            {
                texto.InnerText = "Selecione uma categoria válida.";
                return;
            }

            Produto produtos = new Produto();

            produtos.idCategoria = int.Parse(ddlCategoria.SelectedValue);
            produtos.Descricao = txtDescricao.Value;
            produtos.NomeProduto = txtNomeProduto.Value;
            produtos.Preco = decimal.Parse(txtPreco.Value);
            produtos.Estoque = Convert.ToInt32(txtEstoque.Value);
            produtos.ImagemUrl = txtImgURL.Value;
            if (produtos.Estoque > 0)
            {
                produtos.Disponibilidade = true;
            }
            else
            {
                produtos.Disponibilidade= false;
            }
             

            string Mensagem = ProdutoDAO.CadastrarProdutos(produtos);
            texto.InnerText = Mensagem;

            Limpar();
        }


        private void Limpar()
        {
            txtDescricao.Value = "";
            txtEstoque.Value = "";
            txtImgURL.Value = "";
            txtNomeProduto.Value = "";
            txtPreco.Value = "";
        }
    }
}
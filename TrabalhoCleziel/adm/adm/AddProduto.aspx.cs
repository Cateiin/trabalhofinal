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
              List<Categoria> categorias = new List<Categoria>();
        }

        protected void CadastroProduto_Click(object sender, EventArgs e)
        {

            Produto produtos = new Produto();

            produtos.Descricao = txtDescricao.Value;
            produtos.NomeProduto = txtNomeProduto.Value;
            produtos.Preco = decimal.Parse(txtPreco.Value);
            produtos.Estoque = Convert.ToInt32(txtEstoque.Value);
            produtos.ImagemUrl = txtImgURL.Value;

            string Mensagem = ProdutoDAO.CadastrarUsuario(produtos);
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
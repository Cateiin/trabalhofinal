using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace TrabalhoCleziel
{
    internal class ProdutoDAO
    {
        public static Produto BuscarPorId(int id)
        {
            using (var ctx = new DBFastFoodEntities())
            {
                return ctx.Produtoes.FirstOrDefault(p => p.IdProduto == id);
            }
        }


        internal static string CadastrarProdutos(Produto produtos)
        {
            string mensagem = "";
            try
            {
                if (produtos == null)
                {
                    return "Produto Vazio";
                }

                using (var ctx = new DBFastFoodEntities())
                {
                    ctx.Produtoes.Add(produtos);
                    ctx.SaveChanges();

                    mensagem = "Produto cadastrado com sucesso";
                }
            }
            catch (Exception ex)
            {
                foreach (var eve in ((DbEntityValidationException)ex).EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        mensagem += $"{ve.PropertyName} - {ve.ErrorMessage}<br>";
                    }
                }
            }

            return mensagem;
        }

        public static string Excluir(int id)
        {
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    var produto = ctx.Produtoes.FirstOrDefault(p => p.IdProduto == id);

                    if (produto == null)
                        return "Produto não encontrado.";

                    ctx.Produtoes.Remove(produto);
                    ctx.SaveChanges();

                    return $"Produto '{produto.NomeProduto}' excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao excluir: " + ex.Message;
            }
        }

        // ATUALIZAR PRODUTO
        public static string Atualizar(Produto produtoAlterado)
        {
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    var produto = ctx.Produtoes.FirstOrDefault(p => p.IdProduto == produtoAlterado.IdProduto);

                    if (produto == null)
                        return "Produto não encontrado.";

                    // Atualizando campos
                    produto.NomeProduto = produtoAlterado.NomeProduto;
                    produto.Descricao = produtoAlterado.Descricao;
                    produto.Preco = produtoAlterado.Preco;
                    produto.Estoque = produtoAlterado.Estoque;
                    produto.ImagemUrl = produtoAlterado.ImagemUrl;
                    produto.idCategoria = produtoAlterado.idCategoria;

                    ctx.SaveChanges();

                    return "Produto atualizado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar: " + ex.Message;
            }
        }

        internal static List<Produto> ListarProdutos()
        {
			List<Produto> lista = null;
			try
			{
				using (var ctx = new DBFastFoodEntities())
				{

					lista = ctx.Produtoes.OrderBy(p => p.IdProduto).ToList();
                }


			}
			catch (Exception)
			{

				
			}
            return lista;
        }
    }
}
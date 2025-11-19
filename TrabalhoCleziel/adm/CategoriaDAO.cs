using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoCleziel.Adm
{
    internal class CategoriaDAO
    {
        internal static List<Categoria> Listarcategorias()
        {
            List<Categoria> lista = null;
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    lista = ctx.Categorias.OrderBy(p => p.NomeCategoria).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }

        
    }
}
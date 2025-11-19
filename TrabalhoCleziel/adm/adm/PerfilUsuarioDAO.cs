using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoCleziel.Adm
{
    internal class PerfilUsuarioDAO
    {
        internal static List<PerfilUsuario> ListarPerfis()
        {
            List<PerfilUsuario> lista = null;
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    lista = ctx.PerfilUsuarios.OrderBy(p => p.Descricao).ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }
    }
}
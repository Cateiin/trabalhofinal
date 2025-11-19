using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoCleziel.Adm
{
    internal class PerfilUsuarioDAO
    {
        internal static PerfilUsuario BuscarID(int idperfil)
        {
            PerfilUsuario perfilUsuario = null;

            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    perfilUsuario = ctx.PerfilUsuarios.FirstOrDefault(c => c.IdPerfil == idperfil);
                }

            }
            catch (Exception ex)
            {


            }

            return perfilUsuario;
        }
        public static string AlterarStatus(int idPerfil, bool novoStatus)
        {
            try
            {
                using (DBFastFoodEntities ctx = new DBFastFoodEntities())
                {
                    PerfilUsuario perfil = ctx.PerfilUsuarios.FirstOrDefault(p => p.IdPerfil == idPerfil);

                    if (perfil == null)
                        return "Perfil não encontrado!";

                    perfil.Status = novoStatus;
                    ctx.SaveChanges();

                    return "Status alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

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
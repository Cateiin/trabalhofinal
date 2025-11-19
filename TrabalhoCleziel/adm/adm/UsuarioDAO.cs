using System;
using System.Linq;

namespace TrabalhoCleziel.Adm
{
    internal class UsuarioDAO
    {
        internal static string CadastrarUsuario(Usuario user)
        {
            string mensagem = "";
            try
            {
                if (user == null)
                {
                    return "Usuário Vazio";
                }

                using (var ctx = new DBFastFoodEntities())
                {
                    ctx.Usuarios.Add(user);
                    ctx.SaveChanges();

                    mensagem = "Usuário cadastrado com sucesso";
                }
            }
            catch (Exception ex)
            {



                mensagem = ex.Message;
            }
            return mensagem;
        }

        internal static Usuario SelecionarUsuario(string login)
        {
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.Login == login);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        internal static void SetUltimoAcesso(Usuario user)
        {
            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    var usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == user.IdUsuario);
                    usuario.UltimoAcesso = DateTime.Now;
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
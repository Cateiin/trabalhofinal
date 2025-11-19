using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using TrabalhoCleziel;

namespace TrabalhoCleziel.Adm
{
    internal class UsuarioDAO
    {

        internal static List<Usuario> ListarUsuario()
        {
            try
            {
                using (DBFastFoodEntities ctx = new DBFastFoodEntities())
                {
                    // Carrega o perfil JUNTO com o usuário
                    ctx.Configuration.LazyLoadingEnabled = false;

                    var usuarios = ctx.Usuarios
                        .Include("PerfilUsuario")
                        .OrderBy(u => u.IdUsuario)
                        .ToList();

                    return usuarios;
                }
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }

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

        internal static string Excluir(int id)
        {
            string mensagem = "";

            try
            {

                DBFastFoodEntities ctx = new DBFastFoodEntities();
                Usuario usuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);

                if (usuario != null)
                {
                    ctx.Usuarios.Remove(usuario);
                    ctx.SaveChanges();
                    mensagem = "O usuário " + usuario.PrimeiroNome + " " + usuario.UltimoNome + "foi excluída com sucesso";
                }
                else
                {
                    mensagem = "O usuário  não existe no sistema!";
                }

            }
            catch (Exception erro)
            {

                mensagem = erro.Message;
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

        internal static Usuario BuscarID(int id)
        {
            Usuario usuario = null;

            try
            {
                using (var ctx = new DBFastFoodEntities())
                {
                    usuario = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
                }

            }
            catch (Exception ex)
            {


            }

            return usuario;
        }

        public static string Alterar(Usuario usuarioAlterado)
        {
            try
            {
                using (DBFastFoodEntities db = new DBFastFoodEntities())
                {
                    Usuario usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioAlterado.IdUsuario);

                    if (usuario == null)
                        return "Usuário não encontrado.";

                    // Atualiza campos
                    usuario.PrimeiroNome = usuarioAlterado.PrimeiroNome;
                    usuario.UltimoNome = usuarioAlterado.UltimoNome;
                    usuario.Email = usuarioAlterado.Email;
                    usuario.DataNasc = usuarioAlterado.DataNasc;
                    usuario.Login = usuarioAlterado.Login;
                    usuario.Rua = usuarioAlterado.Rua;

                    db.SaveChanges();

                    return "Usuário alterado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao alterar: " + ex.Message;
            }
        }


        //        List<PerfilUsuario> lista = null;
        //            try
        //            {
        //                using (var ctx = new DBFastFoodEntities())
        //                {
        //                    lista = ctx.PerfilUsuarios.OrderBy(p => p.Descricao).ToList();
        //    }
        //}
        //            catch (Exception ex)
        //            {
        //            }

        //            return lista;
        //        }



        internal static Usuario VerUsuarioLogado()
        {
          
            return HttpContext.Current.Session["UsuarioLogado"] as Usuario;
        }

    
}
}
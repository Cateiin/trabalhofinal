using System.Security.Cryptography;
using System.Text;

namespace TrabalhoCleziel.Adm
{
    public class Sha1Helper
    {
        public static string GerarHashSha1(string entrada)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                // Converte a string de entrada para um array de bytes
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(entrada);

                // Calcula o hash da entrada
                byte[] bytesHash = sha1.ComputeHash(bytesEntrada);

                // Converte o array de bytes do hash para uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytesHash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
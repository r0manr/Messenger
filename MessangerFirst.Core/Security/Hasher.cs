using System.Security.Cryptography;
using System.Text;

namespace MessangerFirst.Core.Security
{
    /// <summary>
    /// Класс шифрования
    /// </summary>
    public class Hasher : IHasher
    {
        /// <summary>
        /// Шифрование строки
        /// </summary>
        /// <param name="original">Строка для шифрования</param>
        /// <returns>Строка в зашифрованном виде</returns>
        public string Encrypt(string original)
        {

            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(original);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Сравнивание строки с её хэшем
        /// </summary>
        /// <param name="s">Входная строка</param>
        /// <param name="hash">Хэш правильной строки</param>
        /// <returns>Результат сравнения</returns>
        public bool CompareStringToHash(string s, string hash)
        {
            string result = Encrypt(s);
            return result == hash;
        }
    }
}

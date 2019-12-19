using System;
using System.Security.Cryptography;
using System.Text;

namespace Web.Extensions
{
    /// <summary>
    /// 加密类
    /// </summary>
    public static class EncryptorExtention
    {
        public static string Md5Encrypt(this string password, int length = 32)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;
            HashAlgorithm provider = CryptoConfig.CreateFromName("MD5") as HashAlgorithm;

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            if (provider == null) return string.Empty;
            byte[] hashValue = provider.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            switch (length)
            {
                case 16://16位密文是32位密文的9到24位字符
                    for (int i = 4; i < 12; i++)
                        result.Append(hashValue[i].ToString("x2"));
                    break;
                case 32:
                    for (int i = 0; i < 16; i++)
                        result.Append(hashValue[i].ToString("x2"));
                    break;
                default:
                    foreach (byte i in hashValue)
                    {
                        result.Append(i.ToString("x2"));
                    }
                    break;
            }
            return result.ToString();
        }

        public static string Sha1Encrypt(this string password, Encoding encode)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] bytes = encode.GetBytes(password);

            byte[] hash = sha1.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();

            foreach (byte b in hash)
            {
                result.AppendFormat("{0:X2}", b);
            }
            return result.ToString().ToLower();
        }
    }
}
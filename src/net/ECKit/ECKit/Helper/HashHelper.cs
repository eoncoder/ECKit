using System;
using System.Text;

namespace com.eoncoder.ECKit.Common
{
    public class HashHelper
    {
        public static string Sha1With(string text)
        {
            return Sha1(Encoding.UTF8.GetBytes(text));
        }

        public static string Sha1(byte[] data)
        {
            var v_crypto = System.Security.Cryptography.SHA1.Create();
            byte[] hash = v_crypto.ComputeHash(data);
            string delimitedHexHash = BitConverter.ToString(hash);
            string hexHash = delimitedHexHash.Replace("-", "");
            return hexHash.ToLower();
        }

        public static uint Md5With(string text)
        {
            return Md5(Encoding.UTF8.GetBytes(text));
        }

        public static uint Md5(byte[] data)
        {
            var v_crypto = System.Security.Cryptography.MD5.Create();
            byte[] hash = v_crypto.ComputeHash(data);
            return BitConverter.ToUInt32(hash, 0);
        }
    }
}

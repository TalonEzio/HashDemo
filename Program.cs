using System;
using System.Security.Cryptography;
using System.Text;

namespace HashDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Mời nhập password: ");
            string password = Console.ReadLine();

            Console.WriteLine($"MD5: {HashString(password, new MD5CryptoServiceProvider())}");
            Console.WriteLine($"SHA1: {HashString(password, new SHA1CryptoServiceProvider())}");
            Console.WriteLine($"SHA256: {HashString(password, new SHA256CryptoServiceProvider())}");
            Console.WriteLine($"SHA384: {HashString(password, new SHA384CryptoServiceProvider())}");

            Console.ReadLine();
        }

        public static string HashString(string password, HashAlgorithm hashProvider)
        {
            StringBuilder hashPasswordBuilder = new StringBuilder();
            byte[] bytes = hashProvider.ComputeHash(Encoding.Unicode.GetBytes(password));

            foreach (var b in bytes)
            {
                hashPasswordBuilder.Append(b.ToString("x2"));//x2: decimal 2 chars. ex: e -> 0e
            }
            return hashPasswordBuilder.ToString();
        }
    }
}
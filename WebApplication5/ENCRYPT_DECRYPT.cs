using System;

namespace WebApplication5
{
    public class ENCRYPT_DECRYPT
    {
        public static string Encrypt(string Password)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Password);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        public static string Decrypt(string encrypted)
        { 
            byte[] b;
            string decrypted;
            b = System.Convert.FromBase64String(encrypted);
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decrypted;
        }
    }
}
﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.Security
{
    /// <summary>
    /// Criptografia
    /// </summary>
    public static class Crypto
    {
        #region [ AES ]

        /// <summary>
        /// Criptografia AES
        /// </summary>
        public static class AES
        {
            #region [ Decrypt ]

            /// <summary>
            /// Método para desencriptar um texto em AES
            /// </summary>
            /// <param name="Buffer">Buffer</param>
            /// <param name="text">Texto para desencriptar</param>
            /// <returns></returns>
            public static byte[] Decrypt(byte[] Buffer, string text)
            {
                System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();

                byte[] decrypted = null;
                try
                {
                    byte[] temp = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
                    AES.Key = temp;
                    AES.Mode = System.Security.Cryptography.CipherMode.ECB;

                    System.Security.Cryptography.ICryptoTransform DESDecrypter = AES.CreateDecryptor();

                    decrypted = DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length);
                }
                catch
                { }

                return decrypted;
            }

            #endregion

            #region [ Encrypt ]

            /// <summary>
            /// Método para encriptar em AES
            /// </summary>
            /// <param name="plaintext"></param>
            /// <param name="text">Texto para encriptar</param>
            /// <returns></returns>
            public static string Encrypt(string plaintext, string text)
            {
                return System.Text.Encoding.UTF8.GetString(Encrypt(System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext), text));
            }

            /// <summary>
            /// Método para encriptar em AES
            /// </summary>
            /// <param name="plaintext"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static byte[] Encrypt(byte[] plaintext, string text)
            {
                /* 
                * Block Length: 128bit
                * Block Mode: ECB
                * Data Padding: Padded by bytes which Asc() equal for number of padded bytes (done automagically)
                * Key Padding: 0x00 padded to multiple of 16 bytes
                * IV: None
                */
                byte[] key = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
                System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
                AES.BlockSize = 128;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                AES.Key = key;

                System.Security.Cryptography.ICryptoTransform encryptor = AES.CreateEncryptor();
                MemoryStream mem = new MemoryStream();
                System.Security.Cryptography.CryptoStream cryptStream = new System.Security.Cryptography.CryptoStream(mem, encryptor,
                System.Security.Cryptography.CryptoStreamMode.Write);

                cryptStream.Write(plaintext, 0, plaintext.Length);
                cryptStream.FlushFinalBlock();

                byte[] cypher = mem.ToArray();

                cryptStream.Close();
                cryptStream = null;
                encryptor.Dispose();
                AES = null;

                return cypher;
            }

            #endregion
        }

        #endregion

        #region [ Base64 ]

        /// <summary>
        /// Criptografia Base 64
        /// </summary>
        public static class Base64
        {
            #region [ Decrypt ]

            /// <summary>
            /// Método para desencriptar um texto em Base64
            /// </summary>
            /// <param name="text">Texto para desencriptar</param>
            /// <returns>Texto desencriptado</returns>
            public static string Decrypt(string text)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(text);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }

            #endregion

            #region [ Encrypt ]

            /// <summary>
            /// Método para encriptar um texto em Base 64
            /// </summary>
            /// <param name="text">Texto para encriptar</param>
            /// <returns>Texto encriptado</returns>
            public static string Encrypt(string text)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
                return System.Convert.ToBase64String(plainTextBytes);
            }

            #endregion
        }

        #endregion

        #region [ MD5 ]

        /// <summary>
        /// Criptografia MD5
        /// </summary>
        public static class Md5
        {
            #region [ Encrypt ]

            /// <summary>
            /// Método para encriptar um texto em MD5
            /// </summary>
            /// <param name="text">Texto para criptografar em MD5</param>
            /// <returns>Texto criptografado</returns>
            public static string Encrypt(string text)
            {
                StringBuilder sb = new StringBuilder();
                MD5 md5 = MD5.Create();

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hash = md5.ComputeHash(inputBytes);

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                return sb.ToString();
            }

            #endregion
        }

        #endregion

        #region [ SHA-1 ]

        /// <summary>
        /// Criptografia SHA-1
        /// </summary>
        public static class Sha1
        {
            #region [ Encrypt ]

            /// <summary>
            /// Método para encriptar texto em SHA-1
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Encrypt(string text, bool lowercase = true)
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        sb.Append(b.ToString("X2"));
                    }

                    if (lowercase)
                    {
                        return sb.ToString().ToLower();
                    }
                    else
                    {
                        return sb.ToString().ToUpper();
                    }
                }
            }

            #endregion
        }

        #endregion

        #region [ SHA-256 ]

        /// <summary>
        /// Criptografia SHA-256
        /// </summary>
        public static class Sha256
        {
            #region [ Encrypt ]

            /// <summary>
            /// Método para encriptar texto em SHA-256
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Encrypt(string text)
            {
                StringBuilder Sb = new StringBuilder();

                using (SHA256 hash = SHA256Managed.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(text));

                    foreach (Byte b in result)
                        Sb.Append(b.ToString("x2"));
                }

                return Sb.ToString();
            }

            #endregion
        }

        #endregion
    }
}

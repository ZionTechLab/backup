using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Digiteq_Logic
{
   public class clsCript
    {
        public static string Encrypt(string plainText)
        {
            string sReturn = "";
            try
            {
                string passPhrase = "&%#@?,:*";
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
                byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, "SHA1", 2);//hash mame "sha1" can be "MD5"
                byte[] keyBytes = password.GetBytes(256 / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();

                sReturn = Convert.ToBase64String(cipherTextBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sReturn;
        }

        public static string Decrypt(string cipherText)
        {
            string sReturn = "";
            try
            {
                string passPhrase = "&%#@?,:*";
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
                byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, "SHA1", 2);
                byte[] keyBytes = password.GetBytes(256 / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                sReturn=  Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sReturn;
        }
    }
}

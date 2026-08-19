using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorizationServer.Model;
using AuthorizationServer.Model.DBEntity;
using AuthorizationServer.Model.ViewModel;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AuthorizationServer.Provider
{
    public class UserProvider
    {
        public UserView ValidateUserAccount(string uname ,string password)
        {
            UserView userDetail = null;
            ////password = Encrypt(password);
            ////////var val1 = ComputeHash(password);
            ////////var isSHatrue = VerifyHash(password, val1);
            uname = Encrypt(uname);
            try
            {            
                using (IUserManageUnitOfWork<ConUserDetail> uof = new UserManageUnitOfWork<ConUserDetail>())
                {                    //encript / decrypt machanisum
                                     ////userDetail =(from US in uof.Reposotery.GetDetails().Where(ex => ex.UsmLogin == uname && ex.UsmPass == password && ex.Active=="Y")
                                     ////        select new UserView
                                     ////        {
                                     ////            UserID = US.UsmId,
                                     ////            Username=US.UsmLogin,
                                     ////            Password=US.UsmPass,

                    ////            UserLoginName = US.PreferredName,                            

                    ////    }).FirstOrDefault(); 


                    userDetail = (from US in uof.Reposotery.GetDetails().Where(ex => ex.UsmLogin == uname && ex.Active == "Y")
                                  select new UserView
                                  {
                                      UserID = US.UsmId,
                                      Username = US.UsmLogin,
                                      Password = US.UsmPass,

                                      UserLoginName = US.PreferredName,

                                  }).FirstOrDefault();
                }

              
            }
            catch (Exception ex)
            {
                return null;
            }

            return userDetail;
        }


        #region SHA1 Hashing
        public static string ComputeHash(string plainText)
        {
            Random random = new Random();
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            HashAlgorithm hash = new SHA1Managed();
            // If salt is not specified, generate it on the fly.
            byte[] saltBytes;
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            int saltSize = random.Next(minSaltSize, maxSaltSize);
            saltBytes = new byte[saltSize];
            rng.GetNonZeroBytes(saltBytes);

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
        
            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

          
            return hashValue;
        }


        public static bool VerifyHash(string plainText,string hashValue)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;                    
            hashSizeInBits = 160;             
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText);

            
            return (hashValue == expectedHashString);
        }


        #endregion


        #region Encription with AES
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KuhlektFTP
{
    //var x = Protect.ToSecureString(@"ORIGINALUNPWS");
    //Console.WriteLine(x);
    //var x2 = Protect.EncryptString(x);
    //Console.WriteLine(x2); //ENCRYPTED UN PWS

    //var y2 = Protect.DecryptString(x2);
    //Console.WriteLine(y2);
    //var y = Protect.ToInsecureString(y2);
    //Console.WriteLine(y);
    public class Protect
    {
        static byte[] entropy = Encoding.Unicode.GetBytes("_TLM_");

        public static string EncryptString(System.Security.SecureString input)
        {
            SecureString input1 = input;
            #pragma warning disable CA1416 // Validate platform compatibility
            byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(ToInsecureString(input1)), entropy, DataProtectionScope.CurrentUser);
            #pragma warning restore CA1416 // Validate platform compatibility
            return Convert.ToBase64String(encryptedData);
        }

        public static System.Security.SecureString DecryptString(string encryptedData)
        {
            try
            {
            #pragma warning disable CA1416 // Validate platform compatibility
                byte[] decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), entropy, DataProtectionScope.CurrentUser);
            #pragma warning restore CA1416 // Validate platform compatibility
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }

        public static string GetKey(string encryptedkey)
        {
            return encryptedkey;
            //var y2 = Protect.DecryptString(encryptedkey);
            //var y = Protect.ToInsecureString(y2);
            //return y;  
        }
    }
}

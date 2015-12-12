using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrayGmailNotifier
{
    public static class PasswordEncryptionUtils
    {
        public static string EncryptedFileName = "data.cry";
        private static int bytesWritten;

        public static void EncryptPassword(string password)
        {
            using (FileStream fStream = new FileStream(EncryptedFileName, FileMode.OpenOrCreate))
            {
                byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(password);
                bytesWritten = PasswordEncryptionUtils.EncryptDataToStream(toEncrypt, DataProtectionScope.CurrentUser, fStream);
            }
        }

        public static string GetDecryptedPassword()
        {
            byte[] decryptedData;
            using(FileStream fStream = new FileStream(EncryptedFileName, FileMode.Open))
            {
                decryptedData = PasswordEncryptionUtils.DecryptDataFromStream(DataProtectionScope.CurrentUser, fStream);
            }

            return UnicodeEncoding.ASCII.GetString(decryptedData);
        }

        #region private

        private static int EncryptDataToStream(byte[] Buffer, DataProtectionScope Scope, Stream S)
        {
            if (Buffer.Length <= 0)
                throw new ArgumentException("Buffer");
            if (Buffer == null)
                throw new ArgumentNullException("Buffer");
            if (S == null)
                throw new ArgumentNullException("S");

            int length = 0;

            // Encrypt the data in memory. The result is stored in the same same array as the original data.
            byte[] encryptedData = ProtectedData.Protect(Buffer, null, Scope);

            // Write the encrypted data to a stream.
            if (S.CanWrite && encryptedData != null)
            {
                S.Write(encryptedData, 0, encryptedData.Length);
                length = encryptedData.Length;
            }

            // Return the length that was written to the stream. 
            return length;
        }

        private static byte[] DecryptDataFromStream(DataProtectionScope Scope, Stream S)
        {
            if (S == null)
                throw new ArgumentNullException("S");

            byte[] inBuffer = new byte[S.Length];
            byte[] outBuffer;

            // Read the encrypted data from a stream.
            if (S.CanRead)
            {
                S.Read(inBuffer, 0, Convert.ToInt32(S.Length));
                outBuffer = ProtectedData.Unprotect(inBuffer, null, Scope);
            }
            else
            {
                throw new IOException("Could not read the stream.");
            }

            return outBuffer;
        }

        #endregion
    }
    
}

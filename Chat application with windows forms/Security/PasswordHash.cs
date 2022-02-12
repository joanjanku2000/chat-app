
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Chat_application_with_windows_forms.Security
{
    class PasswordHash
    {
		private static string GetRandomSalt()
		{
			return BCrypt.Net.BCrypt.GenerateSalt(12);
		}

		public static string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
		}

		public static bool ValidatePassword(string password, string correctHash)
		{
			Console.WriteLine("Got psw from db {0}", correctHash);
			Console.WriteLine("GIven psw is {0}", password);
			return BCrypt.Net.BCrypt.Verify(password, correctHash);
		}
	}

  public class DiffieHellman
    {
        private Aes aes = null;
        private ECDiffieHellmanCng diffieHellman = null;
        private readonly byte[] publicKey;

        public DiffieHellman()
        {
            this.aes = new AesCryptoServiceProvider();

            this.diffieHellman = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };


            this.publicKey = this.diffieHellman.PublicKey.ToByteArray();
        }

        public byte[] PublicKey
        {
            get
            {
                return this.publicKey;
            }
        }

        public byte[] IV
        {
            get
            {
                return this.aes.IV;
            }
        }

        public byte[] Encrypt(byte[] publicKey, string secretMessage)
        {
            byte[] encryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key); // "Common secret"
            Console.WriteLine("Encryption publc key {0}", Encoding.ASCII.GetString(publicKey));
            Console.WriteLine("Encryption derved key {0}", Encoding.ASCII.GetString(derivedKey));
            this.aes.Key = derivedKey;

            using (var cipherText = new MemoryStream())
            {
                using (var encryptor = this.aes.CreateEncryptor())
                {
                    using (var cryptoStream = new CryptoStream(cipherText, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] ciphertextMessage = Encoding.UTF8.GetBytes(secretMessage);
                        cryptoStream.Write(ciphertextMessage, 0, ciphertextMessage.Length);
                    }
                }

                encryptedMessage = cipherText.ToArray();
            }

            return encryptedMessage;
        }

      

        public string Decrypt(byte[] publicKey, byte[] encryptedMessage, byte[] iv)
        {
            string decryptedMessage;
            var key = CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob);
            var derivedKey = this.diffieHellman.DeriveKeyMaterial(key);
            Console.WriteLine("Decription publc key {0}", Encoding.ASCII.GetString(publicKey));
            Console.WriteLine("Decription derved key {0}", Encoding.ASCII.GetString(derivedKey));
            this.aes.Key = derivedKey;
            this.aes.IV = iv;
            this.aes.Padding = PaddingMode.Zeros;

            using (var plainText = new MemoryStream())
            {
                using (var decryptor = this.aes.CreateDecryptor())
                {
                    using (var cryptoStream = new CryptoStream(plainText, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
                    }
                }

                decryptedMessage = Encoding.UTF8.GetString(plainText.ToArray());
            }

            return decryptedMessage;
        }
    }

    class RsaEncryption
    {
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        static public void generatePublicKeyAndPrivateKeyAndSaveItToLocation(long userID, string location)
        {

            string pkey_file_name = "public_k_" + userID;
            string priv_file_name = "privat_K_" + userID;

            string filepath_public = location + "/" + pkey_file_name;
            string filepath_private = location + "/" + priv_file_name;

            if (File.Exists(filepath_public)) { 
                Console.WriteLine("File {0} exists, not overrding", filepath_public);
                return;
            }

            var csp = new RSACryptoServiceProvider(2048);
            var privKey = csp.ExportParameters(true);
            var pubKey = csp.ExportParameters(false);

            string pubKeyString;
            string privKeyString;

            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                var pw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                xs.Serialize(pw, privKey);
                //get the string from the stream
                pubKeyString = sw.ToString();
                privKeyString = pw.ToString();
            }

         

            File.WriteAllText(filepath_public, pubKeyString);          
            File.WriteAllText(filepath_private, privKeyString);

         
            File.SetAttributes(filepath_public, FileAttributes.ReadOnly);
            File.SetAttributes(filepath_private, FileAttributes.ReadOnly);
        }

        static public RSAParameters getRsaParameter(string key)
        { 
            var sr = new System.IO.StringReader(key);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            return  (RSAParameters) xs.Deserialize(sr);
        }


        static public string readKeyFromFile(string location)
        {
            return File.ReadAllText(location);
        }

        static public RSAParameters getPublicKey(string path, long id)
        {
            string pkey_file_name = "public_k_" + id;
            string filepath_public = path + "/" + pkey_file_name;

            return getRsaParameter(readKeyFromFile(filepath_public));
        }

        static public RSAParameters getPrivateKey(string path, long id)
        {

            string priv_file_name = "privat_K_" + id;
            string filepath_private = path + "/" + priv_file_name;

            return getRsaParameter(readKeyFromFile(filepath_private));
        }
        static public string RsaEncrypt(string message, RSAParameters publicKey)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);

            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(message);
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
            var cypherText = Convert.ToBase64String(bytesCypherText);

            return cypherText;
        }


        static public string RsaDecrypt(string encryptedMessage , RSAParameters privKey)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privKey);

            byte[]  bytesCypherText = Convert.FromBase64String(encryptedMessage);

            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            return System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

        }

       
    
}
}

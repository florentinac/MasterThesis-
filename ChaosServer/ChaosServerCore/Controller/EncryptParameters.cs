using ChaosServerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChaosServerCore.Controller
{
    class EncryptParameters<T>
    {
        private RSAParameters publicKey;
        private T plainText;
        private RSACryptoServiceProvider csp = new RSACryptoServiceProvider();

        public EncryptParameters(RSAParameters publicKey, T plainText)
        {
            this.publicKey = publicKey;
            this.plainText = plainText;
        }

        public string Encrypt()
        {
            csp.ImportParameters(publicKey);

            var bytesPlainTextData = Encoding.Unicode.GetBytes(GetPlainTextString());
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
            var cypherText = Convert.ToBase64String(bytesCypherText);

            return cypherText;
        }

        public string GetPlainTextString()
        {
            return XmlHelper.Serialize(plainText);
        }

    }
}

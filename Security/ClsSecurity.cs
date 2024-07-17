using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Security
{
    public class ClsSecurity
    {
        public static string Encriptar(string text)
        {
            UnicodeEncoding Code = new UnicodeEncoding();
            byte[] textToByte = Code.GetBytes(text);
            SHA1CryptoServiceProvider SH = new SHA1CryptoServiceProvider();
            byte[] byteH = SH.ComputeHash(textToByte);
            return Convert.ToBase64String(byteH);
        }

    }
}

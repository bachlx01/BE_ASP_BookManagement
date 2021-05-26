using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Shopping.Common
{
    public class Encryptor
    {
        public static string CreateMD5(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            //create new instance of md5
            MD5 md5 = new MD5CryptoServiceProvider();

            //convert the input text to array of bytes
            md5.ComputeHash(Encoding.Default.GetBytes(input));
            byte[] result = md5.Hash;
            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < result.Length; i++)
            {
                returnValue.Append(result[i].ToString("x2"));
            }

            // return hexadecimal string
            return returnValue.ToString();
        }
    }
}
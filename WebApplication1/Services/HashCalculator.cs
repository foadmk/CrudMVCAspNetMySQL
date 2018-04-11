using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class HashCalculator
    {
        public static string GenerateMD5(string value)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}

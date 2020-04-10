using System.Security.Cryptography;
using System.Text;

namespace Shared.Layer
{
    public static class ExtensionMethods
    {
        public static string ToMd5(this string s)
        {
            var hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(s));

            foreach (var b in bytes)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}

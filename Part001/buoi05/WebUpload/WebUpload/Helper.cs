using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace WebUpload
{
    public class Helper
    {
        public static string RanDomString(int len)
        {
            char[] arr = new char[len];
            string pattern = "tqekoijf26672arqeiikkmad887263ifa15";
            Random random = new Random();
            for (int i = 0; i < len; i++)
                arr[i] = pattern[random.Next(pattern.Length)];

            return string.Join(string.Empty, arr);
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace CryptographyMentoring
{
    public class KeyIdentifier
    {
        public string? IdentifyCorrectKey()
        {
            // Your SHA256 hash
            string correctHash = "f28fe539655fd6f7275a09b7c3508a3f81573fc42827ce34ddf1ec8d5c2421c3";
            // Your given keys
            string[] keys = new string[]
            {
            "68544020247570407220244063724074",
            "54684020247570407220244063724074",
            "54684020247570407220244063727440"
            };

            string? correctKey = null;
            using (SHA256 sha256 = SHA256.Create())
            {
                foreach (string key in keys)
                {
                    byte[] keyBytes = StringToByteArray(key); // Convert HEX string to byte array
                    string hash = BitConverter.ToString(sha256.ComputeHash(keyBytes)).Replace("-", "").ToLower();
                    if (hash == correctHash)
                    {
                        correctKey = key;
                        break;
                    }
                }
            }
            return correctKey;
        }

        public static byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
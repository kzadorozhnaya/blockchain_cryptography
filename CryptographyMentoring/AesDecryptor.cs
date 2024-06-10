using System.Security.Cryptography;

public class AesDecryptor
{
    public string? DecryptMessage(string correctKey)
    {
        byte[] cipherTextBytes = Convert.FromBase64String("876b4e970c3516f333bcf5f16d546a87aaeea5588ead29d213557efc1903997e");
        byte[] ivBytes = Convert.FromBase64String("656e6372797074696f6e496e74566563");
        byte[] keyBytes = Convert.FromBase64String(correctKey);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = ivBytes;
        aes.Mode = CipherMode.CBC;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream msDecrypt = new MemoryStream(cipherTextBytes);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        string plaintext = srDecrypt.ReadToEnd();
        return plaintext;
    }
}
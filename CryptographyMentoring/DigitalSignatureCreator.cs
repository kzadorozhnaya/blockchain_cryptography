using System.Security.Cryptography;
using System.Text;

public class DigitalSignatureCreator
{
    public string CreateSignature((ECDsaCng privateKey, string publicKey) keyPair, string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        byte[] signature;

        using (ECDsaCng eCDsa = keyPair.privateKey)
        {
            signature = eCDsa.SignData(data, HashAlgorithmName.SHA256);
        }

        return Convert.ToBase64String(signature);
    }
}
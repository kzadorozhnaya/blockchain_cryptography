using System.Security.Cryptography;
using System.Text;

public class EccKeyPairGenerator
{
    public (ECDsaCng, string) GenerateKeyPair()
    {
        ECDsaCng eCDsa = new ECDsaCng();
        eCDsa.HashAlgorithm = CngAlgorithm.Sha256;
        string publicKey = Convert.ToBase64String(eCDsa.Key.Export(CngKeyBlobFormat.EccPublicBlob));
        return (eCDsa, publicKey);
    }
}
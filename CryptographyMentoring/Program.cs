using CryptographyMentoring;

public class Program
{
    static void Main(string[] args)
    {
        // Identify the correct key
        var keyIdentifier = new KeyIdentifier();
        var correctKey = keyIdentifier.IdentifyCorrectKey();
        var decryptedMessage = string.Empty;

        // Decrypt the AES-128 message
        var aesDecryptor = new AesDecryptor();
        try
        {
            decryptedMessage = aesDecryptor.DecryptMessage(correctKey);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        // Generate an ECC key pair
        var eccKeyPairGenerator = new EccKeyPairGenerator();
        var keyPair = eccKeyPairGenerator.GenerateKeyPair();  // it contains both private and public keys

        // Create a digital signature
        var digitalSignatureCreator = new DigitalSignatureCreator();
        var digitalSignature = digitalSignatureCreator.CreateSignature(keyPair, decryptedMessage);

        Console.WriteLine($"Correct symmetric key: {correctKey}");
        Console.WriteLine($"Asymmetric public key: {keyPair.Item2}");
        Console.WriteLine($"Digital Signature: {digitalSignature}");
    }
}
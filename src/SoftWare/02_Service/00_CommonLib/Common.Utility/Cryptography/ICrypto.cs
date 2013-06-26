using System;

namespace Common.Utility.Cryptography
{
    public interface ICrypto
    {
        string Decrypt(string encryptedBase64ConnectString);
        string Encrypt(string plainConnectString);
    }
}


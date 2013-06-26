using System;

namespace Common.Utility.Cryptography
{
    public static class CryptoManager
    {
        public static ICrypto GetCrypto(CryptoAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case CryptoAlgorithm.DES:
                    return new Sym_DES();

                case CryptoAlgorithm.RC2:
                    return new Sym_RC2();

                case CryptoAlgorithm.Rijndael:
                    return new Sym_Rijndael();

                case CryptoAlgorithm.TripleDES:
                    return new Sym_TripleDES();

                case CryptoAlgorithm.RSA:
                    return new Asym_RSA();

                case CryptoAlgorithm.MD5:
                    return new Hash_MD5();

                case CryptoAlgorithm.SHA1:
                    return new Hash_SHA1();
            }
            return null;
        }
    }
}


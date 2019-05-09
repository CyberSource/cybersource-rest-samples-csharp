using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CyberSource.Api;
using CyberSource.Model;
using FlexServerSDK.Exception;
using FlexServerSDK.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class TokenizeCard
    {
        public static void Run()
        {
            var generateKeyResult = GenerateKey.Run();
            var keyId = generateKeyResult.KeyId;
            var derFormat = generateKeyResult.Der.Format;
            var derAlgo = generateKeyResult.Der.Algorithm;
            var derPublicKey = generateKeyResult.Der.PublicKey;

            var requestObj = new TokenizeRequest
            (
                KeyId: keyId,
                CardInfo: new Flexv1tokensCardInfo
                (
                    CardExpirationYear: "2031",
                    CardNumber: "5555555555554444",
                    CardType: "002",
                    CardExpirationMonth: "03"
                )
            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TokenizationApi(clientConfig);

                var result = apiInstance.Tokenize(requestObj);
                Console.WriteLine(result);

                var flexPublicKey = new FlexPublicKey(keyId, new FlexServerSDK.Model.DerPublicKey(derFormat, derAlgo, derPublicKey), null);
                var flexToken = new FlexToken()
                {
                    keyId = result.KeyId,
                    token = result.Token,
                    maskedPan = result.MaskedPan,
                    cardType = result.CardType,
                    timestamp = (long)result.Timestamp,
                    signedFields = result.SignedFields,
                    signature = result.Signature,
                    discoverableServices = result.DiscoverableServices
                };

                IDictionary<string, string> postParameters = new Dictionary<string, string>();
                postParameters["signedFields"] = flexToken.signedFields;
                postParameters["signature"] = flexToken.signature;
                postParameters["cardType"] = flexToken.cardType;
                postParameters["keyId"] = flexToken.keyId;
                postParameters["maskedPan"] = flexToken.maskedPan;
                postParameters["token"] = flexToken.token;
                postParameters["timestamp"] = Convert.ToString(flexToken.timestamp);

                var tokenVerificationResult = Verify(flexPublicKey, postParameters);
                Console.WriteLine("TOKEN VERIFICATION : " + tokenVerificationResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }

        public static bool Verify(FlexPublicKey flexKey, IDictionary<string, string> postParameters)
        {
            var publicKeyStr = flexKey.der.publicKey;
            RSAParameters publicKey = DecodePublicKey(Convert.FromBase64String(publicKeyStr)).ExportParameters(false);

            string signedFields = (string)postParameters["signedFields"];
            StringBuilder sb = new StringBuilder();

            foreach (string k in signedFields.Split(','))
            {
                sb.Append(',');
                sb.Append(postParameters[k]);
            }

            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
            }

            string signedValues = sb.ToString();
            string signature = (string)postParameters["signature"];
            return ValidateTokenSignature(publicKey, signedValues, signature);
        }

        private static bool ValidateTokenSignature(RSAParameters publicKey, string signedFields, string signature)
        {
            bool success = false;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] bytesToVerify = Encoding.UTF8.GetBytes(signedFields);
                byte[] signedBytes = Convert.FromBase64String(signature);

                try
                {
                    rsa.ImportParameters(publicKey);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    throw new FlexSDKInternalException("Error validating signature", e);
                }
                catch (System.Exception e)
                {
                    throw new FlexSDKInternalException("Error validating signature", e);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

            return success;
        }

        private static RSACryptoServiceProvider DecodePublicKey(byte[] x509key)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] seqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(x509key);
            BinaryReader binr = new BinaryReader(mem);    // wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {
                twobytes = binr.ReadUInt16();

                // data read as little endian order (actual data order for Sequence is 30 81)
                if (twobytes == 0x8130)
                {
                    binr.ReadByte();    // advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();   // advance 2 bytes
                }
                else
                {
                    return null;
                }

                seq = binr.ReadBytes(15);       // read the Sequence OID

                // make sure Sequence for OID is correct
                if (!CompareBytearrays(seq, seqOID))
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();

                // data read as little endian order (actual data order for Bit String is 03 81)
                if (twobytes == 0x8103)
                {
                    binr.ReadByte();    // advance 1 byte
                }
                else if (twobytes == 0x8203)
                {
                    binr.ReadInt16();   // advance 2 bytes
                }
                else
                {
                    return null;
                }

                bt = binr.ReadByte();

                // expect null byte next
                if (bt != 0x00)
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();

                // data read as little endian order (actual data order for Sequence is 30 81)
                if (twobytes == 0x8130)
                {
                    binr.ReadByte();    // advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16();   // advance 2 bytes
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                byte lowbyte = 0x00;
                byte highbyte = 0x00;

                // data read as little endian order (actual data order for Integer is 02 81)
                if (twobytes == 0x8102)
                {
                    lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                }
                else if (twobytes == 0x8202)
                {
                    highbyte = binr.ReadByte(); // advance 2 bytes
                    lowbyte = binr.ReadByte();
                }
                else
                {
                    return null;
                }

                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   // reverse byte order since asn.1 key uses big endian order
                int modsize = BitConverter.ToInt32(modint, 0);

                byte firstbyte = binr.ReadByte();
                binr.BaseStream.Seek(-1, SeekOrigin.Current);

                if (firstbyte == 0x00)
                {
                    // if first byte (highest order) of modulus is zero, don't include it
                    binr.ReadByte();    // skip this null byte
                    modsize -= 1;   // reduce modulus buffer size by 1
                }

                byte[] modulus = binr.ReadBytes(modsize);   // read the modulus bytes

                // expect an Integer for the exponent data
                if (binr.ReadByte() != 0x02)
                {
                    return null;
                }

                int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                byte[] exponent = binr.ReadBytes(expbytes);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                RSAParameters rsaKeyInfo = new RSAParameters();
                rsaKeyInfo.Modulus = modulus;
                rsaKeyInfo.Exponent = exponent;
                rsa.ImportParameters(rsaKeyInfo);
                return rsa;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}

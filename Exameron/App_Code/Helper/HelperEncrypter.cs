using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class HelperEncrypter
{

    private readonly string AdminUrlApi;
    private readonly byte[] bKey;
    private readonly byte[] bIV;

    public HelperEncrypter()
    {
        bKey = Convert.FromBase64String(ConfigurationManager.AppSettings["KeyEncrypt"]);
        bIV = Convert.FromBase64String(ConfigurationManager.AppSettings["VetorEncrypt"]);
    }

    public string Encrypt(string text)
    {
        try
        {
            if (!string.IsNullOrEmpty(text))
            {
               
                byte[] bText = new UTF8Encoding().GetBytes(text);
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 256;

                MemoryStream mStream = new MemoryStream();
                CryptoStream encryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateEncryptor(bKey, bIV),
                    CryptoStreamMode.Write);

                encryptor.Write(bText, 0, bText.Length);
                encryptor.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao criptografar", ex);
        }
    }

    public string Decrypt(string text)
    {
        try
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] bText = Convert.FromBase64String(text);

                Rijndael rijndael = new RijndaelManaged();

                rijndael.KeySize = 256;

                MemoryStream mStream = new MemoryStream();

                CryptoStream decryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateDecryptor(bKey, bIV),
                    CryptoStreamMode.Write);

                decryptor.Write(bText, 0, bText.Length);
                decryptor.FlushFinalBlock();
                UTF8Encoding utf8 = new UTF8Encoding();
                return utf8.GetString(mStream.ToArray());
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao descriptografar", ex);
        }
    }

}
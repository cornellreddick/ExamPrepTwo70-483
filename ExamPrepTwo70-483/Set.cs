using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ExamPrepTwo70_483
{
    //class Set<T>
    //{
    //    //A naive set implemention
    //    private List<T> list = new List<T>();

    //    public void Insert(T item)
    //    {
    //        if (!Contains(item))
    //        {
    //            list.Add(item);
    //        }
    //    }

    //    public bool Contains(T item)
    //    {
    //        foreach (T member  in list)
    //        {
    //            if (member.Equals(item))
    //            {
    //                return true;
    //            }

    //        }
    //        return false;
    //    }
    //}

    //A set implementation that uses hashing
    class Set<T>
    {
        private List<T>[] buckets = new List<T>[100];
        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }
        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }
        private int GetBucket(int hashcode)
        {
            // A Hash code can be negative. To make sure that you end up with a positive
            // value cast the value to an unsigned int. The unchecked block makes sure that
            // you can cast a value larger then int to an int safely.
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }
        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            return false;
        }
        //Signing and verifying data with a certificate
        public static void SignAndVerify()
        {
            string textToSign ="Test paragraph";
            byte[] signature = Sign(textToSign,"cn = WouterDeKort");
            // Uncomment this line to make the verification step fail
            // signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }
        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }
        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash,
            CryptoConfig.MapNameToOID("SHA1"),
            signature);
        }
        private static byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }
        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore",
            StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }

        //Getting the value of a SecureString
        public static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
       
    }
}

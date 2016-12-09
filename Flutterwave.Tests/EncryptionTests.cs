using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flutterwave.Utilities;

namespace Flutterwave.Tests
{
    [TestClass]
    public class EncryptionTests
    {
        private string _encryptKey = "molly-wobbles";

        private enum EncType
        {
            Encryption,
            Decryption
        }

        private string getRandomString()
        {
            Random r = new Random();
            string sample = "1234567890 abcdefghijlk !@#$%^&*()_+=-/.,';\"][{}";
            string ret = Enumerable.Repeat<Func<char>>(() => sample.ElementAt(r.Next(sample.Length)), 12).Select(fn => fn()).Select(c => c.ToString()).Aggregate((s1, s2) => s1 + s2);
            return ret;
        }

        private string getRandomHash()
        {
            string input = getRandomString();
            string ret = testEncryption(input, _encryptKey, true);
            return ret;
        }

        private string testEncryption(string input, string key, bool useHash, EncType type = EncType.Encryption)
        {
            string _word = type == EncType.Encryption ? "En" : "De";
            string _withWord = useHash ? "With" : "Without";

            string ret = "";
            if (type == EncType.Encryption) ret = Encrypt.TripleDESEncrypt(input, key, true);
            else ret = Encrypt.TripleDESDecrypt(input, key, true);
            Console.WriteLine($"{_word}crypt {_withWord} Hashing: {input} => {ret}");
            Assert.IsNotNull(input);
            Assert.AreNotEqual(input, "");
            Assert.IsNotNull(ret);
            Assert.AreNotEqual(ret, "");
            return ret;
        }

        [TestMethod]
        [Description("Test that Triple DES Encryption Works (does not fail) with Hashing")]
        public void testThatTripleDESEncryptWorksWithHashing() => testEncryption(getRandomString(), _encryptKey, true);

        [TestMethod]
        [Description("Test that Triple DES Decryption Works (does not fail) with Hashing")]
        public void testThatTripleDESDecryptWorksWithHashing() => testEncryption(getRandomHash(), _encryptKey, true, EncType.Decryption);

        [TestMethod]
        [Description("Test that Triple DES Encryption Works (does not fail) without Hashing")]
        public void testThatTripleDESEncryptWorksWithoutHashing() => testEncryption(getRandomString(), _encryptKey, false);

        [TestMethod]
        [Description("Test that Triple DES Decryption Works (does not fail) without Hashing")]
        public void testThatTripleDESDecryptWorksWithoutHashing() => testEncryption(getRandomHash(), _encryptKey, false, EncType.Decryption);

        [TestMethod]
        [Description("Test that Triple DES is consistent with Hashing both ways")]
        public void testThatTripleDESWorksWithHashingBothWays()
        {
            string testString1 = getRandomString();
            string ret = testEncryption(testString1, _encryptKey, true);
            string testString2 = testEncryption(ret, _encryptKey, true, EncType.Decryption);
            Assert.AreEqual(testString1, testString2);
        }

        [TestMethod]
        [Description("Test that Triple DES is consistent without Hashing both ways")]
        public void testThatTripleDESWorksWithoutHashingBothWays()
        {
            string testString1 = getRandomString();
            string ret = testEncryption(testString1, _encryptKey, false);
            string testString2 = testEncryption(ret, _encryptKey, false, EncType.Decryption);
            Assert.AreEqual(testString1, testString2);
        }
    }
}

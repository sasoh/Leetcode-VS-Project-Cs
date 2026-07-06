using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ConsoleApp
{
    public class SimpleCipher
    {
        public SimpleCipher()
        {
            var r = new Random();
            var sb = new StringBuilder();
            for (int i = 0, lim = r.Next(100, 120); i < lim; ++i)
            {
                sb.Append((char)('a' + r.Next(0, 26)));
            }
            Key = sb.ToString();
        }

        public SimpleCipher(string key) => Key = key;

        public string Key { get; private set; }

        public string Encode(string plaintext) => Process(plaintext, (c, i) => (char)(c + i));

        public string Decode(string ciphertext) => Process(ciphertext, (c, i) => (char)(c - i));

        private string Process(string input, Func<char, int, char> operation)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < input.Length; ++i)
            {
                var keyIndex = i % Key.Length;
                var keyOffset = (Key[keyIndex] - 'a');
                var newChar = operation(input[i], keyOffset);
                const char diff = (char)('z' - 'a' + 1);
                if (newChar < 'a') {
                    newChar += diff;
                }
                else  if (newChar > 'z') {
                    newChar -= diff;
                }                

                sb.Append(newChar);
            }
            return sb.ToString();
        }
    }

    public class Program
    {

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            var sut = new SimpleCipher("iamapandabear");
            var a = "qayaeaagaciai";
            var b = sut.Encode("iamapandabear");

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}
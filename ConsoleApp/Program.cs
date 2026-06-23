using System;
using System.Text;
namespace ConsoleApp
{
    public class SpiralMatrix
    {
        public static int[,] GetMatrix(int size)
        {
            var r = new int[size, size];

            var top = 0;
            var bottom = size - 1;
            var left = 0;
            var right = size - 1;
            var num = 1;
            while (top <= bottom && left <= right)
            {
                for (var i = left; i <= right; ++i)
                {
                    r[top, i] = num++;
                }
                top++;

                for (var i = top; i <= bottom; ++i)
                {
                    r[i, right] = num++;
                }
                right--;

                for (var i = right; i >= left; --i) {
                    r[bottom, i] = num++;
                }
                bottom--;

                for (var i = bottom; i >= top; --i) {
                    r[i, left] = num++;
                }
                left++;
            }

            return r;
        }

        public static string PrintMatrix(int[,] m)
        {
            var sb = new StringBuilder();
            int length = m.GetLength(0);
            for (var i = 0; i < length; ++i) {
                for (var j = 0; j < length; ++j) {
                    var num = m[i, j];
                    sb.AppendFormat("{0,2}", num);
                    if (j < length - 1) { 
                        sb.Append(", ");
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }


    public class Program
    {
        private static void T1()
        {
            var i = SpiralMatrix.GetMatrix(4);
            Console.WriteLine(SpiralMatrix.PrintMatrix(i));
        }

        private static void RunTests()
        {
            Console.WriteLine("Running tests");

            T1();

            Console.WriteLine("Finished tests");
        }

        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}
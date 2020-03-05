using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework0205
{
    class Program
    {

        static void Main(string[] args)
        {
            {
                //var stack = new Stack<int>();

                //stack.Push(12);
                //stack.Push(24);
                //stack.Push(36);

                //int a = stack.Pop();
                //int b = stack.Pop();

                //Console.WriteLine( a + b );
            }

            string[] array1 = new string[] { "Chocolete", "Cake", "Book", "Cup", "Rain", "Apple" };
            int[] array2 = new int[] {59, 17, 20, 15, 17, 92, 5, 12 };


            new Arrays().Sort<string>(array1);
            new Arrays().Sort<int>(array2);


            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i] + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            Console.ReadLine();
        }
    }
}

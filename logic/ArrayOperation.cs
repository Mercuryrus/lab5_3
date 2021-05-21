using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace lab5_3.logic
{
    class ArrayOperation
    {
        public static void ArrayOper()
        {
            //string read = File.ReadAllText(@"../../../logic/read.txt");
            using(FileStream reader = File.OpenRead(@"../../../logic/read.txt"))
            {
                byte[] readbyte = new byte[reader.Length];
                reader.Read(readbyte, 0, readbyte.Length);
                string strarr = System.Text.Encoding.Default.GetString(readbyte);
                int[] array = strarr.Split(' ').Select(x => int.Parse(x)).ToArray();

                Console.WriteLine("Прочитаный массив:");
                foreach(int j in array)
                {
                    Console.Write(" " + j);
                }
                
                
                int mult = 1;
                for (int i = 0; i < array.Length; i += 2)
                {
                    mult *= array[i];
                }
                Console.WriteLine($"\n\nПроизведение четных элементов массива:\n{mult}");

                int firstZero = Array.IndexOf(array, 0);
                int lastZero = Array.LastIndexOf(array, 0);
                int sum = 0;
                for (int i = firstZero; i<lastZero; i++)
                {
                    sum += array[i];
                }
                Console.WriteLine($"\nСумма между первым и последним нулевым эл-м:\n{sum}");

                Array.Sort(array);
                Array.Reverse(array);
                Console.WriteLine("\nОтсортированный массив:");
                foreach (int j in array)
                {
                    Console.Write(" " + j);
                }

            }

            
            
        }

    }
}

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
        public static int[] array = Array.Empty<int>();
        public static string strarr;
        public static void ArrayReadTxt()
        {
            using (FileStream reader = File.OpenRead(@"../../../logic/read.txt"))
            {
            byte[] readbyte = new byte[reader.Length];
            reader.Read(readbyte, 0, readbyte.Length);
            strarr = System.Text.Encoding.Default.GetString(readbyte); 
            }

            if (strarr.Any(c=>char.IsLetter(c)))
            {
                Console.WriteLine(" В файле какая-то дичь. Не буду я с ней рабоать");
            }
            else
            {
                array = strarr.Split(' ').Select(x => int.Parse(x)).ToArray();
            }
            Console.WriteLine(" Прочитаный массив: ");
            foreach (int j in array)
            {
                Console.Write(" " + j);
            }
        }
        public static string MultiplyEvenArray()
        {
            int mult = 1;
            for (int i = 0; i < array.Length; i += 2)
            {
                mult *= array[i];
            }
            return $"\n\n Произведение четных элементов массива:\n {mult}";
        }

        public static string SumZeroElem()
        {
            if (array.Count(x=>x.Equals(0)) >= 2)
            { 
                int firstZero = Array.IndexOf(array, 0);
                int lastZero = Array.LastIndexOf(array, 0);
                int sum = 0;

                for (int i = firstZero; i<lastZero; i++)
                {
                    sum += array[i];
                }

                return $"\n Сумма между первым и последним нулевым эл-м:\n {sum}";
            }
            else
            {
                return"\n Массив не содержит элементов равных 0\n Или их меньше двух";
            }
        }
        public static void SortArray()
        {
            array = array.OrderBy(x => -x.CompareTo(0)).ToArray();
            Console.WriteLine("\n Отсортированный массив:");
            foreach (int j in array)
            {
                Console.Write(" " + j);
            }
        }   
    }
}

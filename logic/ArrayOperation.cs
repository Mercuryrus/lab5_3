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
            
            if (strarr.All(c => char.IsNumber(c)))
            {
                Console.WriteLine(" В файле какая-то дичь. Не буду я с ней рабоать");
            }
            else
            {
                array = strarr.Split(' ').Select(x => int.Parse(x)).ToArray();
                Console.WriteLine(" Прочитаный массив: ");
                foreach (int j in array)
                {
                    Console.Write(" " + j);
                }   
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
            if (array.Count(x => x.Equals(0)) >= 2)
            {
                int firstZero = Array.IndexOf(array, 0);
                int lastZero = Array.LastIndexOf(array, 0);
                int sum = 0;

                for (int i = firstZero; i < lastZero; i++)
                {
                    sum += array[i];
                }

                return $"\n Сумма между первым и последним нулевым эл-м:\n {sum}";
            }
            else
            {
                return "\n Массив не содержит элементов равных 0\n Или их меньше двух";
            }
        }
        public static int[] SortArray()
        {
            array = array.OrderBy(x => -x.CompareTo(0)).ToArray();
            Console.WriteLine("\n Отсортированный массив:");
            return array;

        }
        public static void WriteInTxt()
        {
            int[] posArr = array.Where(a => a > 0).ToArray();
            string posStr = string.Join(' ', Array.ConvertAll(posArr, a => a.ToString()));

            int[] zrArr = array.Where(a => a == 0).ToArray();
            string zeroStr = string.Join(' ', Array.ConvertAll(zrArr, a => a.ToString()));

            int[] ngArr = array.Where(a => a < 0).ToArray();
            string negStr = string.Join(' ', Array.ConvertAll(ngArr, a => a.ToString()));


            if (posArr.GroupBy(x => x).Select(y => y).Where(z => z.Count() > 1).Count()>0)
            { 
                using (FileStream writePos = new FileStream(@"../../../logic/output/positiveREP.txt", FileMode.OpenOrCreate))
                {
                    byte[] positive = System.Text.Encoding.Default.GetBytes(posStr);
                    writePos.Write(positive, 0, positive.Length);
                    Console.WriteLine($"\n\n{posStr}");
                }
            }
            else
            {
                using (FileStream writePos = new FileStream(@"../../../logic/output/positive.txt", FileMode.OpenOrCreate))
                {
                    byte[] positive = System.Text.Encoding.Default.GetBytes(posStr);
                    writePos.Write(positive, 0, positive.Length);
                    Console.WriteLine(posStr);
                }

            }
            if (zrArr.GroupBy(x => x).Select(y => y).Where(z => z.Count() > 1).Count()>0)
            {
                using (FileStream writeZero = new FileStream(@"../../../logic/output/zeroREP.txt", FileMode.OpenOrCreate))
                {
                    byte[] zero = System.Text.Encoding.Default.GetBytes(zeroStr);
                    writeZero.Write(zero, 0, zero.Length);
                    Console.WriteLine(zeroStr);
                }
            }
            else
            {
                using (FileStream writeZero = new FileStream(@"../../../logic/output/zero.txt", FileMode.OpenOrCreate))
                {
                    byte[] zero = System.Text.Encoding.Default.GetBytes(zeroStr);
                    writeZero.Write(zero, 0, zero.Length);
                    Console.WriteLine(zeroStr);
                }
            }

            if (ngArr.GroupBy(x => x).Select(y => y).Where(z => z.Count() > 1).Count() > 0)
            {
                using (FileStream writeNeg = new FileStream(@"../../../logic/output/negativeREP.txt", FileMode.OpenOrCreate))
                {
                    byte[] negative = System.Text.Encoding.Default.GetBytes(negStr);
                    writeNeg.Write(negative, 0, negative.Length);
                    Console.WriteLine(negStr);
                }
            }
            else
            {
                using (FileStream writeNeg = new FileStream(@"../../../logic/output/negative.txt", FileMode.OpenOrCreate))
                {
                    byte[] negative = System.Text.Encoding.Default.GetBytes(negStr);
                    writeNeg.Write(negative, 0, negative.Length);
                    Console.WriteLine(negStr);
                }
            }
        }

    }
}

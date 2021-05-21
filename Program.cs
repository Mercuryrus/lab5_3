using System;

namespace lab5_3
{
    class Program
    {
        static void Main()
        {
            logic.ArrayOperation.ArrayReadTxt();
            Console.WriteLine(logic.ArrayOperation.MultiplyEvenArray());
            Console.WriteLine(logic.ArrayOperation.SumZeroElem());
            logic.ArrayOperation.SortArray();
        }
    }
}

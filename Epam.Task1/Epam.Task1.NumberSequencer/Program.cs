using System;
using System.Text;

namespace Epam.Task1.NumberSequencer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(NumberSequencer(7));

            Console.WriteLine();

            Console.WriteLine(NumberSequencerSB(100));
        }

        public static string NumberSequencer(int n)
        {
            string result = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                if (i == n) result += i.ToString();
                else result += i.ToString() + ", ";
            }
            return result;
        }

        /* В случае операций со строками в цикле, лучше всего сразу
         * задуматься об использовании класса StringBuilder,
         * так как строка неизменяема и при каждой операции присвоения
         * в цикле будет создаваться новая строка.
         * После +- 20-30 итераций SB работает быстрее и дает меньшую
         * нагрузку на память. Эффективнее всего будет, если сразу
         * задавать размер SB в конструкторе.
        */

        public static string NumberSequencerSB(int n)
        {
            int size = 0;

            if (n < 10) size += n;

            if (n >= 10 && n < 100) size += (n - 9) * 2 + 9;

            if (n >= 100 && n < 1000) size += (n - 99) * 3 + 189;

            if (n >= 1000 && n < 10000) size += (n - 999) * 4 + 2889;

            if (n >= 10000) size += 38894;

            size = size + n * 2 - 2;

            StringBuilder sb = new StringBuilder(size);

            for (int i = 1; i <= n; i++)
            {
                if (i == n) sb.Append(i.ToString());
                else sb.Append(i.ToString()).Append(", ");
            }

            string result = sb.ToString();
            return result;
        }
    }
}

using System;

namespace Epam.Task1.CheckSimplicity
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1 - " + CheckSimplicity(1).ToString());
            Console.WriteLine("2 - " + CheckSimplicity(2).ToString());
            Console.WriteLine("3 - " + CheckSimplicity(3).ToString());
            Console.WriteLine("7 - " + CheckSimplicity(7).ToString());
            Console.WriteLine("9 - " + CheckSimplicity(9).ToString());
            Console.WriteLine("55 - " + CheckSimplicity(55).ToString());
            Console.WriteLine("71 - " + CheckSimplicity(71).ToString());
        }

        public static bool CheckSimplicity(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= n / i; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

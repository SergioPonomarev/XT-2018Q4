using System;

namespace Epam.Task1.CheckSimplicity
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{i} is simple number - "
                                  + CheckSimplicity(i).ToString());
            }
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

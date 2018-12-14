using System;

namespace Epam.Task5.NumberArraySum
{
    public static class SingleRandom
    {
        private static Random random = new Random();

        private static object lockOn = new object();

        public static int Next()
        {
            lock (lockOn)
            {
                return random.Next();
            }
        }

        public static int Next(int max)
        {
            lock (lockOn)
            {
                return random.Next(max);
            }
        }

        public static int Next(int min, int max)
        {
            lock (lockOn)
            {
                return random.Next(min, max);
            }
        }

        public static double NextDouble()
        {
            lock (lockOn)
            {
                return random.NextDouble();
            }
        }

        public static void NextBytes(byte[] array)
        {
            lock (lockOn)
            {
                random.NextBytes(array);
            }
        }
    }
}

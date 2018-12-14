﻿using System;

namespace Epam.Task5.NumberArraySum
{
    public static class NumberArrayExtentions
    {
        public static byte ArraySum(this byte[] arr)
        {
            byte sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static sbyte ArraySum(this sbyte[] arr)
        {
            sbyte sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static short ArraySum(this short[] arr)
        {
            short sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static ushort ArraySum(this ushort[] arr)
        {
            ushort sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static int ArraySum(this int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static uint ArraySum(this uint[] arr)
        {
            uint sum = 0U;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static long ArraySum(this long[] arr)
        {
            long sum = 0L;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static ulong ArraySum(this ulong[] arr)
        {
            ulong sum = 0UL;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static float ArraySum(this float[] arr)
        {
            float sum = 0.0F;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static double ArraySum(this double[] arr)
        {
            double sum = 0.0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static decimal ArraySum(this decimal[] arr)
        {
            decimal sum = 0.0M;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }
}

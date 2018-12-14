using System;

namespace Epam.Task5.NumberArraySum
{
    internal class Program
    {
        private static bool choiceCheck;
        private static bool check;
        private static int length;

        private static void Main(string[] args)
        {
            Console.WriteLine("Greetings! This is The ArraySum Method Demonstrating Program.");
            Console.WriteLine();

            while (!choiceCheck)
            {
                ShowMenu();
                string choice = ReadMenuChoice();
                Console.WriteLine();
                switch (choice)
                {
                    case "byte":
                        choiceCheck = true;
                        ByteArrayProcessing();
                        break;

                    case "sbyte":
                        choiceCheck = true;
                        SbyteArrayProcessing();
                        break;

                    case "short":
                        choiceCheck = true;
                        ShortArrayProcessing();
                        break;

                    case "ushort":
                        choiceCheck = true;
                        UshortArrayProcessing();
                        break;

                    case "int":
                        choiceCheck = true;
                        IntArrayProcessing();
                        break;

                    case "uint":
                        choiceCheck = true;
                        UintArrayProcessing();
                        break;

                    case "long":
                        choiceCheck = true;
                        LongArrayProcessing();
                        break;

                    case "ulong":
                        choiceCheck = true;
                        UlongArrayProcessing();
                        break;

                    case "float":
                        choiceCheck = true;
                        FloatArrayProcessing();
                        break;

                    case "double":
                        choiceCheck = true;
                        DoubleArrayProcessing();
                        break;

                    case "decimal":
                        choiceCheck = true;
                        DecimalArrayProcessing();
                        break;

                    default:
                        choiceCheck = false;
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static void DecimalArrayProcessing()
        {
            ArrayLength();
            decimal[] decimalArr = new decimal[length];
            for (int i = 0; i < decimalArr.Length; i++)
            {
                decimalArr[i] = Convert.ToDecimal(Math.Round(SingleRandom.Next(-100000, 100000) + SingleRandom.NextDouble(), 7));
            }

            ConsolePrintArray(decimalArr);
            decimal decimalSum = decimalArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {decimalSum.ToString()}");
        }

        private static void DoubleArrayProcessing()
        {
            ArrayLength();
            double[] doubleArr = new double[length];
            for (int i = 0; i < doubleArr.Length; i++)
            {
                doubleArr[i] = Convert.ToDouble(Math.Round(SingleRandom.Next(-10000, 10000) + SingleRandom.NextDouble(), 5));
            }

            ConsolePrintArray(doubleArr);
            double doubleSum = doubleArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {doubleSum.ToString()}");
        }

        private static void FloatArrayProcessing()
        {
            ArrayLength();
            float[] floatArr = new float[length];
            for (int i = 0; i < floatArr.Length; i++)
            {
                floatArr[i] = Convert.ToSingle(Math.Round(SingleRandom.Next(-1000, 1000) + SingleRandom.NextDouble(), 3));
            }

            ConsolePrintArray(floatArr);
            float floatSum = floatArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {floatSum.ToString()}");
        }

        private static void UlongArrayProcessing()
        {
            ArrayLength();
            ulong[] ulongArr = new ulong[length];
            for (int i = 0; i < ulongArr.Length; i++)
            {
                ulongArr[i] = Convert.ToUInt64(SingleRandom.Next(0, 10000000));
            }

            ConsolePrintArray(ulongArr);
            ulong ulongSum = ulongArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {ulongSum.ToString()}");
        }

        private static void LongArrayProcessing()
        {
            ArrayLength();
            long[] longArr = new long[length];
            for (int i = 0; i < longArr.Length; i++)
            {
                longArr[i] = Convert.ToInt64(SingleRandom.Next(-10000000, 10000000));
            }

            ConsolePrintArray(longArr);
            long longSum = longArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {longSum.ToString()}");
        }

        private static void UintArrayProcessing()
        {
            ArrayLength();
            uint[] uintArr = new uint[length];
            for (int i = 0; i < uintArr.Length; i++)
            {
                uintArr[i] = Convert.ToUInt32(SingleRandom.Next(0, 1000000));
            }

            ConsolePrintArray(uintArr);
            uint uintSum = uintArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {uintSum.ToString()}");
        }

        private static void IntArrayProcessing()
        {
            ArrayLength();
            int[] intArr = new int[length];
            for (int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = SingleRandom.Next(-1000000, 1000000);
            }

            ConsolePrintArray(intArr);
            int intSum = intArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {intSum.ToString()}");
        }

        private static void UshortArrayProcessing()
        {
            ArrayLength();
            ushort[] ushortArr = new ushort[length];
            for (int i = 0; i < ushortArr.Length; i++)
            {
                ushortArr[i] = Convert.ToUInt16(SingleRandom.Next(0, 1001));
            }

            ConsolePrintArray(ushortArr);
            ushort ushortSum = ushortArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {ushortSum.ToString()}");
        }

        private static void ShortArrayProcessing()
        {
            ArrayLength();
            short[] shortArr = new short[length];
            for (int i = 0; i < shortArr.Length; i++)
            {
                shortArr[i] = Convert.ToInt16(SingleRandom.Next(-1000, 1001));
            }

            ConsolePrintArray(shortArr);
            short shortSum = shortArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {shortSum.ToString()}");
        }

        private static void SbyteArrayProcessing()
        {
            ArrayLength();
            sbyte[] sbyteArr = new sbyte[length];
            for (int i = 0; i < sbyteArr.Length; i++)
            {
                sbyteArr[i] = Convert.ToSByte(SingleRandom.Next(-10, 11));
            }

            ConsolePrintArray(sbyteArr);
            sbyte sumSbyte = sbyteArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {sumSbyte.ToString()}");
        }

        private static void ByteArrayProcessing()
        {
            ArrayLength();
            byte[] byteArr = new byte[length];
            SingleRandom.NextBytes(byteArr);
            ConsolePrintArray(byteArr);
            byte sumByte = byteArr.ArraySum();
            Console.WriteLine($"Sum of elements in array: {sumByte.ToString()}");
        }

        private static void ConsolePrintArray<T>(T[] array)
        {
            Console.Write("Array elements: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        private static string ReadMenuChoice()
        {
            return Console.ReadLine().ToLower();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("Byte - to create byte array.");
            Console.WriteLine("Sbyte - to create sbyte array.");
            Console.WriteLine("Short - to create short array.");
            Console.WriteLine("Ushort - to create ushort array.");
            Console.WriteLine("Int - to create int array.");
            Console.WriteLine("Uint - to create uint array.");
            Console.WriteLine("Long - to create long array.");
            Console.WriteLine("Ulong - to create ulong array.");
            Console.WriteLine("Float - to create float array.");
            Console.WriteLine("Double - to create double array.");
            Console.WriteLine("Decimal - to create decimal array.");
            Console.Write("Enter chosen type: ");
        }

        private static int ArrayLength()
        {
            while (!check)
            {
                try
                {
                    Console.Write("Enter natural number for array length: ");
                    check = int.TryParse(Console.ReadLine(), out length);
                    check = CheckLength(check, length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }

            return length;
        }

        private static bool CheckLength(bool check, int length)
        {
            if (!check || length < 1)
            {
                throw new ArgumentException("Array length must be natural number greater than 0.");
            }

            return true;
        }
    }
}

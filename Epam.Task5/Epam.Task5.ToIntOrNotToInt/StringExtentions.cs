using System;

namespace Epam.Task5.ToIntOrNotToInt
{
    public static class StringExtentions
    {
        public static bool IsPositiveNaturalNumber(this string param)
        {
            decimal res = 0;
            decimal integerPart = 0;
            decimal fractionalPart = 0;
            int power = 0;
            int index = 0;
            int divisor = 1;
            bool plus = false;
            bool minus = false;
            bool comma = false;
            bool exponent = false;

            switch (param[0])
            {
                case '+':
                    index = 1;

                    if (index == param.Length)
                    {
                        return false;
                    }

                    if (!(param[index] >= '0' && param[index] <= '9'))
                    {
                        return false;
                    }

                    break;

                case '-':
                    return false;
            }

            if (param[index] == '0')
            {
                if (index == param.Length - 1)
                {
                    return false;
                }
            }

            if (param[index] == '0' && char.ToUpper(param[index + 1]) == char.ToUpper('x'))
            {
                for (int i = index + 2; i < param.Length; i++)
                {
                    if ((param[i] < '0' || param[i] > '9') &&
                        (char.ToUpper(param[i]) < 'A' || char.ToUpper(param[i]) > 'F'))
                    {
                        return false;
                    }
                }

                return true;
            }

            for (int i = index; i < param.Length; i++)
            {
                if ((param[i] < '0' ||
                    param[i] > '9') &&
                    param[i] != ',' &&
                    char.ToUpper(param[i]) != 'E' &&
                    param[i] != '+' &&
                    param[i] != '-')
                {
                    return false;
                }

                if (param[i] == ',')
                {
                    if (!comma)
                    {
                        comma = true;
                        if (i - 1 == -1 || i + 1 == param.Length)
                        {
                            return false;
                        }

                        if (param[i - 1] < '0' || param[i - 1] > '9')
                        {
                            return false;
                        }

                        if (param[i + 1] < '0' || param[i + 1] > '9')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (char.ToUpper(param[i]) == 'E')
                {
                    if (!exponent)
                    {
                        exponent = true;
                        if (i - 1 == -1 || i + 1 == param.Length)
                        {
                            return false;
                        }

                        if (param[i - 1] < '0' || param[i - 1] > '9')
                        {
                            return false;
                        }

                        if (exponent)
                        {
                            res = res / divisor;
                            i++;
                        }

                        while (i < param.Length)
                        {
                            if (param[i] < '0' || param[i] > '9')
                            {
                                if (param[i] != '+' && param[i] != '-')
                                {
                                    return false;
                                }
                            }

                            if (param[i] == '-')
                            {
                                if (!minus)
                                {
                                    minus = true;
                                    i++;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            if (param[i] == '+')
                            {
                                if (!plus)
                                {
                                    plus = true;
                                    i++;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            if (i == param.Length)
                            {
                                return false;
                            }

                            power = (power * 10) + (param[i] - '0');
                            i++;
                        }

                        if (minus)
                        {
                            power = power * -1;
                        }

                        res = res * (decimal)Math.Pow(10, power);
                    }
                    else
                    {
                        return false;
                    }

                    integerPart = Math.Truncate(res);

                    if (integerPart == 0)
                    {
                        return false;
                    }

                    fractionalPart = res - Math.Truncate(res);

                    if (fractionalPart == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                if (comma && !exponent && param[i] != ',')
                {
                    divisor *= 10;
                }

                if (!exponent && param[i] != ',')
                {
                    res = (res * 10) + (param[i] - '0');
                }
            }

            res = res / divisor;

            fractionalPart = res - Math.Truncate(res);

            if (fractionalPart == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

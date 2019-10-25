using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_system_converter
{
    public static class NumberConverter
    {
        public const int PRECISION = 8;

        public static readonly Keys[] BinaryKeys = { Keys.D1, Keys.NumPad1, Keys.NumPad0, Keys.D0, Keys.Oemcomma, Keys.OemPeriod };
        public static readonly Keys[] OctoKeys = { Keys.D1, Keys.NumPad1, Keys.NumPad0, Keys.D0, Keys.D2, Keys.NumPad2,
            Keys.NumPad3, Keys.D3, Keys.D4, Keys.NumPad4, Keys.D5, Keys.NumPad5, Keys.NumPad6,
            Keys.D6, Keys.D7, Keys.NumPad7, Keys.Oemcomma, Keys.OemPeriod };
        public static readonly Keys[] DecimalKeys = { Keys.D1, Keys.NumPad1, Keys.NumPad0, Keys.D0, Keys.D2, Keys.NumPad2,
            Keys.NumPad3, Keys.D3, Keys.D4, Keys.NumPad4, Keys.D5, Keys.NumPad5, Keys.NumPad6,
            Keys.D6, Keys.D7, Keys.NumPad7, Keys.NumPad8, Keys.D8, Keys.D9, Keys.NumPad9, Keys.Oemcomma, Keys.OemPeriod };
        public static readonly Keys[] HexadecimalKeys = { Keys.D1, Keys.NumPad1, Keys.NumPad0, Keys.D0, Keys.D2, Keys.NumPad2,
            Keys.NumPad3, Keys.D3, Keys.D4, Keys.NumPad4, Keys.D5, Keys.NumPad5, Keys.NumPad6,
            Keys.D6, Keys.D7, Keys.NumPad7, Keys.NumPad8, Keys.D8, Keys.D9, Keys.NumPad9, Keys.A, Keys.B,
            Keys.C, Keys.D, Keys.E, Keys.F, Keys.Oemcomma, Keys.OemPeriod };

        public static readonly char[] BinaryChars = { '1', '0', ',', '.', ',' };
        public static readonly char[] OctoChars = { '1', '0', ',', '2', '3', '4', '5', '6', '7', '.', ',' };
        public static readonly char[] DecimalChars = { '1', '0', ',', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',' };
        public static readonly char[] HexadecimalChars = { '1', '0', ',', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'A',
            'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', '.', ',' };


        public static bool DoesSystemHasLetter(Keys key, NumberSystem system)
        {
            switch (system)
            {
                case NumberSystem.Binary:
                    if (BinaryKeys.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Octal:
                    if (OctoKeys.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Decimal:
                    if (DecimalKeys.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Hexadecimal:
                    if (HexadecimalKeys.Contains(key))
                        return true;
                    else return false;
                default:
                    break;
            }
            return false;
        }
        public static bool DoesSystemHasLetter(char key, NumberSystem system)
        {
            switch (system)
            {
                case NumberSystem.Binary:
                    if (BinaryChars.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Octal:
                    if (OctoChars.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Decimal:
                    if (DecimalChars.Contains(key))
                        return true;
                    else return false;
                case NumberSystem.Hexadecimal:
                    if (HexadecimalChars.Contains(key))
                        return true;
                    else return false;
                default:
                    break;
            }
            return false;
        }

        public static int GetValueFromChar(char ch, NumberSystem system)
        {
            switch (system)
            {
                case NumberSystem.Binary:
                    if (ch == '0')
                        return 0;
                    if (ch == '1')
                        return 1;
                    break;
                case NumberSystem.Octal:
                    if (ch == '0')
                        return 0;
                    if (ch == '1')
                        return 1;
                    if (ch == '2')
                        return 2;
                    if (ch == '3')
                        return 3;
                    if (ch == '4')
                        return 4;
                    if (ch == '5')
                        return 5;
                    if (ch == '6')
                        return 6;
                    if (ch == '7')
                        return 7;
                    break;
                case NumberSystem.Decimal:
                    if (ch == '0')
                        return 0;
                    if (ch == '1')
                        return 1;
                    if (ch == '2')
                        return 2;
                    if (ch == '3')
                        return 3;
                    if (ch == '4')
                        return 4;
                    if (ch == '5')
                        return 5;
                    if (ch == '6')
                        return 6;
                    if (ch == '7')
                        return 7;
                    if (ch == '8')
                        return 8;
                    if (ch == '9')
                        return 9;
                    break;
                case NumberSystem.Hexadecimal:
                    if (ch == '0')
                        return 0;
                    if (ch == '1')
                        return 1;
                    if (ch == '2')
                        return 2;
                    if (ch == '3')
                        return 3;
                    if (ch == '4')
                        return 4;
                    if (ch == '5')
                        return 5;
                    if (ch == '6')
                        return 6;
                    if (ch == '7')
                        return 7;
                    if (ch == '8')
                        return 8;
                    if (ch == '9')
                        return 9;
                    if (ch == 'a' || ch == 'A')
                        return 10;
                    if (ch == 'b' || ch == 'B')
                        return 11;
                    if (ch == 'c' || ch == 'C')
                        return 12;
                    if (ch == 'd' || ch == 'D')
                        return 13;
                    if (ch == 'e' || ch == 'E')
                        return 14;
                    if (ch == 'f' || ch == 'F')
                        return 15;
                    break;
                default:
                    break;
            }
            return 0;
        }
        public static string GetHexCharFromInt(int i)
        {
            if (i < 10)
                return i.ToString();
            else if (i == 10)
                return "A";
            else if (i == 11)
                return "B";
            else if (i == 12)
                return "C";
            else if (i == 13)
                return "D";
            else if (i == 14)
                return "E";
            else return "F";
        }

        public static string Convert(string input, NumberSystem inputSystem, NumberSystem outputSystem)
        {
            //return ConvertFromDecimal(ConvertToDecimal(input, inputSystem), outputSystem).ToString();
            return ConvertFromDecimal(ConvertToDecimal(input, inputSystem), outputSystem);
        }

        public static string ConvertFromDecimal(double value, NumberSystem system)
        {
            //double result = 0;
            double whole = Floor(value);
            double frac = Fraction(value);

            string wholePart = "";
            string fractionPart = "";

            bool breakNextIteration = false;

            switch (system)
            {
                case NumberSystem.Binary:
                    wholePart = "";
                    breakNextIteration = false;
                    while (true)
                    {
                        whole = Floor(whole);
                        wholePart += (whole % 2).ToString();
                        //Debug.WriteLine("Whole part: " + whole + " reminder: " + whole % 2);
                        whole /= 2;
                        if (breakNextIteration)
                            break;
                        if (whole < 2)
                            breakNextIteration = true;
                    }

                    if (frac != 0)
                    {
                        int iteration = 0;
                        while (iteration < PRECISION)
                        {
                            double temp = frac * 2;
                            if (temp >= 1)
                            {
                                fractionPart += Floor(temp);
                                temp -= Floor(temp);
                            }
                            else
                            {
                                fractionPart += Floor(temp);
                            }

                            frac = temp;
                            iteration++;
                        }
                    }

                    break;
                case NumberSystem.Octal:
                    wholePart = "";
                    breakNextIteration = false;
                    while (true)
                    {
                        whole = Floor(whole);
                        wholePart += (whole % 8).ToString();
                        //Debug.WriteLine("Whole part: " + whole + " reminder: " + whole % 2);
                        whole /= 8;
                        if (breakNextIteration)
                            break;
                        if (whole < 8)
                            breakNextIteration = true;
                    }

                    if (frac != 0)
                    {
                        int iteration = 0;
                        while (iteration < PRECISION)
                        {
                            double temp = frac * 8;
                            if (temp >= 1)
                            {
                                fractionPart += Floor(temp);
                                temp -= Floor(temp);
                            }
                            else
                            {
                                fractionPart += Floor(temp);
                            }

                            frac = temp;
                            iteration++;
                        }
                    }
                    break;
                case NumberSystem.Decimal:
                    return value.ToString();
                case NumberSystem.Hexadecimal:
                    wholePart = "";
                    breakNextIteration = false;
                    while (true)
                    {
                        whole = Floor(whole);
                        wholePart += GetHexCharFromInt((int)(whole % 16)).ToString();
                        //Debug.WriteLine("Whole part: " + whole + " reminder: " + whole % 2);
                        whole /= 16;
                        if (breakNextIteration)
                            break;
                        if (whole < 16)
                            breakNextIteration = true;
                    }

                    if (frac != 0)
                    {
                        int iteration = 0;
                        while (iteration < PRECISION)
                        {
                            double temp = frac * 16;
                            if (temp >= 1)
                            {
                                fractionPart += GetHexCharFromInt((int)Floor(temp));
                                temp -= Floor(temp);
                            }
                            else
                            {
                                fractionPart += GetHexCharFromInt((int)Floor(temp));
                            }

                            frac = temp;
                            iteration++;
                        }
                    }
                    break;
                default:
                    break;
            }
            wholePart = ReverseString(wholePart);
            //fractionPart = ReverseString(fractionPart);

            string stringResult = wholePart;
            if (fractionPart != "")
                stringResult += ("," + fractionPart);
            //Debug.WriteLine("Whole part: " + wholePart);
            //double result1 = System.Convert.ToDouble(wholePart);
            //double result2 = 0;// System.Convert.ToDouble(fractionPart);
            //if (fractionPart != "")
            //    result = 
            //Debug.WriteLine("Result from decimal: " + result);
            //return System.Convert.ToDouble(stringResult);



            stringResult = PrepareString(stringResult);
            stringResult = PrepareOutput(stringResult);

            Debug.WriteLine("WHOLE PART: " + wholePart);
            Debug.WriteLine("FRACTION PART: " + fractionPart);

            //if (fractionPart != "")
            //{
            //
            //    stringResult = "0," + stringResult.Trim(',');
            //    Debug.WriteLine("CERF!");
            //}
            //if (wholePart == "00" && fractionPart != "")
            //{
            //    stringResult = "0,";
            //    stringResult += fractionPart;
            //    Debug.WriteLine("CERF!");
            //}
            //if (system == NumberSystem.Hexadecimal)
            //    stringResult = ReverseString(stringResult);

            return stringResult;
        }
        public static double ConvertToDecimal(string value, NumberSystem system)
        {
            double result = 0;
            string whole = "0";
            string frac = "0";
            value = PrepareString(value);
            if (value.Contains(","))
            {
                whole = value.Split(',')[0];
                if (whole == "")
                    whole += "0";
                frac = value.Split(',')[1];
            }
            else
            {
                whole = value;
            }

            double wholePart = 0;
            double fractionPart = 0;

            //System.Diagnostics.Debug.WriteLine("Whole: " + whole);
            //System.Diagnostics.Debug.WriteLine("Fraction: " + frac);

            switch (system)
            {
                case NumberSystem.Binary:
                    for (int i = 0; i < whole.Length; i++)
                    {
                        wholePart += Math.Pow(2, i) * GetValueFromChar(whole[whole.Length - 1 - i], NumberSystem.Binary);
                    }
                    if (frac != "0")
                    {
                        for (int i = 0; i < frac.Length; i++)
                        {
                            fractionPart += Math.Pow(2, -i - 1) * GetValueFromChar(frac[i], NumberSystem.Binary);
                            //System.Diagnostics.Debug.WriteLine("Pow: " + i + " : " + Math.Pow(2, i));
                        }
                    }
                    break;
                case NumberSystem.Octal:
                    for (int i = 0; i < whole.Length; i++)
                    {
                        wholePart += Math.Pow(8, i) * GetValueFromChar(whole[whole.Length - 1 - i], NumberSystem.Octal);
                    }
                    if (frac != "0")
                    {
                        for (int i = 0; i < frac.Length; i++)
                        {
                            fractionPart += Math.Pow(8, -i - 1) * GetValueFromChar(frac[i], NumberSystem.Octal);
                            //System.Diagnostics.Debug.WriteLine("Pow: " + i + " : " + Math.Pow(8, i));
                        }
                    }
                    break;
                case NumberSystem.Decimal:
                    for (int i = 0; i < whole.Length; i++)
                    {
                        wholePart += Math.Pow(10, i) * GetValueFromChar(whole[whole.Length - 1 - i], NumberSystem.Decimal);
                    }
                    if (frac != "0")
                    {
                        for (int i = 0; i < frac.Length; i++)
                        {
                            fractionPart += Math.Pow(10, -i - 1) * GetValueFromChar(frac[i], NumberSystem.Decimal);
                            //System.Diagnostics.Debug.WriteLine("Pow: " + i + " : " + Math.Pow(10, i));
                        }
                    }
                    //result = System.Convert.ToDouble(value);
                    break;
                case NumberSystem.Hexadecimal:
                    for (int i = 0; i < whole.Length; i++)
                    {
                        wholePart += Math.Pow(16, i) * GetValueFromChar(whole[whole.Length - 1 - i], NumberSystem.Hexadecimal);
                    }
                    if (frac != "0")
                    {
                        for (int i = 0; i < frac.Length; i++)
                        {
                            fractionPart += Math.Pow(16, -i - 1) * GetValueFromChar(frac[i], NumberSystem.Hexadecimal);
                            //System.Diagnostics.Debug.WriteLine("Pow: " + i + " : " + Math.Pow(16, i));
                        }
                    }
                    break;
                default:
                    break;
            }

            result = wholePart + fractionPart;
            //System.Diagnostics.Debug.WriteLine("Result: " + result);
            return result;
        }


        private static string PrepareString(string value)
        {
            bool isStarted = false;
            string result = value;
            int offset = 0;
            result = value.Replace(".", ",");
            for (int i = 0; i < result.Length; i++)
            {
                if (isStarted == false)
                {
                    if (result[i] == '0')
                        offset++;
                    else isStarted = true;
                }
            }
            result = result.Substring(offset);
            if (result.Contains(","))
                result += '0';
            if (result == "")
                result += 0;
            return result;
        }
        private static string PrepareOutput(string value)
        {
            string result = value;
            if (result.Contains(','))
            {
                int offset = 0;
                bool trim = false;
                for (int i = result.Length - 1; i >= 0; i--)
                {
                    if (result[i] == '0')
                        offset = i;
                    else
                    {
                        trim = true;
                        break;
                    }
                }
                //if (result.Length > 0)
                Debug.WriteLine(result.Length);
                Debug.WriteLine(result.Length - 1 - offset);
                if (trim)
                    result = result.Remove(offset);
            }
            return result;
        }

        public static double Floor(double value)
        {
            return (long)value;
        }

        public static double Fraction(double value)
        {
            return value - Floor(value);
        }

        private static string ReverseString(string str)
        {
            char[] arr = new char[str.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = str[arr.Length - 1 - i];
            }
            return new string(arr);
        }
    }
    

    public enum NumberSystem
    {
        Binary, Octal, Decimal, Hexadecimal
    }
}

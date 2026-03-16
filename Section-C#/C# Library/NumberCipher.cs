using System;

/*
v1.0.0

WRITTEN BY ASHAR 
28.11.2025
Inspired by: https://www.instructables.com/Best-Codes/

CIPHER LIBRARY FOR NUMBERS ONLY
CONTAINS:
    1. A1Z26
    2. ATBASH
    3. BINARY       
    4. BRAILLE
    5. CAESAR CIPHER
    6. COLUMNAR CIPHER
    7. MORSE CODE
    8. PHONE CIPHER
*/

class NumberCipher{

    //ROMAN NUMERAL CONVERTER
    public static string Roman_Encode(int number){
        if (number < 1 || number > 3999)
            throw new ArgumentOutOfRangeException("number", "Insert value between 1 and 3999");
        
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        string result = thousands[number / 1000] +
                        hundreds[(number % 1000) / 100] +
                        tens[(number % 100) / 10] +
                        units[number % 10];

        return result;
    }
    public static int Roman_Decode(string roman){
        Dictionary<char, int> romanMap = new Dictionary<char, int> {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int total = 0;
        int prevValue = 0;

        foreach (char c in roman.ToUpper()){
            if (!romanMap.ContainsKey(c))
                throw new ArgumentException("Invalid Roman numeral character: " + c);

            int currentValue = romanMap[c];

            if (currentValue > prevValue){
                total += currentValue - 2 * prevValue;
            } else {
                total += currentValue;
            }
            prevValue = currentValue;
        }

        return total;
    }

    //BASE 1-62 CONVERTER
    public static string Base_Encode(int number, int targetBase){
        const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        if (targetBase < 2 || targetBase > digits.Length)
            throw new ArgumentException($"Base must be between 2 and {digits.Length}");

        // Zero is a special case
        if (number == 0)
            return "0";

        bool isNegative = number < 0;
        number = Math.Abs(number);

        string result = "";

        while (number > 0){
            int remainder = number % targetBase;
            result = digits[remainder] + result;
            number /= targetBase;
        }

        return isNegative ? "-" + result : result;
    }


    public static int Base_Decode(string encoded, int sourceBase)
    {
        const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        if (sourceBase < 2 || sourceBase > digits.Length)
            throw new ArgumentException($"Base must be between 2 and {digits.Length}");

        if (string.IsNullOrWhiteSpace(encoded))
            throw new ArgumentException("Encoded string cannot be empty.");

        bool isNegative = encoded.StartsWith("-");
        if (isNegative)
            encoded = encoded.Substring(1);

        int result = 0;

        foreach (char c in encoded){
            int value = digits.IndexOf(c);
            if (value < 0 || value >= sourceBase)
                throw new ArgumentException($"Invalid character '{c}' for base {sourceBase}.");

            result = result * sourceBase + value;
        }

        return isNegative ? -result : result;
    }

} 
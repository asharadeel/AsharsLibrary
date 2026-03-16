using System;

/*
v1.0.0

WRITTEN BY ASHAR 
28.11.2025
Inspired by: https://www.instructables.com/Best-Codes/

CIPHER LIBRARY
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

class Cipher{
    public static string A1Z26_Encode(string text){
        text = text.ToUpper();
        List<int> values = new List<int>();
        foreach(char c in text){
            if (char.IsLetter(c))
                values.Add(c - 'A' + 1);
            else if (c == ' ')
                values.Add(0);
        }
        return string.Join(" ", values);
    }

    public static string A1Z26_Decode(string numbers){
        string[] parts = numbers.Split(' ');
        string result = "";
        foreach (string p in parts){
            if (int.TryParse(p, out int num)){
                if (num == 0)
                    result += " ";
                else if (num >= 1 && num <= 26)
                    result += (char)('A' + num - 1);
            }
        }
        return result;
    }

    //ATBASH 
    public static string Atbash(string text){
        text = text.ToUpper();
        string result = "";
        foreach(char c in text){
            if (char.IsLetter(c)){
                result += (char)('Z' - (c - 'A'));
            }
            else{
                result += c;
            }
        }
        return result;
    }

    //BINARY
    public static string Binary_Encode(string text){
        string result = "";
        foreach (char c in text){
            result += Convert.ToString(c, 2).PadLeft(8, '0') + " ";
        }
        return result.Trim(); 
    }
    public static string Binary_Decode(string binary){
        string[] parts = binary.Split(' ');
        string result = "";
        foreach (string part in parts){
            int charCode = Convert.ToInt32(part, 2);
            result += (char)charCode;
        }
        return result;
    }

    // BRAILE
    public static string Braille_Encode(string text){
        text = text.ToUpper();
        Dictionary<char, char> braille = new Dictionary<char, char>(){
            {'A','⠁'},{'B','⠃'},{'C','⠉'},{'D','⠙'},{'E','⠑'},
            {'F','⠋'},{'G','⠛'},{'H','⠓'},{'I','⠊'},{'J','⠚'},
            {'K','⠅'},{'L','⠇'},{'M','⠍'},{'N','⠝'},{'O','⠕'},
            {'P','⠏'},{'Q','⠟'},{'R','⠗'},{'S','⠎'},{'T','⠞'},
            {'U','⠥'},{'V','⠧'},{'W','⠺'},{'X','⠭'},{'Y','⠽'},
            {'Z','⠵'}
        };

        string result = "";
        foreach(char c in text){
            if (braille.ContainsKey(c))
                result += braille[c];
            else
                result += " "; // keep spaces
        }

        return result;
    }

    public static string Braille_Decode(string brailleInput){
        Dictionary<char, char> reverse = new Dictionary<char, char>(){
            {'⠁','A'},{'⠃','B'},{'⠉','C'},{'⠙','D'},{'⠑','E'},
            {'⠋','F'},{'⠛','G'},{'⠓','H'},{'⠊','I'},{'⠚','J'},
            {'⠅','K'},{'⠇','L'},{'⠍','M'},{'⠝','N'},{'⠕','O'},
            {'⠏','P'},{'⠟','Q'},{'⠗','R'},{'⠎','S'},{'⠞','T'},
            {'⠥','U'},{'⠧','V'},{'⠺','W'},{'⠭','X'},{'⠽','Y'},
            {'⠵','Z'}
        };

        string result = "";
        foreach(char c in brailleInput){
            if (reverse.ContainsKey(c))
                result += reverse[c];
            else
                result += " ";
        }

        return result;
    }

    // CEASER CIPHER    
    public static string Caesar_Encode(string text, int shift){
        text = text.ToUpper();
        string result = "";
        foreach(char c in text){
            if (char.IsLetter(c)){
                char shifted = (char)(((c - 'A' + shift) % 26) + 'A');
                result += shifted;
            }
            else{
                result += c;
            }
        }
        return result;
    }
    public static string Caesar_Decode(string text, int shift){
        return Caesar_Encode(text, 26 - (shift % 26));
    }

    // COLUMNAR CIPHER
    public static string Columnar_Encode(string text, string key){
        int cols = key.Length;
        int rows = (int)Math.Ceiling((double)text.Length / cols);
        char[,] grid = new char[rows, cols];

        for (int i = 0; i < text.Length; i++){
            grid[i / cols, i % cols] = text[i];
        }

        List<(char, int)> keyOrder = new List<(char, int)>();
        for (int i = 0; i < key.Length; i++){
            keyOrder.Add((key[i], i));
        }
        keyOrder.Sort();

        string result = "";
        foreach (var (_, colIndex) in keyOrder){
            for (int r = 0; r < rows; r++){
                if (grid[r, colIndex] != '\0'){
                    result += grid[r, colIndex];
                }
            }
        }

        return result;
    }
    public static string Columnar_Decode(string cipherText, string key){
        int cols = key.Length;
        int rows = (int)Math.Ceiling((double)cipherText.Length / cols);
        char[,] grid = new char[rows, cols];

        List<(char, int)> keyOrder = new List<(char, int)>();
        for (int i = 0; i < key.Length; i++){
            keyOrder.Add((key[i], i));
        }
        keyOrder.Sort();

        int index = 0;
        foreach (var (_, colIndex) in keyOrder){
            for (int r = 0; r < rows; r++){
                if (index < cipherText.Length){
                    grid[r, colIndex] = cipherText[index++];
                }
            }
        }

        string result = "";
        for (int r = 0; r < rows; r++){
            for (int c = 0; c < cols; c++){
                if (grid[r, c] != '\0'){
                    result += grid[r, c];
                }
            }
        }

        return result;
    }

    // MORSE CODE
    public static string Morse_Encode(string text){
        Dictionary<char, string> morse = new Dictionary<char, string>(){
            {'A',".-"},{'B',"-..."},{'C',"-.-."},{'D',"-.."},{'E',"."},
            {'F',"..-."},{'G',"--."},{'H',"...."},{'I',".."},{'J',".---"},
            {'K',"-.-"},{'L',".-.."},{'M',"--"},{'N',"-."},{'O',"---"},
            {'P',".--."},{'Q',"--.-"},{'R',".-."},{'S',"..."},{'T',"-"},
            {'U',"..-"},{'V',"...-"},{'W',".--"},{'X',"-..-"},{'Y',"-.--"},
            {'Z',"--.."},
            {'0',"-----"},{'1',".----"},{'2',"..---"},{'3',"...--"},{'4',"....-"},
            {'5',"....."},{'6',"-...."},{'7',"--..."},{'8',"---.."},{'9',"----."},
            {' ',"/"}
        };

        text = text.ToUpper();
        string result = "";
        foreach(char c in text){
            if (morse.ContainsKey(c)){
                result += morse[c] + " ";
            }
        }

        return result.Trim();
    }
    public static string Morse_Decode(string morseCode){
        Dictionary<string, char> reverse = new Dictionary<string, char>(){
            {".-",'A'},{ "-...",'B'},{ "-.-.",'C'},{ "-..",'D'},{ ".",'E'},
            {"..-.",'F'},{ "--.",'G'},{ "....",'H'},{ "..",'I'},{ ".---",'J'},
            {"-.-",'K'},{ ".-..",'L'},{ "--",'M'},{ "-.",'N'},{ "---",'O'},
            {".--.",'P'},{ "--.-",'Q'},{ ".-.",'R'},{ "...",'S'},{ "-",'T'},
            {"..-",'U'},{ "...-",'V'},{ ".--",'W'},{ "-..-",'X'},{ "-.--",'Y'},
            {"--..",'Z'},
            {"-----",'0'},{ ".----",'1'},{ "..---",'2'},{ "...--",'3'},{ "....-",'4'},
            {".....",'5'},{ "-....",'6'},{ "--...",'7'},{ "---..",'8'},{ "----.",'9'},
            {"/",' '}
        };

        string[] parts = morseCode.Split(' ');
        string result = "";
        foreach (string part in parts){
            if (reverse.ContainsKey(part)){
                result += reverse[part];
            }
        }

        return result;
    }

    //PHONE CIPHER
    public static string Phone_Encode(string text){
        Dictionary<char, string> phone = new Dictionary<char, string>(){
            {'A',"2"},{'B',"22"},{'C',"222"},
            {'D',"3"},{'E',"33"},{'F',"333"},
            {'G',"4"},{'H',"44"},{'I',"444"},
            {'J',"5"},{'K',"55"},{'L',"555"},
            {'M',"6"},{'N',"66"},{'O',"666"},
            {'P',"7"},{'Q',"77"},{'R',"777"},{'S',"7777"},
            {'T',"8"},{'U',"88"},{'V',"888"},
            {'W',"9"},{'X',"99"},{'Y',"999"},{'Z',"9999"},
            {' ',"0"}
        };

        text = text.ToUpper();
        string result = "";
        foreach(char c in text){
            if (phone.ContainsKey(c)){
                result += phone[c];
            }
        }

        return result;
    }
    public static string Phone_Decode(string phoneCode){
        Dictionary<string, char> reverse = new Dictionary<string, char>(){
            {"2",'A'},{ "22",'B'},{ "222",'C'},
            {"3",'D'},{ "33",'E'},{ "333",'F'},
            {"4",'G'},{ "44",'H'},{ "444",'I'},
            {"5",'J'},{ "55",'K'},{ "555",'L'},
            {"6",'M'},{ "66",'N'},{ "666",'O'},
            {"7",'P'},{ "77",'Q'},{ "777",'R'},{ "7777",'S'},
            {"8",'T'},{ "88",'U'},{ "888",'V'},
            {"9",'W'},{ "99",'X'},{ "999",'Y'},{ "9999",'Z'},
            {"0",' '}
        };

        List<string> parts = new List<string>();
        for (int i = 0; i < phoneCode.Length; ){
            char currentChar = phoneCode[i];
            int count = 1;
            while (i + count < phoneCode.Length && phoneCode[i + count] == currentChar){
                count++;
            }
            parts.Add(new string(currentChar, count));
            i += count;
        }

        string result = "";
        foreach (string part in parts){
            if (reverse.ContainsKey(part)){
                result += reverse[part];
            }
        }

        return result;
    }
}
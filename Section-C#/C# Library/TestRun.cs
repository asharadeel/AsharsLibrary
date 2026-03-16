/*
using System;
using System.Collections.Generic;


v1.0.3

PROGRAM MAIN
TESTING 

WRITTEN BY ASHAR 

public class Program{
	
    public static void Main(){
        Console.WriteLine("\nASHARS LIBRARY\n");
        Console.WriteLine("###\n##\n#\nPROGRAM.MAIN()");
        Console.WriteLine("Choose your Library to Test");
        Console.WriteLine("[0] Quit");
        Console.WriteLine("[1] Cipher Section");
        Console.WriteLine("[2] Number Cipher Section");
        Console.WriteLine("-----\t-----\t-----\t-----");
        Console.Write("Enter option number: ");
        String option = Console.ReadLine();
        while(option != "0"){
            if(option == "1"){
                CipherSection();
            } 
            else if(option == "2"){
                NumberCipherSection();
            } 
            else {
                Console.WriteLine("Invalid option. Please try again.");
            }
            Console.WriteLine("\nASHARS LIBRARY\n");
            Console.WriteLine("###\n##\n#\nPROGRAM.MAIN()");
            Console.WriteLine("Choose your Library to Test");
            Console.WriteLine("[0] Quit");
            Console.WriteLine("[1] Cipher Section");
            Console.WriteLine("[2] Number Cipher Section");
            Console.WriteLine("-----\t-----\t-----\t-----");
            Console.Write("Enter option number: ");
            option = Console.ReadLine();
        }
        
        
        
        // Example usage of NumberCipher
        Console.WriteLine("\nNumber Cipher Examples:");
        int number = 2006;
        string roman = NumberCipher.Roman_Encode(number);
        Console.WriteLine($"Roman Encode of {number}: {roman}");
        int decodedNumber = NumberCipher.Roman_Decode(roman);
        Console.WriteLine($"Roman Decode of {roman}: {decodedNumber}");

    }



    public static void CipherSection()
    {
        Console.WriteLine("###\n##\n#\nCIPHERSECTION()");

        Console.WriteLine("Welcome to Cipher Libray");
        Console.WriteLine("Enter a string to encode (type 'stop' to exit):");
        String v1 = Console.ReadLine();
        while (string.IsNullOrEmpty(v1)){
            Console.WriteLine("Input cannot be empty. Please enter a valid string:");
            v1 = Console.ReadLine();
        }
        while(v1 != "stop"){
            CipherAll(v1);
            Console.WriteLine("SUPER ENCRYPTION: ");
            SuperEncrypt(v1);
            Console.WriteLine("\n Enter another string to encode or type 'stop' to exit:");
            v1 = Console.ReadLine();
        }
        Console.WriteLine("\n END OF CIPHERSECTION()\n#\n##\n###");

    }
    public static void CipherAll(string text){
        
        Console.WriteLine("A1Z26: " + Cipher.A1Z26_Encode(text));
        Console.WriteLine("ATBASH: " + Cipher.Atbash(text));
        Console.WriteLine("BINARY: " + Cipher.Binary_Encode(text));
        Console.WriteLine("BRAILLE: " + Cipher.Braille_Encode(text));
        Console.WriteLine("CAESAR (shift 3): " + Cipher.Caesar_Encode(text, 3));
        Console.WriteLine("COLUMNAR (key reverses): " + Cipher.Columnar_Encode(text, "EDCBA"));
        Console.WriteLine("MORSE: " + Cipher.Morse_Encode(text));
        Console.WriteLine("PHONE: " + Cipher.Phone_Encode(text));
    }
    public static void SuperEncrypt(string text)
    {
        string step1 = Cipher.Caesar_Encode(text, 5);
        string step2 = Cipher.Atbash(step1);
        string step3 = Cipher.Caesar_Encode(step2,3);
        string step4 = Cipher.Columnar_Encode(step3,step1);
        string step5 = Cipher.Binary_Encode(step4);
        Console.WriteLine("Super Encrypted: " + step5);
    }


    public static void NumberCipherSection(){
        Console.WriteLine("###\n##\n#\nNUMBERCIPHERSECTION()");
        Console.WriteLine("Welcome to Number Cipher Library");
        Console.WriteLine("Enter a number to encode (type 'stop' to exit):");
        Console.WriteLine("Max 3999");

        string v1 = Console.ReadLine();

        // Fix: C# uses Length, not length()
        while (string.IsNullOrEmpty(v1) || (v1 != "stop" && Int32.Parse(v1) > 3999)){
            Console.WriteLine("Input cannot be empty or longer than 10 digits. Please enter a valid number:");
            v1 = Console.ReadLine();
        }

        while (v1 != "stop"){
            try{
                int number = Int32.Parse(v1);
                NumberCipherAll(number);
            }
            catch (FormatException){
                Console.WriteLine("Invalid number format. Please enter a valid integer.");
            }

            Console.WriteLine("Enter another number to encode or type 'stop' to exit:");
            v1 = Console.ReadLine();

            // Repeat the validation for new input
            while (!string.IsNullOrEmpty(v1) && v1 != "stop" && v1.Length > 10){
                Console.WriteLine("Input too long. Max 10 digits.");
                v1 = Console.ReadLine();
            }
        }

        Console.WriteLine("\n END OF NUMBERCIPHERSECTION()\n#\n##\n###");
    }

    public static void NumberCipherAll(int number){
        string romanEncoded = NumberCipher.Roman_Encode(number);
        Console.WriteLine("Roman Encoded: " + romanEncoded);

        for(int i = 2; i <= 62; i++){
            string baseEncoded = NumberCipher.Base_Encode(number, i);
            Console.WriteLine($"Base {i} Encoded: " + baseEncoded);
        }
    }


}


*/
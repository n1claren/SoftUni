using System;
using System.Linq;

namespace _04.Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseCode = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < morseCode.Length; i++)
            {
                string currentLetter = morseCode[i];

                switch (currentLetter)
                {
                    case ".-":
                        morseCode[i] = "A";
                        break;
                    case "-...":
                        morseCode[i] = "B";
                        break;
                    case "-.-.":
                        morseCode[i] = "C";
                        break;
                    case "-..":
                        morseCode[i] = "D";
                        break;
                    case ".":
                        morseCode[i] = "E";
                        break;
                    case "..-.":
                        morseCode[i] = "F";
                        break;
                    case "--.":
                        morseCode[i] = "G";
                        break;
                    case "....":
                        morseCode[i] = "H";
                        break;
                    case "..":
                        morseCode[i] = "I";
                        break;
                    case ".---":
                        morseCode[i] = "J";
                        break;
                    case "-.-":
                        morseCode[i] = "K";
                        break;
                    case ".-..":
                        morseCode[i] = "L";
                        break;
                    case "--":
                        morseCode[i] = "M";
                        break;
                    case "-.":
                        morseCode[i] = "N";
                        break;
                    case "---":
                        morseCode[i] = "O";
                        break;
                    case ".--.":
                        morseCode[i] = "P";
                        break;
                    case "--.-":
                        morseCode[i] = "Q";
                        break;
                    case ".-.":
                        morseCode[i] = "R";
                        break;
                    case "...":
                        morseCode[i] = "S";
                        break;
                    case "-":
                        morseCode[i] = "T";
                        break;
                    case "..-":
                        morseCode[i] = "U";
                        break;
                    case "...-":
                        morseCode[i] = "V";
                        break;
                    case ".--":
                        morseCode[i] = "W";
                        break;
                    case "-..-":
                        morseCode[i] = "X";
                        break;
                    case "-.--":
                        morseCode[i] = "Y";
                        break;
                    case "--..":
                        morseCode[i] = "Z";
                        break;
                    case "|":
                        morseCode[i] = " ";
                        break;

                }
            }

            Console.WriteLine(string.Join("", morseCode));
        }
    }
}
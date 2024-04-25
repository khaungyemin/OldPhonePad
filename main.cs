using System;
using System.Collections.Generic;
using System.Text;

class OldPhonePadConverter
{
    public static string OldPhonePad(string input)
    {
        Dictionary<char, string> numberToLetters = new Dictionary<char, string>() // create a dictionary of char to string
        {
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        char prevButton = ' ';
        int buttonCount = 1;
        StringBuilder resultBuilder = new StringBuilder();

        // looping the each character in the input string
        foreach (char c in input)
        {
            if (Char.IsDigit(c)) //checking on the character is digit or not              
            {
                if (c == '1' || c == '0')
                {
                    continue;//skip to next char
                }
                if (c != prevButton) //checking on the character is same as previous character or not
                {

                    buttonCount = 1;
                    // Reset count for a new button press
                }
                else
                {
                    resultBuilder.Length--;
                    buttonCount++;

                }

                if (buttonCount > numberToLetters[c].Length)
                {
                    buttonCount = 1; // Reset count if it exceeds the number of letters
                }


                resultBuilder.Append(numberToLetters[c][buttonCount - 1]);
                // Append the correct letter based on count
                prevButton = c;
            }
            else if (c == '*')
            {
                if (resultBuilder.Length > 0)
                {
                    resultBuilder.Length--; // Remove last character
                }
            }
            else if (c == '#')
            {
                break; // Exit the loop
            }
            else if (c == ' ')
            {
                prevButton = ' '; // Reset prevButton for the next word
            }
            else if (c == '1' && c == '0')
            {

            }
        }

        return resultBuilder.ToString().TrimEnd();
        //remove whitspace at the end
    }

    public static void Main(string[] args)
    // testing the program
    {
        Console.WriteLine(OldPhonePad("33#")); // Output: E
        Console.WriteLine(OldPhonePad("227*#")); // Output: B
        Console.WriteLine(OldPhonePad("4433555 555666#")); // Output: Hello
        Console.WriteLine(OldPhonePad("8 88777444666*664#")); // Output: ???
        Console.WriteLine(OldPhonePad("111000*2#")); // output for 2

    }
}
// See https://aka.ms/new-console-template for more information
using CMP1124M___Aclgorithms_and_Complexity___A01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

string file = @"c:\A01 - Alfie Sugden\CMP1124M - Algorithms and Complexity - A01\Text files\Road_1_256.txt";
//Defines file path

string[] line = File.ReadAllLines(file);

readToArrays RTA = new readToArrays();
//Instance of readToArray class is made

int[] ints = RTA.readArray(file);
//readArray is called and the array from the file is read

Console.WriteLine("Enter a number between 0 and 999: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string input = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

if (int.TryParse(input, out int intVal))
{
    bool found = false;
    for (int i = 0; i < line.Length; i++)
    {
        if (int.TryParse(line[i], out int lineVal) || lineVal != intVal)
        {
            Console.WriteLine($"Your Number {intVal} is on line {i + 1}.");
            found = true;
            break;
        }
    }
    //The above "Searches" the .txt file for the value entered and will return the value with the line number

    if (!found)
    {
        Console.WriteLine($"Could not find {intVal} in the list");
    }
    //If the number isn't found it will display this 
}
else
{
    Console.WriteLine("The number isn't in the list. Please try another number: ");
}
//If the 'if (!found)' doesn't work it will display this
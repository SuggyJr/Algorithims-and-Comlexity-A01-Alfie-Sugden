// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        fileReader reader = new fileReader();
        int[] road1Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_1_256.txt");
        int[] road2Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_2_256.txt");
        int[] road3Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_3_256.txt");

        bubbleSorter sorter = new bubbleSorter();
        sorter.sortAscending(road1Array);
        sorter.sortAscending(road2Array);
        sorter.sortAscending(road3Array);
        sorter.sortDescending(road1Array);
        sorter.sortDescending(road2Array);
        sorter.sortDescending(road3Array);

        Console.WriteLine("The 10th value of the sorted arrays are:");
        Console.WriteLine("Array 1 (ascending order): " + road1Array[9]);
        Console.WriteLine("Array 2 (ascending order): " + road2Array[9]);
        Console.WriteLine("Array 3 (ascending order): " + road3Array[9]);
        Console.WriteLine("Array 1 (descending order): " + road1Array[road1Array.Length - 10]);
        Console.WriteLine("Array 2 (descending order): " + road2Array[road2Array.Length - 10]);
        Console.WriteLine("Array 3 (descending order): " + road3Array[road3Array.Length - 10]);

        Console.Write("Enter a number to search for: ");
        int searchValue = int.Parse(Console.ReadLine());

        searchResult result1 = searchHelper.Search(road1Array, searchValue);
        searchResult result2 = searchHelper.Search(road2Array, searchValue);
        searchResult result3 = searchHelper.Search(road3Array, searchValue);

        if (result1.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 1 array at position(s): {string.Join(", ", result1.Positions)}");
        }
        else if (result2.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 2 array at position(s): {string.Join(", ", result2.Positions)}");
        }
        else if (result3.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 3 array at position(s): {string.Join(", ", result3.Positions)}");
        }
        else
        {
            Console.WriteLine($"Number {searchValue} is not found in any of the arrays.");
        }

        Console.ReadLine();
    }
}

class fileReader
{
    public int[] ReadFile(string filePath)
    {
        string[] stringArray = File.ReadAllLines(filePath);
        int[] intArray = Array.ConvertAll(stringArray, int.Parse);
        return intArray;
    }
}
class bubbleSorter
{
    public void sortAscending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public void sortDescending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] < array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}

class searchHelper
{
    public static searchResult Search(int[] array, int value)
    {
        searchResult result = new searchResult();
        result.Positions = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                result.IsFound = true;
                result.Positions.Add(i);
            }
        }

        return result;
    }
}

class searchResult
{
    public bool IsFound { get; set; }
    public List<int> Positions { get; set; }
}
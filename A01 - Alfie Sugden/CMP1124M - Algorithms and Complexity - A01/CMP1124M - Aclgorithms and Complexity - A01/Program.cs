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
        int[] road4Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_1_2048.txt");
        int[] road5Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_2_2048.txt");
        int[] road6Array = reader.ReadFile(@"c:\A01 - Alfie Sugden\Text files\Road_3_2048.txt");

        bubbleSorter sorter = new bubbleSorter();
        sorter.sortAscending(road1Array);
        sorter.sortAscending(road2Array);
        sorter.sortAscending(road3Array);
        sorter.sortAscending(road4Array);
        sorter.sortAscending(road5Array);
        sorter.sortAscending(road6Array);
        sorter.sortDescending(road1Array);
        sorter.sortDescending(road2Array);
        sorter.sortDescending(road3Array); 
        sorter.sortDescending(road4Array);
        sorter.sortDescending(road5Array);
        sorter.sortDescending(road6Array);

        Console.WriteLine("The 10th values for Roads 1,2,3 (256) of the sorted arrays are:");
        Console.WriteLine("Array 1 (ascending order): " + road1Array[9]);
        Console.WriteLine("Array 2 (ascending order): " + road2Array[9]);
        Console.WriteLine("Array 3 (ascending order): " + road3Array[9]);
        Console.WriteLine("Array 1 (descending order): " + road1Array[road1Array.Length - 10]);
        Console.WriteLine("Array 2 (descending order): " + road2Array[road2Array.Length - 10]);
        Console.WriteLine("Array 3 (descending order): " + road3Array[road3Array.Length - 10]);

        Console.WriteLine("The 50th values for Roads 1,2,3 (2048) of the sorted arrays are:");
        Console.WriteLine("Array 4 (ascending order): " + road1Array[49]);
        Console.WriteLine("Array 5 (ascending order): " + road2Array[49]);
        Console.WriteLine("Array 6 (ascending order): " + road3Array[49]);
        Console.WriteLine("Array 4 (descending order): " + road1Array[road1Array.Length - 50]);
        Console.WriteLine("Array 5 (descending order): " + road2Array[road2Array.Length - 50]);
        Console.WriteLine("Array 6 (descending order): " + road3Array[road3Array.Length - 50]);

        Console.Write("Enter a number to search for: ");
        int searchValue = int.Parse(Console.ReadLine());

        searchResult result1 = searchHelper.Search(road1Array, searchValue);
        searchResult result2 = searchHelper.Search(road2Array, searchValue);
        searchResult result3 = searchHelper.Search(road3Array, searchValue);
        searchResult result4 = searchHelper.Search(road4Array, searchValue);
        searchResult result5 = searchHelper.Search(road5Array, searchValue);
        searchResult result6 = searchHelper.Search(road6Array, searchValue);

        if (result1.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 1 (256) array at position(s): {string.Join(", ", result1.Positions)}");
        }
        else if (result2.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 2 (256) array at position(s): {string.Join(", ", result2.Positions)}");
        }
        else if (result3.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 3 (256) array at position(s): {string.Join(", ", result3.Positions)}");
        }
        else if (result4.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 2 (2048 )array at position(s): {string.Join(", ", result4.Positions)}");
        }
        else if (result5.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 3 (2048) array at position(s): {string.Join(", ", result5.Positions)}");
        }
        else if (result6.IsFound)
        {
            Console.WriteLine($"Number {searchValue} is found in the Road 3 (2048) array at position(s): {string.Join(", ", result6.Positions)}");
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
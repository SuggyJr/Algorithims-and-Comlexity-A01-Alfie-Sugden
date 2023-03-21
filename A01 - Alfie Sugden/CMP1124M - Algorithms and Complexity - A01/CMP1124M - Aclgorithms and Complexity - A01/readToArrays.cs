using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1124M___Aclgorithms_and_Complexity___A01
{
    public class readToArrays
    {
        public int[] readArray(string file)
        {
            string[] line = File.ReadAllLines(file);
            //File is read into an array of strings

            int[] ints = new int[line.Length];
            //An array of intagers is initialised to hol values

            for (int i = 0; i < line.Length; i++)
            {
                int.TryParse(line[i], out ints[i]);
            }
            //Each line is looped through and and parsed into an intager

            return ints;
            //Returns the intagers

            //Each value from the file is now contained within the integer array
        }
    }
    //This allows this class to be called to read the .txt files into arrays
}
//@"f:\USBOIIII\UNI WORK\A&C\ASS1\Text files\Road_1_256.txt"
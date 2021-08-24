using System;

namespace TestDome.Tests
{
    //https://www.testdome.com/questions/35884
    //Implement function CountNumbers that accepts a sorted array of unique integers and, efficiently with respect to time used, counts the number of
    //array elements that are less than the parameter lessThan.

    //For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2
    //because there are two array elements less than 4.

    public class SortedSearch
    {
        public static int CountNumbers1(int[] sortedArray, int lessThan)
        {
            var LessthanCount = 0;

            foreach (var item in sortedArray)
            {
                if (item < lessThan)
                {
                    LessthanCount++;
                }
            }
            return LessthanCount;
        }

        public static int CountNumbers2(int[] sortedArray, int lessThan)
        {
            int lengthOfArray = sortedArray.Length;
            if (lengthOfArray == 0)
                return 0;

            if (sortedArray[0] >= lessThan)
                return 0;
            if (sortedArray[lengthOfArray - 1] < lessThan)
                return lengthOfArray;

            int index = Array.BinarySearch(sortedArray, lessThan);
            if (index < 0)
                return ~index;

            return index;
        }

        public static int CountNumbers3(int[] sortedArray, int lessThan)
        {
            int val = Array.BinarySearch(sortedArray, lessThan);
            return val < 0 ? ~val : val;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(CountNumbers1(new int[] { 1, 3, 5, 7 }, 4));
            Console.ReadKey();
            //https://docs.microsoft.com/pt-br/dotnet/api/system.array.binarysearch?view=net-5.0
        }
    }
}

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
        //Solution without performance
        public static int CountNumbers1(int[] sortedArray, int lessThan)
        {
            var lessThanCount = 0;

            foreach (var item in sortedArray)
            {
                if (item < lessThan)
                    lessThanCount++;
            }
            return lessThanCount;
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

        /// O índice do value especificado no array especificado, caso value seja encontrado; caso contrário, um número negativo. 
        /// Caso value não seja encontrado e value seja menor que um ou mais elementos no array, o número negativo retornado 
        /// será o complemento bit a bit do índice do primeiro elemento maior que value. Caso value não seja encontrado e value 
        /// seja maior que todos os elementos no array, o número negativo retornado será o complemento bit a bit (do índice do último elemento mais 1). 
        /// Se esse método for chamado com array não classificado, o valor retornado poderá estar incorreto e um número negativo pode ser retornado, 
        /// mesmo se value estiver presente no array. 
        /// 
        /// Caso o Array não contenha o valor especificado, o método retorna um inteiro negativo. Você pode aplicar o operador de complemento de bit a bit (~ em C#) 
        /// ao resultado negativo para produzir um índice. Se esse índice for um maior que o limite superior da matriz, não haverá nenhum elemento maior do que value na matriz.
        /// Do contrário, é o índice do primeiro elemento que é maior que value.
        public static int CountNumbers3(int[] sortedArray, int lessThan)
        {
            int val = Array.BinarySearch(sortedArray, lessThan);
            return val < 0 ? ~val : val;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(CountNumbers3(new int[] { 1, 3, 5, 7 }, 4));
            Console.ReadKey();
            //https://docs.microsoft.com/pt-br/dotnet/api/system.array.binarysearch?view=net-5.0
        }
    }
}

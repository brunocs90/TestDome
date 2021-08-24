using System;
using System.Collections.Generic;

namespace TestDome.Tests
{
    //https://www.testdome.com/questions/38908
    //A TrainComposition is built by attaching and detaching wagons from the left and the right sides, efficiently with respect to time used.

    //For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, again from the left, we get a composition of two wagons
    //(13 and 7 from left to right).
    //Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

    public class TrainComposition
    {
        private LinkedList<int> wagons = new LinkedList<int>();

        public void AttachWagonFromLeft(int wagonId)
        {
            wagons.AddFirst(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            wagons.AddLast(wagonId);
        }

        public int DetachWagonFromLeft()
        {
            var firstWagon = wagons.First.Value;
            wagons.RemoveFirst();
            return firstWagon;
        }

        public int DetachWagonFromRight()
        {
            var lastWagon = wagons.Last.Value;
            wagons.RemoveLast();
            return lastWagon;
        }

        public static void Main(string[] args)
        {
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(13);
            Console.WriteLine(train.DetachWagonFromRight()); // 7 
            Console.WriteLine(train.DetachWagonFromLeft()); // 13
            Console.ReadKey();
            //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-5.0
        }
    }
}

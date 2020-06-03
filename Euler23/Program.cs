using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler23
{
    class Program
    {
        const int ABUNDANTLIMIT = 28123;
        static void Main(string[] args)
        {
            List<int> abunds = FindAllAbundantNumbers();
            HashSet<int> abundsSums = AllSumsOfAbunds(abunds);
            //Console.WriteLine(string.Join(", ", abundsSums));
            HashSet<int> notAbundSums = GetNumbersNotInHashSet(abundsSums);
            int finalSum = 0;
            foreach(int notAbundSum in notAbundSums)
            {
                finalSum += notAbundSum;
            }
            Console.WriteLine(finalSum);
        }
        //Gets all the positive integers which cannot be written as a sum of two abundant numbers
        private static HashSet<int> GetNumbersNotInHashSet(HashSet<int> abundsSums)
        {
            HashSet<int> notInSet = new HashSet<int>();
            for (int i = 0; i < ABUNDANTLIMIT; i++)
            {
                if(!abundsSums.Contains(i))
                {
                    notInSet.Add(i);
                }
            }
            return notInSet;
        }
        //Gets all the positive integers which can be written as a sum of two abundant numbers
        private static HashSet<int> AllSumsOfAbunds(List<int> abunds)
        {
            //Hashset can only contain unique numbers
            HashSet<int> abundSums = new HashSet<int>();
            for (int i = 0; i < abunds.Count; i++)
            {
                for(int j = 0; j < abunds.Count; j++)
                {
                    int abundSum = abunds[i] + abunds[j];
                    if (abundSum < ABUNDANTLIMIT)
                        abundSums.Add(abundSum);
                }
            }
            return abundSums;
        }
        //Finds all Abundant Numbers less that 28123
        static List<int> FindAllAbundantNumbers()
        {
            List<int> abunds = new List<int>();
            for(int i = 0; i < ABUNDANTLIMIT; i++)
            {
                List<int> factors = Factor(i);
                //Console.Write("{0}: {1} | {2}", i, string.Join(", ", factors), ArraySum(factors));
                if (i < ListSum(factors))
                {
                    //Console.Write("  abConfirmed\n");
                    abunds.Add(i);
                }
                //else
                    //Console.WriteLine();
            }
            return abunds;
        }
        static int ListSum(List<int> nums)
        {
            int sum = 0;
            foreach(int n in nums)
            {
                sum += n;
            }
            return sum;
        }
        static List<int> Factor(int num)
        {
            List<int> factors = new List<int>();
            for(int i = 1; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    if (num / i == i)
                        factors.Add(i);
                    else
                    {
                        factors.Add(i);
                        if(i != 1)
                            factors.Add(num / i);
                    }
                }
            }
            factors.Sort();
            return factors;
        }
    }
}

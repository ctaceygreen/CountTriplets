using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {

        Dictionary<long, long> waitingForMiddle = new Dictionary<long, long>();
        Dictionary<long, long> waitingForLast = new Dictionary<long, long>();
        long numberOfTriplets = 0;

        foreach (long item in arr)
        {
            //Check if we are currently waiting for this as the last in a triple
            if (waitingForLast.ContainsKey(item) && waitingForLast[item] > 0)
            {

                numberOfTriplets+=waitingForLast[item];

            }

            if (waitingForMiddle.ContainsKey(item) && waitingForMiddle[item] > 0)
            {
                //Check if we are currently waiting for this as the middle in a triple
                long lastVal = item * r;
                if (waitingForLast.ContainsKey(lastVal))
                {
                    //Update count to 1 more waiting
                    waitingForLast[lastVal]+=waitingForMiddle[item];
                }
                else
                {
                    waitingForLast.Add(lastVal, waitingForMiddle[item]);
                }

            }
            
            //Otherwise, add item * r to waiting for middle
            long middleVal = item * r;
            if (waitingForMiddle.ContainsKey(middleVal))
            {
                //Update count to 1 more waiting
                waitingForMiddle[middleVal]++;
            }
            else
            {
                waitingForMiddle.Add(middleVal, 1);
            }
            
        }
            return numberOfTriplets;

    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        //textWriter.WriteLine(ans);

        //textWriter.Flush();
        //textWriter.Close();
    }
}

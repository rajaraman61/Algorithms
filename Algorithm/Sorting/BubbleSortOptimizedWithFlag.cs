using Algorithms.Interface;
using Algorithms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithm.Sorting
{
    internal class BubbleSortOptimizedWithFlag : ISortAlgorithm
    {
        public string GetDescription()
        {
            return "Bubble Sort with Flag optimization";
        }


        public void Run()
        {
            // Get the integers from the user, including the number of inputs
            int[] userInputs = InputUtils.GetIntInputs();
            int[] sortedValues = Sort(userInputs);
            Console.WriteLine("Sorted Value:");

            foreach (int value in sortedValues)
            {
                Console.WriteLine(value);
            }
        }

        public int[] Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        MiscUtils.Swap(ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
            return arr;
        }
    }
}

using Algorithms.Interface;
using Algorithms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algorithm.Sorting
{
	internal class SelectionSort : ISortAlgorithm
	{
		public string GetDescription()
		{
			return "Selection sort algorithm";
		}

		public void Run()
		{
			// Get the integers from the user, including the number of inputs
			int[] userInputs = InputUtils.GetIntInputs();
			int[] sortedValues = Sort(userInputs);

			Console.WriteLine("Sorted Value:");

			foreach (var value in sortedValues)
			{
				Console.WriteLine(value);
			}
		}

		public int[] Sort(int[] arr)
		{
			int n = arr.Length;

			for (int i = 0; i < n - 1; i++ )
			{
				// Find the index of the minimum element in the remaining unsorted array
				int minIndex = i;
				for (var j = i + 1; j < n; j++)
				{
					if (arr[j] < arr[minIndex])
					{
						minIndex = j;
					}
				}

				// Swap the found minimum element with the first unsorted element
				if (minIndex != i)
				{
					MiscUtils.Swap(ref arr[i], ref arr[minIndex]);
				}
			}

			return arr;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Utils
{
	public static class InputUtils
	{
		// Method to get integer inputs from the user, including the number of inputs
		public static int[] GetIntInputs()
		{
			int numberOfInputs;

			// Get the number of inputs from the user
			while (true)
			{
				Console.Write("Enter the number of integer values you want to input: ");
				string input = Console.ReadLine();

				if (int.TryParse(input, out numberOfInputs) && numberOfInputs > 0)
				{
					break; // Exit loop if valid number of inputs
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a positive integer.");
				}
			}

			int[] inputs = new int[numberOfInputs];

			for (int i = 0; i < numberOfInputs; i++)
			{
				int userInput;
				while (true)
				{
					Console.Write($"Enter integer value {i + 1} of {numberOfInputs}: ");
					string inputValue = Console.ReadLine();

					if (int.TryParse(inputValue, out userInput))
					{
						inputs[i] = userInput;
						break; // Exit the loop if input is valid
					}
					else
					{
						Console.WriteLine("Invalid input. Please enter a valid integer.");
					}
				}
			}

			return inputs;
		}
	}

}

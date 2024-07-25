using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Discover and initialize algorithms
			var algorithms = DiscoverAlgorithms();

			// Display the menu
			DisplayMenu(algorithms);

			// Get user choice
			string choice = GetUserChoice();

			// Run the selected algorithm
			RunAlgorithm(choice, algorithms);
		}

		static Dictionary<string, IAlgorithm> DiscoverAlgorithms()
		{
			// Create a dictionary to store algorithms
			var algorithms = new Dictionary<string, IAlgorithm>();

			// Get all types that implement IAlgorithm
			var algorithmTypes = Assembly.GetExecutingAssembly()
			.GetTypes()
										 .Where(t => typeof(IAlgorithm).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
										 .ToList();

			// Instantiate and add each algorithm to the dictionary
			for (int i = 0; i < algorithmTypes.Count; i++)
			{
				IAlgorithm algorithm = null;
				try
				{
					algorithm = (IAlgorithm)Activator.CreateInstance(algorithmTypes[i]);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error creating instance of {algorithmTypes[i].Name}: {ex.Message}");
				}

				if (algorithm != null)
				{
					algorithms.Add((i + 1).ToString(), algorithm);
				}
			}
			return algorithms;
		}

		static void DisplayMenu(Dictionary<string, IAlgorithm> algorithms)
		{
			Console.WriteLine("Select an option:");
			foreach (var key in algorithms.Keys)
			{
				Console.WriteLine($"{key}. {algorithms[key].GetType().Name}");
			}
			Console.Write("Enter your choice: ");
		}

		static string GetUserChoice()
		{
			string choice = Console.ReadLine();
			return string.IsNullOrEmpty(choice) ? string.Empty : choice;
		}

		static void RunAlgorithm(string choice, Dictionary<string, IAlgorithm> algorithms)
		{
			if (algorithms.TryGetValue(choice, out IAlgorithm algorithm))
			{
				algorithm.Run();
			}
			else
			{
				Console.WriteLine("Invalid choice. Please select a valid option.");
			}
		}
	}
}

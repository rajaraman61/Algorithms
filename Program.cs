using Algorithms.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		static Dictionary<string, ISortAlgorithm> DiscoverAlgorithms()
		{
			// Create a dictionary to store algorithms
			var algorithms = new Dictionary<string, ISortAlgorithm>();

			// Get all types that implement IAlgorithm
			var algorithmTypes = Assembly.GetExecutingAssembly()
			.GetTypes()
										 .Where(t => typeof(ISortAlgorithm).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
										 .ToList();

			// Instantiate and add each algorithm to the dictionary
			for (int i = 0; i < algorithmTypes.Count; i++)
			{
				ISortAlgorithm algorithm = null;
				try
				{
					algorithm = (ISortAlgorithm)Activator.CreateInstance(algorithmTypes[i]);
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

		static void DisplayMenu(Dictionary<string, ISortAlgorithm> algorithms)
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

		static void RunAlgorithm(string choice, Dictionary<string, ISortAlgorithm> algorithms)
		{
			if (algorithms.TryGetValue(choice, out ISortAlgorithm algorithm))
			{
				var stopWatch = Stopwatch.StartNew();
				algorithm.Run();
				stopWatch.Stop();
				Console.WriteLine($"Total execution time for {algorithm.GetDescription()}: {stopWatch.ElapsedMilliseconds} ms");
			}
			else
			{
				Console.WriteLine("Invalid choice. Please select a valid option.");
			}
		}
	}
}

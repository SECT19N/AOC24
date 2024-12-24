using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC24.Model {
	public class DayFive {
		public static List<string> ReadRules() {
			List<string> output = new List<string>();
			var allLines = File.ReadAllLines("./Input/DayFive.txt").ToList();

			foreach (var line in allLines) {
				if (line.Contains('|')) {
					output.Add(line);
				}
			}

			return output;
		}

		public static List<string> ReadUpdates() {
			List<string> output = new List<string>();
			var allLines = File.ReadAllLines("./Input/DayFive.txt").ToList();

			foreach (var line in allLines) {
				if (line.Contains(",")) {
					output.Add(line);
				}
			}

			return output;
		}

		public static int SumOfCorrectMiddlePages() {
			int sum = 0;

			List<string> updates = ReadUpdates();
			List<string> rules = ReadRules();

			var orderingRules = ParseRules(rules);

			foreach (var update in updates) {
				var updatePages = update.Split(',').Select(int.Parse).ToList();

				if (IsUpdateCorrect(updatePages, orderingRules)) {
					int middlePage = updatePages[updatePages.Count / 2];
					sum += middlePage;
				}
			}

			return sum;
		}

		public static int SumOfReorderedMiddlePages() {
			int sum = 0;

			List<string> updates = ReadUpdates();
			List<string> rules = ReadRules();

			var orderingRules = ParseRules(rules);

			foreach (var update in updates) {
				var updatePages = update.Split(',').Select(int.Parse).ToList();

				if (!IsUpdateCorrect(updatePages, orderingRules)) {
					var reorderedPages = ReorderUpdate(updatePages, orderingRules);

					int middlePage = reorderedPages[reorderedPages.Count / 2];
					sum += middlePage;
				}
			}

			return sum;
		}

		private static List<int> ReorderUpdate(List<int> update, Dictionary<int, List<int>> rules) {
			var graph = new Dictionary<int, List<int>>();
			var indegree = new Dictionary<int, int>();

			foreach (var page in update) {
				graph[page] = [];
				indegree[page] = 0;
			}

			foreach (var rule in rules) {
				int pageX = rule.Key;
				foreach (var pageY in rule.Value) {
					if (update.Contains(pageX) && update.Contains(pageY)) {
						graph[pageX].Add(pageY);
						indegree[pageY]++;
					}
				}
			}

			var queue = new Queue<int>(indegree.Where(x => x.Value == 0).Select(x => x.Key));
			var sorted = new List<int>();

			while (queue.Count > 0) {
				var current = queue.Dequeue();
				sorted.Add(current);

				foreach (var neighbor in graph[current]) {
					indegree[neighbor]--;
					if (indegree[neighbor] == 0) {
						queue.Enqueue(neighbor);
					}
				}
			}

			return sorted;
		}

		private static Dictionary<int, List<int>> ParseRules(List<string> rules) {
			var ruleDict = new Dictionary<int, List<int>>();

			foreach (var rule in rules) {
				var parts = rule.Split('|').Select(int.Parse).ToArray();

				if (!ruleDict.ContainsKey(parts[0])) {
					ruleDict[parts[0]] = [];
				}

				ruleDict[parts[0]].Add(parts[1]);
			}

			return ruleDict;
		}

		private static bool IsUpdateCorrect(List<int> update, Dictionary<int, List<int>> rules) {
			var positions = update
				.Select((page, index) => new { page, index })
				.ToDictionary(x => x.page, x => x.index);

			foreach (var rule in rules) {
				int pageX = rule.Key;

				foreach (var pageY in rule.Value) {
					if (!positions.ContainsKey(pageX) || !positions.ContainsKey(pageY)) {
						continue;
					}

					if (positions[pageX] >= positions[pageY]) {
						return false;
					}
				}
			}

			return true;
		}
	}
}
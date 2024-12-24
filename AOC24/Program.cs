using AOC24.Model;

namespace AOC24;

public class Program {
	static void Main(string[] args) {
		Console.WriteLine("Day One");
		Console.WriteLine($"Sum of Differences: {DayOne.Sum()}.");
		Console.WriteLine($"Score of similarity: {DayOne.Similiarity()}.");

		Console.WriteLine("Day Two");
		Console.WriteLine($"Safe reports: {DayTwo.CheckSafety()}.");
		Console.WriteLine($"Safe reports with dampeners: {DayTwo.CheckSafetyWithDampeners()}.");

		Console.WriteLine("Day Three");
		Console.WriteLine($"Uncorrupted mul scores: {DayThree.AddUp()}.");
		Console.WriteLine($"Uncorrupted mul scores with checks: {DayThree.AddUpWithCheck()}.");

		Console.WriteLine("Day Four");
		Console.WriteLine($"XMAS occurs {DayFour.CountOccurrences()} times.");
		Console.WriteLine($"X-MAS occurs {DayFour.CountXMASPatterns()} times.");

		Console.WriteLine("Day Five");
		Console.WriteLine($"Sum of correctly-ordered middle pages: {DayFive.SumOfCorrectMiddlePages()}");
	}
}
using AOC24.Model;

namespace AOC24;

public class Program {
	static void Main(string[] args) {
		Console.WriteLine($"Sum of Differences: {DayOne.Sum()}");
		Console.WriteLine($"Score of similarity: {DayOne.Similiarity()}");

		Console.WriteLine($"Safe reports: {DayTwo.CheckSafety()}");
		Console.WriteLine($"Safe reports with dampeners: {DayTwo.CheckSafetyWithDampeners()}");
	}
}
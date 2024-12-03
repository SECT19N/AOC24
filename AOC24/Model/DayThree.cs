using System.Text.RegularExpressions;

namespace AOC24.Model;

public class DayThree {
	public static string ReadString() {
		return File.ReadAllText("./Input/DayThree.txt");
	}

	public static List<string> FindPattern() {
		List<string> patterns = [];

		string regex = @"mul\(\d{1,3},\d{1,3}\)";

		MatchCollection matches = Regex.Matches(ReadString(), regex);

		foreach (Match match in matches) {
			patterns.Add(match.Value);
		}

		return patterns;
	}

	public static int AddUp() {
		int add = 0;

		List<string> muls = FindPattern();

		foreach (string mul in muls) {
			string regex = @"\d{1,3}";

			MatchCollection matches = Regex.Matches(mul, regex);

			int score = 1;

			foreach (Match match in matches) {
				score *= int.Parse(match.Value);
			}

			add += score;
		}

		return add;
	}
}
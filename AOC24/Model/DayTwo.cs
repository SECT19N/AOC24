namespace AOC24.Model;

public class DayTwo {
	public static List<string> ReadString() {
		return File.ReadAllLines("./Input/DayTwo.txt").ToList();
	}

	public static bool SafeDifference(int left, int right) {
		return Math.Abs(left - right) >= 1 && Math.Abs(left - right) <= 3;
	}

	public static string IsOrdered(string line) {
		string[] parts = line.Trim().Split(" ");

		List<int> ints = parts.Select(int.Parse).ToList();

		bool ascending = true, descending = true;

		for (int i = 0; i < ints.Count - 1; i++) {
			if (ints[i] > ints[i + 1]) {
				ascending = false;
			}
			if (ints[i] < ints[i + 1]) {
				descending = false;
			}
		}

		if (ascending) {
			return "Asc";
		} else if (descending) {
			return "Desc";
		} else {
			return "Unsafe";
		}
	}

	public static int CheckSafety() {
		int safeCount = 0;

		List<string> reports = ReadString();

		foreach (string line in reports) {
			if (IsOrdered(line) == "Asc" || IsOrdered(line) == "Desc") {
				bool safe = false;

				string[] parts = line.Trim().Split(" ");

				List<int> ints = parts.Select(int.Parse).ToList();

				for (int i = 0; i < ints.Count - 1; i++) {
					if (SafeDifference(ints[i], ints[i + 1]) == false) {
						safe = false;
						break;
					} else {
						safe = true;
					}
				}

				if (safe == true) {
					safeCount++;
				}
			}
		}

		return safeCount;
	}

	static bool IsSafe(List<int> levels) {
		int n = levels.Count;

		List<int> differences = [];

		for (int i = 0; i < n - 1; i++) {
			differences.Add(levels[i + 1] - levels[i]);
		}

		bool increasing = differences.All(diff => diff >= 1 && diff <= 3);
		bool decreasing = differences.All(diff => diff <= -1 && diff >= -3);

		return increasing || decreasing;
	}

	public static int CheckSafetyWithDampeners() {
		int safeCount = 0;

		List<string> rawReports = ReadString();

		List<List<int>> reports = rawReports.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();

		foreach (List<int> levels in reports) {
			if (IsSafe(levels)) {
				safeCount++;
			} else {
				bool foundSafe = false;

				for (int i = 0; i < levels.Count; i++) {
					List<int> modified = new(levels);
					modified.RemoveAt(i);

					if (IsSafe(modified)) {
						safeCount++;
						foundSafe = true;
						break;
					}
				}

				if (foundSafe)
					continue;
			}
		}

		return safeCount;
	}
}
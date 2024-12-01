namespace AOC24.Model;

public class DayOne {
	public static List<string> ReadString() {
		return File.ReadAllLines("./Input/DayOne.txt").ToList();
	}

	public static int Sum() {
		int sum = 0;

		List<int> leftNums = [];
		List<int> rightNums = [];

		foreach (string line in ReadString()) {
			string[] parts = line.Split("   ");

			leftNums.Add(int.Parse(parts[0]));
			rightNums.Add(int.Parse(parts[1]));
		}

		leftNums.Sort();
		rightNums.Sort();

		for (int i = 0; i < leftNums.Count; i++) {
			sum += Difference(leftNums[i], rightNums[i]);
		}

		return sum;
	}

	public static int Difference(int left, int right) {
		return Math.Abs(left - right);
	}
	
	public static int Similiarity() {
		int score = 0;

		List<int> leftNums = [];
		List<int> rightNums = [];

		foreach (string line in ReadString()) {
			string[] parts = line.Split("   ");

			leftNums.Add(int.Parse(parts[0]));
			rightNums.Add(int.Parse(parts[1]));
		}

		foreach (int left in leftNums) {
			int sim = 0;

			foreach (int right in rightNums) {
				if (left == right) {
					sim++;
				}
			}

			score += left * sim;
		}

		return score;
	}
}
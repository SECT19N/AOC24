namespace AOC24.Model;

public class DayFour {
	static char[,] ConvertInputToGrid() {
		string[] lines = File.ReadAllLines("./Input/DayFour.txt");
		int rows = lines.Length;
		int cols = lines[0].Length;

		char[,] grid = new char[rows, cols];

		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				grid[row, col] = lines[row][col];
			}
		}

		return grid;
	}

	public static int CountOccurrences(string word) {
		char[,] grid = ConvertInputToGrid();
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		int wordLength = word.Length;
		int count = 0;

		int[,] directions = {
			{ 0, 1 },   // Right
            { 1, 0 },   // Down
            { 0, -1 },  // Left
            { -1, 0 },  // Up
            { 1, 1 },   // Diagonal Down-Right
            { 1, -1 },  // Diagonal Down-Left
            { -1, 1 },  // Diagonal Up-Right
            { -1, -1 }  // Diagonal Up-Left
        };

		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				for (int d = 0; d < directions.GetLength(0); d++) {
					int rowOffset = directions[d, 0];
					int colOffset = directions[d, 1];

					if (CanFindWord(grid, word, row, col, rowOffset, colOffset)) {
						count++;
					}
				}
			}
		}

		return count;
	}


	static bool CanFindWord(char[,] grid, string word, int startRow, int startCol, int rowOffset, int colOffset) {
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		int wordLength = word.Length;

		for (int i = 0; i < wordLength; i++) {
			int newRow = startRow + i * rowOffset;
			int newCol = startCol + i * colOffset;

			if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow, newCol] != word[i]) {
				return false;
			}
		}

		return true;
	}
}
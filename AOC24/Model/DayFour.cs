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

	public static int CountOccurrences() {
		char[,] grid = ConvertInputToGrid();
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
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

					if (CanFindWord(grid, row, col, rowOffset, colOffset)) {
						count++;
					}
				}
			}
		}

		return count;
	}


	static bool CanFindWord(char[,] grid, int startRow, int startCol, int rowOffset, int colOffset) {
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		int wordLength = "XMAS".Length;

		for (int i = 0; i < wordLength; i++) {
			int newRow = startRow + i * rowOffset;
			int newCol = startCol + i * colOffset;

			if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow, newCol] != "XMAS"[i]) {
				return false;
			}
		}

		return true;
	}

	public static int CountXMASPatterns() {
		char[,] grid = ConvertInputToGrid();
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		int count = 0;

		for (int row = 0; row < rows - 2; row++) {
			for (int col = 0; col < cols - 2; col++) {
				if (IsXMASPattern(grid, row, col, forward: true) ||
					IsXMASPattern(grid, row, col, forward: false)) {
					count++;
				}
			}
		}

		return count;
	}

	static bool IsXMASPattern(char[,] grid, int row, int col, bool forward) {
		char topLeft = grid[row, col];
		char center = grid[row + 1, col + 1];
		char bottomRight = grid[row + 2, col + 2];

		char topRight = grid[row, col + 2];
		char bottomLeft = grid[row + 2, col];

		if (forward) {
			bool output = false;

			if (topLeft == 'M' && center == 'A' && bottomRight == 'S' && topRight == 'S' && bottomLeft == 'M') {
				output = true;
			} else if (topLeft == 'M' && center == 'A' && bottomRight == 'S' && topRight == 'M' && bottomLeft == 'S') {
				output = true;
			} else if (topLeft == 'S' && center == 'A' && bottomRight == 'M' && topRight == 'M' && bottomLeft == 'S') {
				output = true;
			} else if (topLeft == 'S' && center == 'A' && bottomRight == 'M' && topRight == 'S' && bottomLeft == 'M') {
				output = true;
			}

			return output;
		} else {
			return topLeft == 'S' && center == 'A' && bottomRight == 'M' &&
				   topRight == 'M' && bottomLeft == 'S';
		}
	}
}
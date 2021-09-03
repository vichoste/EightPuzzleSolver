using System;
using System.Collections.Generic;
using System.Linq;

namespace EightPuzzleSolver.Puzzle;

/// <summary>
/// Play game
/// </summary>
internal class Play {
	#region Attributes
	private List<string> board;
	private (int Row, int Column) emptyCellPosition;
	#endregion
	#region Properties
	/// <summary>
	/// Board game
	/// </summary>
	public List<string> Board {
		get => this.board;
		internal set {
			if (value.Count != 9) {
				throw new ArgumentException("Board needs 9 values");
			}
			string[] validNumbers = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
			if (!value.Intersect(validNumbers).Any()) {
				throw new ArgumentException("Only numbers from 0 to 8 are allowed");
			}
			this.board = value;
		}
	}
	/// <summary>
	/// Move counter
	/// </summary>
	public long Moves {
		get; internal set;
	}
	/// <summary>
	/// Current position of the empty cell
	/// </summary>
	public (int Row, int Column) EmptyCellPosition {
		get => (this.emptyCellPosition.Row, this.emptyCellPosition.Column);
		internal set {
			if (value.Row < 0 || value.Row > 2 || value.Column < 0 || value.Column > 2) {
				throw new IndexOutOfRangeException($"Cell position ({value.Row}, {value.Column}) is out of range.");
			}
			this.emptyCellPosition = value;
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	public Play() {
		// Creates the new board
		this.board = new() {
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8"
		};
		// Safely shuffle the board
		do {
			this.Shuffle();
		} while (!this.IsSolvable());
	}
	#endregion
	#region Methods
	/// <summary>
	/// Checks if the board is solvable
	/// Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	/// <returns>True if it has solution</returns>
	private bool IsSolvable() {
		int result = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = i + 1; j < 3; j++) {
				if (int.Parse(this.board[i * 3 + j]) > 0 && int.Parse(this.board[i * 3 + j]) > int.Parse(this.board[i * 3 + j])) { // Assuming they will always be integers
					result++;
				}
			}
		}
		return result % 2 == 0;
	}
	/// <summary>
	/// Randomizes the values within the board
	/// Source: http://csharphelper.com/blog/2016/10/randomize-two-dimensional-arrays-in-c/
	/// </summary>
	private void Shuffle() {
		Random random = new();
		for (int i = 0; i < 8; i++) {
			int j = random.Next(i, 9);
			int rowI = i / 3;
			int columnI = i % 3;
			int rowJ = j / 3;
			int columnJ = j % 3;
			Swap(this.board, rowI * 3 + columnI, rowJ * 3 + columnJ);
			this.EmptyCellPosition = int.Parse(this.board[rowI * 3 + columnI]) == 0 ? (rowI, columnI) : int.Parse(this.board[rowJ * 3 + columnJ]) == 0 ? (rowJ, columnJ) : this.EmptyCellPosition; // Save the position of the empty cell for quick access
		}
	}
	#endregion
	#region Static methods
	/// <summary>
	/// Swaps two numbers within the board
	/// </summary>
	/// <param name="firstCell">First cell</param>
	/// <param name="secondCell">Second cell</param>
	private static void Swap(List<string> board, int firstIndex, int secondIndex) {
		string temp = board[firstIndex];
		board[firstIndex] = board[secondIndex];
		board[secondIndex] = temp;
	}
	/// <summary>
	/// Moves the empty cell
	/// </summary>
	/// <param name="board">Board which we want to move the cell</param>
	/// <param name="direction">Direction of the movement</param>
	/// <param name="emptyCellPosition">The position of the empty cell</param>
	/// <returns>Tuple of new empty cell coordinates and the board with the new positions because of the movement operation. If the movement is invalid, return unchanged</returns>
	public static ((int Row, int Column) EmptyCellPosition, List<string> Board) Move(List<string> board, Direction direction, (int Row, int Column) emptyCellPosition) {
		if (direction == Direction.Up && emptyCellPosition.Row - 1 < 0 || direction == Direction.Down && emptyCellPosition.Row + 1 > 2 || direction == Direction.Left && emptyCellPosition.Column - 1 < 0 || direction == Direction.Right && emptyCellPosition.Column + 1 > 2) {
			return (emptyCellPosition, board);
		}
		List<string> @new = new(board);
		switch (direction) {
			case Direction.Up:
				Swap(@new, emptyCellPosition.Row * 3 + emptyCellPosition.Column, ( emptyCellPosition.Row - 1 ) * 3 + emptyCellPosition.Column);
				return ((emptyCellPosition.Row - 1, emptyCellPosition.Column), @new);
			case Direction.Down:
				Swap(@new, emptyCellPosition.Row * 3 + emptyCellPosition.Column, ( emptyCellPosition.Row + 1 ) * 3 + emptyCellPosition.Column);
				return ((emptyCellPosition.Row + 1, emptyCellPosition.Column), @new);
			case Direction.Left:
				Swap(@new, emptyCellPosition.Row * 3 + emptyCellPosition.Column, emptyCellPosition.Row * 3 + emptyCellPosition.Column - 1);
				return ((emptyCellPosition.Row, emptyCellPosition.Column - 1), @new);
			case Direction.Right:
				Swap(@new, emptyCellPosition.Row * 3 + emptyCellPosition.Column, emptyCellPosition.Row * 3 + emptyCellPosition.Column + 1);
				return ((emptyCellPosition.Row, emptyCellPosition.Column + 1), @new);
		}
		return (emptyCellPosition, board);
	}
	#endregion
}
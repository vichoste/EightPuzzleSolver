using System;
using System.Collections.Generic;

namespace EightPuzzleSolver.Puzzle;

/// <summary>
/// Play game
/// </summary>
internal class Play {
	#region Properties
	/// <summary>
	/// Board game
	/// </summary>
	public List<string> Board {
		get; internal set;
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
		get; internal set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	public Play() {
		// Creates the grid
		this.Board = new() {
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
		// Safely shuffle the grid
		do {
			this.Shuffle();
		} while (!this.IsSolvable());
	}
	#endregion
	#region Methods
	/// <summary>
	/// Swaps number value between two cells
	/// </summary>
	/// <param name="firstCell">First cell</param>
	/// <param name="secondCell">Second cell</param>
	private void Swap(int firstIndex, int secondIndex) {
		string temp = this.Board[firstIndex];
		this.Board[firstIndex] = this.Board[secondIndex];
		this.Board[secondIndex] = temp;
	}
	/// <summary>
	/// Moves the empty cell
	/// </summary>
	/// <param name="destination">Destination cell</param>
	/// <returns>True if the movement is valid</returns>
	public void Move(Direction direction) {
		switch (direction) {
			case Direction.Up:
				if (this.EmptyCellPosition.Row - 1 < 0) {
					return;
				}
				this.Swap(this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column, ( this.EmptyCellPosition.Row - 1 ) * 3 + this.EmptyCellPosition.Column);
				this.EmptyCellPosition = (this.EmptyCellPosition.Row - 1, this.EmptyCellPosition.Column);
				break;
			case Direction.Down:
				if (this.EmptyCellPosition.Row + 1 > 2) {
					return;
				}
				this.Swap(this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column, ( this.EmptyCellPosition.Row + 1 ) * 3 + this.EmptyCellPosition.Column);
				this.EmptyCellPosition = (this.EmptyCellPosition.Row + 1, this.EmptyCellPosition.Column);
				break;
			case Direction.Left:
				if (this.EmptyCellPosition.Column - 1 < 0) {
					return;
				}
				this.Swap(this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column, this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column - 1);
				this.EmptyCellPosition = (this.EmptyCellPosition.Row, this.EmptyCellPosition.Column - 1);
				break;
			case Direction.Right:
				if (this.EmptyCellPosition.Column + 1 > 2) {
					return;
				}
				this.Swap(this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column, this.EmptyCellPosition.Row * 3 + this.EmptyCellPosition.Column + 1);
				this.EmptyCellPosition = (this.EmptyCellPosition.Row, this.EmptyCellPosition.Column + 1);
				break;
		}
	}
	#endregion
	#region "Inspirations"
	/// <summary>
	/// Checks if the board is solvable
	/// Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	/// <returns>True if it has solution</returns>
	private bool IsSolvable() {
		int result = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = i + 1; j < 3; j++) {
				if (int.Parse(this.Board[i * 3 + j]) > 0 && int.Parse(this.Board[i * 3 + j]) > int.Parse(this.Board[i * 3 + j])) { // Assuming they will always be integers
					result++;
				}
			}
		}
		return result % 2 == 0;
	}
	/// <summary>
	/// Randomizes the values of the board cells
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
			this.Swap(rowI * 3 + columnI, rowJ * 3 + columnJ);
			this.EmptyCellPosition = int.Parse(this.Board[rowI * 3 + columnI]) == 0 ? (rowI, columnI) : int.Parse(this.Board[rowJ * 3 + columnJ]) == 0 ? (rowJ, columnJ) : this.EmptyCellPosition; // Save the position of the empty cell for quick access
		}
	}
	#endregion
}
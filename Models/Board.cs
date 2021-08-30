using System;
using System.Collections.Generic;

namespace EightPuzzleSolver.Models;

/// <summary>
/// Board game
/// </summary>
internal class Board {
	#region Attributes
	/// <summary>
	/// Current state of the board
	/// </summary>
	private readonly Cell[][] Cells;
	/// <summary>
	/// This is the winning combination. Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	private readonly int[][] WinningCombination = new int[][] {
		new int[] {1, 2, 3},
		new int[] {4, 5, 6},
		new int[] {7, 8, 0}
	};
	#endregion
	#region Properties
	/// <summary>
	/// Move counter
	/// </summary>
	public long Moves {
		get; internal set;
	}
	/// <summary>
	/// Gets the current state of the board for displaying at the window
	/// </summary>
	public List<(string Number, bool IsActive)> Current {
		get {
			List<(string Number, bool IsActive)> result = new();
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					result.Add((this.Cells[i][j].Number, this.Cells[i][j].IsActive));
				}
			}
			return result;
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	internal Board() {
		// Creates the grid
		this.Cells = new Cell[][] {
			new Cell[] {new Cell("0"), new Cell("1"), new Cell("2")},
			new Cell[] {new Cell("3"), new Cell("4"), new Cell("5")},
			new Cell[] {new Cell("6"), new Cell("7"), new Cell("8")}
		};
		// Safely shuffle the grid
		do {
			this.Shuffle();
		} while (!this.IsSolvable() && !this.IsSolved());
	}
	#endregion
	#region Methods
	/// <summary>
	/// Checks if the game is solved
	/// I am lazy to implement a more efficient way of doing this. The arrays will be always 3x3 anyways.
	/// </summary>
	/// <returns>If true, the player has won</returns>
	internal bool IsSolved() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (int.Parse(this.Cells[i][j].Number) != this.WinningCombination[i][j]) { // Assuming parse will always give an integer
					return false; // One number mismatch and the game will be considered not solved.
				}
			}
		}
		return true;
	}
	#endregion
	#region "Inspirations"
	/// <summary>
	/// Checks if the grid is solvable
	/// Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	/// <returns>True if it has solution</returns>
	private bool IsSolvable() {
		int result = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = i + 1; j < 3; j++) {
				if (int.Parse(this.Cells[i][j].Number) > 0 && int.Parse(this.Cells[i][j].Number) > int.Parse(this.Cells[i][j].Number)) { // Assuming they will always be integers
					result++;
				}
			}
		}
		return result % 2 == 0;
	}
	/// <summary>
	/// Randomizes the values of the grid
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
			string temp = this.Cells[rowI][columnI].Number;
			this.Cells[rowI][columnI].Number = this.Cells[rowJ][columnJ].Number;
			this.Cells[rowJ][columnJ].Number = temp;
		}
	}
	#endregion
}
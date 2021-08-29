using System;
using System.Collections.Generic;

namespace EightPuzzleSolver.Models;

/// <summary>
/// [You have lost] The game itself.
/// </summary>
internal class Game {
	#region Attributes
	/// <summary>
	/// Current state of the grid
	/// </summary>
	internal readonly Cell[][] GridValues;
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
	/// Current state of the first column of the grid for displaying at the game window
	/// </summary>
	public List<Cell> CurrentGrid {
		get {
			List<Cell> result = new();
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					result.Add(this.GridValues[i][j]);
				}
			}
			return result;
		}
	}
	/// <summary>
	/// Gets a string value for a cell
	/// </summary>
	/// <param name="row">Row position</param>
	/// <param name="column">Column position</param>
	/// <returns>Current value in string</returns>
	public string this[int row, int column] {
		get => this.GridValues[row][column].Number;
		internal set => this.GridValues[row][column].Number = value;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	public Game() {
		// Creates the grid
		this.GridValues = new Cell[][] {
			new Cell[] {new Cell("0"), new Cell("1"), new Cell("2")},
			new Cell[] {new Cell("3"), new Cell("4"), new Cell("5")},
			new Cell[] {new Cell("6"), new Cell("7"), new Cell("8")}
		};
		// Safely shuffle the grid
		do {
			this.ShuffleGrid();
		} while (!this.IsGridSolvable() && !this.IsSolved());
		this.GridValues[0][0].IsActive = true;
	}
	#endregion
	#region Methods
	/// <summary>
	/// Checks if the game is solved
	/// </summary>
	/// <returns>If true, the player has won</returns>
	public bool IsSolved() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (int.Parse(this[i, j]) != this.WinningCombination[i][j]) { // Assuming parse will always give an integer
					return false; // One number mismatch and the game will be considered not solved.
				}
			}
		}
		return true;
	}
	#endregion
	#region "Inspirations"
	/// <summary>
	/// Checks if the grid is solvable.
	/// Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	/// <returns>True if it has solution</returns>
	private bool IsGridSolvable() {
		int result = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = i + 1; j < 3; j++) {
				if (int.Parse(this[j,i]) > 0 && int.Parse(this[j,i]) > int.Parse(this[i,j])) { // Assuming they will always be integers
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
	private void ShuffleGrid() {
		Random random = new();
		for (int i = 0; i < 8; i++) {
			int j = random.Next(i, 9);
			int rowI = i / 3;
			int columnI = i % 3;
			int rowJ = j / 3;
			int columnJ = j % 3;
			string temp = this.GridValues[rowI][columnI].Number;
			this.GridValues[rowI][columnI].Number = this.GridValues[rowJ][columnJ].Number;
			this.GridValues[rowJ][columnJ].Number = temp;
		}
	}
	#endregion
}
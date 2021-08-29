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
	private readonly Cell[][] GridValues;
	#endregion
	#region Properties
	/// <summary>
	/// Move counter
	/// </summary>
	public long Moves {
		get; private set;
	}
	/// <summary>
	/// Current state of the first column of the grid for displaying at the game window
	/// </summary>
	public List<string> CurrentGrid {
		get {
			List<string> result = new();
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					result.Add(this.GridValues[i][j].ToString());
				}
			}
			return result;
		}
	}
	public string this[byte row, byte column] {

	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	public Game() {
		// Creates the grid
		this.GridValues = new Cell[][] {
			new Cell[] {new Cell(0), new Cell(1), new Cell(2)},
			new Cell[] {new Cell(3), new Cell(4), new Cell(5)},
			new Cell[] {new Cell(6), new Cell(7), new Cell(8)}
		};
		// Safely shuffle the grid
		do {
			this.ShuffleGrid();
		} while (!this.IsGridSolvable());
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
				if (this.GridValues[j][i] > 0 && this.GridValues[j][i] > this.GridValues[i][j]) {
					result++;
				}
			}
		}
		return result % 2 == 0;
	}
	/// <summary>
	/// Randomizes the values of the grid
	/// Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	private void ShuffleGrid() {
		Random random = new();
		for (int i = 0; i < 8; i++) {
			int j = random.Next(i, 9);
			int rowIndexI = i / 3;
			int columnIndexI = i % 3;
			int rowIndexJ = j / 3;
			int columnIndexJ = j % 3;
			byte temporaryValue = this.GridValues[rowIndexI][columnIndexI];
			this.GridValues[rowIndexI][columnIndexI] = this.GridValues[rowIndexJ][columnIndexJ];
			this.GridValues[rowIndexJ][columnIndexJ] = temporaryValue;
		}
	}
	#endregion
}
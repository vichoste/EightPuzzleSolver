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
	private byte[][] GridValues = new byte[][] { new byte[] { 0, 1, 2 }, new byte[] { 3, 4, 5 }, new byte[] { 6, 7, 8 } };
	#endregion
	#region Properties
	/// <summary>
	/// Move counter
	/// </summary>
	public long MoveAmount {
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
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a game
	/// </summary>
	public Game() {
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
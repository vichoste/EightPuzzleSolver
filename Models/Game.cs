using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleSolver.Models {
	/// <summary>
	/// [You have lost] The game itself.
	/// </summary>
	class Game {
		#region Attributes
		/// <summary>
		/// Current state of the grid
		/// </summary>
		private readonly byte[][] currentGrid = new byte[][] { new byte[] { 0, 1, 2 }, new byte[] { 3, 4, 5 }, new byte[] { 6, 7, 8 } };
		/// <summary>
		/// Move counter
		/// </summary>
#pragma warning disable IDE0032 // Use auto property
#pragma warning disable IDE0044 // Add readonly modifier
		private long moves = 0;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore IDE0032 // Use auto property
		#endregion
		#region Properties
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentGrid {
			get {
				List<string> result = new();
				for (int i = 0; i < 3; i++) {
					for (int j = 0; j < 3; j++) {
						result.Add(currentGrid[i][j].ToString());
					}
				}
				return result;
			}
		}
		/// <summary>
		/// Amount of moves done
		/// </summary>
		public long Moves => this.moves;
		#endregion
		#region Constructors
		/// <summary>
		/// Creates a game
		/// </summary>
		public Game() {
			// Safely shuffle the grid
			do {
				ShuffleGrid();
			} while (!IsGridSolvable());
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
					if (this.currentGrid[j][i] > 0 && this.currentGrid[j][i] > this.currentGrid[i][j]) {
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
				byte temp = this.currentGrid[rowIndexI][columnIndexI];
				this.currentGrid[rowIndexI][columnIndexI] = this.currentGrid[rowIndexJ][columnIndexJ];
				this.currentGrid[rowIndexJ][columnIndexJ] = temp;
			}
		}
		#endregion
	}
}

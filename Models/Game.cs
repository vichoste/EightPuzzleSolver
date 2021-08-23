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
	sealed class Game {
		/// <summary>
		/// Current state of the grid
		/// </summary>
		private readonly byte[,] currentGrid = new byte[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
		/// <summary>
		/// Current state of the grid
		/// </summary>
		public List<byte> CurrentGridRows {
			get {
				List<byte> result = new();
				for (int i = 0; i < 3; i++) {
					for (int j = 0; j < 3; j++) {
						result.Add(currentGrid[i, j]);
					}
				}
				return result;
			}
		}
		/// <summary>
		/// Creates a game
		/// </summary>
		public Game() {
		}
	}
}

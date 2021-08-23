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
		#region Private
		/// <summary>
		/// Current state of the grid
		/// </summary>
		private readonly byte[][] currentGrid = new byte[][] { new byte[] { 0, 1, 2 }, new byte[] { 3, 4, 5 }, new byte[] { 6, 7, 8 } };
		#endregion
		#region Observables
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentFirstColumn {
			get {
				List<string> result = new();
				for (int i = 0; i < 3; i++) {
					result.Add(currentGrid[i][0].ToString());
				}
				return result;
			}
		}
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentSecondColumn {
			get {
				List<string> result = new();
				for (int i = 0; i < 3; i++) {
					result.Add(currentGrid[i][1].ToString());
				}
				return result;
			}
		}
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentThirdColumn {
			get {
				List<string> result = new();
				for (int i = 0; i < 3; i++) {
					result.Add(currentGrid[i][2].ToString());
				}
				return result;
			}
		}
		#endregion
		/// <summary>
		/// Creates a game
		/// </summary>
		public Game() {
		}
	}
}

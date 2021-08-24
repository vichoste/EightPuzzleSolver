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
		public List<string> CurrentFirstColumn {
			get {
				List<string> result = new();
				result.Add(currentGrid[0][0].ToString());
				result.Add(currentGrid[1][0].ToString());
				result.Add(currentGrid[2][0].ToString());
				return result;
			}
		}
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentSecondColumn {
			get {
				List<string> result = new();
				result.Add(currentGrid[0][1].ToString());
				result.Add(currentGrid[1][1].ToString());
				result.Add(currentGrid[2][1].ToString());
				return result;
			}
		}
		/// <summary>
		/// Current state of the first column of the grid for displaying at the game window
		/// </summary>
		public List<string> CurrentThirdColumn {
			get {
				List<string> result = new();
				result.Add(currentGrid[0][2].ToString());
				result.Add(currentGrid[1][2].ToString());
				result.Add(currentGrid[2][2].ToString());
				return result;
			}
		}
		/// <summary>
		/// Amount of moves done
		/// </summary>
		public long Moves => this.moves;
		#endregion
		/// <summary>
		/// Creates a game
		/// </summary>
		public Game() {
		}
	}
}

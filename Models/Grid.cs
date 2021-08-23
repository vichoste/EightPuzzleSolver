using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleSolver.Models {
	/// <summary>
	/// This is the grid puzzle who holds the numbers
	/// </summary>
	sealed class Grid {
		/// <summary>
		/// Private instance of the grid
		/// </summary>
		private byte[,] grid = new byte[3, 3];
		/// <summary>
		/// Creates the grid
		/// </summary>
		public Grid() {
		}
	}
}

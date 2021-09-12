using System;
using System.Collections.Generic;

namespace EightPuzzleSolver.Models;
/// <summary>
/// This is a cell from the board
/// </summary>
public class CellModel {
	#region Properties
	/// <summary>
	/// Value number from the cell
	/// </summary>
	public int Value {
		get; set;
	}
	/// <summary>
	/// Checks if this cell was the last one moved
	/// </summary>
	public bool IsTheLastMovement {
		get; set;
	}
	#endregion
	#region Static properties
	/// <summary>
	/// Solved combination
	/// </summary>
	public static readonly int SolvedCombination = 87654321;
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a cell
	/// </summary>
	public CellModel() {
	}
	#endregion
	#region Static methods
	/// <summary>
	/// Calculates a combination number
	/// </summary>
	/// <param name="board">Board</param>
	/// <returns>Board combination number</returns>
	public static int CalculateCombination(List<CellModel> board) {
		var combination = 0;
		/* How this works:
		 * There are 9 positions. So, in order to generate an ID that represents the board combination, that is comparable to others, the following will be done:
		 * ID = sum(
		 * state[0] * 1
		 * state[1] * 10
		 * state[2] * 100
		 * state[3] * 1000
		 * state[4] * 10000
		 * state[5] * 100000
		 * state[6] * 1000000
		 * state[7] * 10000000
		 * state[8] * 100000000
		 * state[9] * 1000000000)
		 */
		for (var i = 0; i < 9; i++) {
			combination += board[i].Value * (int) Math.Pow(10, i); // Assuming both parsing and combination are integers
		}
		return combination;
	}
	#endregion
}
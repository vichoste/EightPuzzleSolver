using System.Collections.Generic;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// This is a path finding algorithm
/// </summary>
interface IPathFinding {
	/// <summary>
	/// Solve a board
	/// </summary>
	/// <param name="numbers">The board combination</param>
	void Solve(List<string> combination);
}

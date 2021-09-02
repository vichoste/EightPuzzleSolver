using System.Collections.Generic;

namespace EightPuzzleSolver.Algorithms;

/// <summary>
/// This is a path finding algorithm
/// </summary>
internal interface IPathFinding {
	/// <summary>
	/// Solve a board
	/// </summary>
	/// <returns>Number of resulting nodes with the winning combination</returns>
	(int, List<string>) Solve();
}

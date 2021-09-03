using System.Collections.Generic;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class BreadthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public BreadthFirstSearch(List<string> board, (int, int) emptyCellPosition) : base(board, emptyCellPosition) {
		
	}
}
using System.Collections.Generic;

using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class BreadthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public BreadthFirstSearch(List<string> board, (int, int) emptyCellPosition) : base(board, emptyCellPosition) {
		do {
			var MoveFreedom = CheckMoveFreedom(emptyCellPosition);
			
		} while (this.SolutionPath.Peek() is Vertex vertex && vertex.UniqueId == Vertex.SolvedUniqueId);
	}
}
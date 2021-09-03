using System.Collections.Generic;

using EightPuzzleSolver.Puzzle;
using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class BreadthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public BreadthFirstSearch() : base() => this.pendingVertices = new Queue<Vertex>();
	/// <summary>
	/// Solves the board via Breadth First Search
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="emptyCellPosition">Root empty cell position</param>
	public override void Solve(List<string> board, (int Row, int Column) emptyCellPosition) {
		if (Play.CalculateUniqueId(board) != Vertex.SolvedUniqueId) {
			Queue<Vertex>? queue = this.pendingVertices as Queue<Vertex>;
			Vertex root = new(board, emptyCellPosition);
			queue.Enqueue(root);
			root.IsVisited = true;
			while (queue.Count > 0) {
				var current = queue.Dequeue();
				if (current.UniqueId == Vertex.SolvedUniqueId) {
					break;
				}
				var children = this.MakePossibleMovements(current);
				for (int i = children.Count - 1; i >= 0; i--) {
					var currentChild = children[i];
					if (!currentChild.IsVisited) {
						queue.Enqueue(currentChild);
						currentChild.IsVisited = true;
					}
				}
			}
		}
	}
}
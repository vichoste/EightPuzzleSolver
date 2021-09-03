using System.Collections.Generic;

using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class DepthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public DepthFirstSearch() : base() => this.pendingVertices = new Stack<Vertex>();
	/// <summary>
	/// Solves the board via Depth First Search
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="emptyCellPosition">Root empty cell position</param>
	/// /// <returns>Solved board. If a solved board is passed, it will return that instead</returns>
	public override ((int, int), List<string>) Solve(List<string> board, (int Row, int Column) emptyCellPosition) {
		if (Vertex.CalculateUniqueId(board) != Vertex.SolvedUniqueId) {
			Stack<Vertex>? stack = this.pendingVertices as Stack<Vertex>;
			Vertex root = new(board, emptyCellPosition);
			stack.Push(root);
			this.visitedVertices.Add(root);
			while (stack.Count > 0) {
				var current = stack.Pop();
				if (current.UniqueId == Vertex.SolvedUniqueId) {
					return (current.Position, current.State);
				}
				var children = MakePossibleMovements(current);
				for (int i = children.Count - 1; i >= 0; i--) {
					var currentChild = children[i];
					if (this.visitedVertices.Find(v => v.UniqueId == currentChild.UniqueId) is null) {
						stack.Push(currentChild);
						this.visitedVertices.Add(currentChild);
					}
				}
			}
		}
		return (emptyCellPosition, board);
	}
}
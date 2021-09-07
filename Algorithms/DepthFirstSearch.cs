using System.Collections.Generic;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class DepthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public DepthFirstSearch() : base() => this.pendingVertices = new Stack<State>();
	/// <summary>
	/// Solves the board with DFS
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="zeroX">Root zero cell row position</param>
	/// <param name="zeroY">Root zero cell column position</param>
	public override (List<CellModel>, int, int) Solve(List<CellModel> board, int zeroX, int zeroY) {
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
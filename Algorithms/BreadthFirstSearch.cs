using System.Collections.Generic;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.Structures;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// BFS pathfinding algorithm
/// </summary>
internal class BreadthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public BreadthFirstSearch() : base() => this.pendingVertices = new Queue<CellModel>();
	/// <summary>
	/// Solves the board via Breadth First Search
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="emptyCellPosition">Root empty cell position</param>
	/// /// <returns>Solved board with empty cell position. If a solved board is passed, it will return that instead</returns>
	public override List<CellModel> Solve(CellViewModel cellViewModel) {
		Queue<CellModel>? queue = this.pendingVertices as Queue<CellModel>;
		CellModel root = new(board, emptyCellPosition);
		queue.Enqueue(root);
		this.visitedVertices.Add(root);
		while (queue.Count > 0) {
			var current = queue.Dequeue();
			if (current.UniqueId == Vertex.SolvedUniqueId) {
				return (current.Position, current.State);
			}
			var children = MakePossibleMovements(current);
			for (int i = children.Count - 1; i >= 0; i--) {
				var currentChild = children[i];
				if (this.visitedVertices.Find(v => v.UniqueId == currentChild.UniqueId) is null) {
					queue.Enqueue(currentChild);
					this.visitedVertices.Add(currentChild);
				}
			}
		}
		return (emptyCellPosition, board);
	}
}
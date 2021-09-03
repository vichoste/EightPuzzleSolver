using System.Collections.Generic;
using System.Windows.Documents;

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
			Vertex root = new(board, emptyCellPosition);
			this.Graph.Add(root);
			if (emptyCellPosition.Row > 0) { // Check up
				(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Up, emptyCellPosition);
				Vertex up = new(Board, EmptyCellPosition);
				this.Graph.Add(up);
				this.NodeCount++;
			}
			if (emptyCellPosition.Row < 2) { // Check down
				(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Down, emptyCellPosition);
				Vertex down = new(Board, EmptyCellPosition);
				this.Graph.Add(down);
				this.NodeCount++;
			}
			if (emptyCellPosition.Column > 0) { // Check left
				(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Left, emptyCellPosition);
				Vertex left = new(Board, EmptyCellPosition);
				this.Graph.Add(left);
				this.NodeCount++;
			}
			if (emptyCellPosition.Column < 2) { // Check right
				(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Right, emptyCellPosition);
				Vertex right = new(Board, EmptyCellPosition);
				this.Graph.Add(right);
				this.NodeCount++;
			}

		}
	}
}
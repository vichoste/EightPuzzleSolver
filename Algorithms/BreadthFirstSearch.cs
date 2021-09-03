﻿using System.Collections.Generic;

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
	public BreadthFirstSearch(List<string> board, (int Row, int Column) emptyCellPosition) : base(board, emptyCellPosition) {
		if (Play.CalculateUniqueId(board) != Vertex.SolvedUniqueId) {
			do {
				if (emptyCellPosition.Row > 0) { // Check up
					(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Up, emptyCellPosition);
					this.Graph.Add(Board, EmptyCellPosition);
				}
				if (emptyCellPosition.Row < 2) { // Check down
					(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Down, emptyCellPosition);
					this.Graph.Add(Board, EmptyCellPosition);
				}
				if (emptyCellPosition.Column > 0) { // Check left
					(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Left, emptyCellPosition);
					this.Graph.Add(Board, EmptyCellPosition);
				}
				if (emptyCellPosition.Column < 2) { // Check right
					(var EmptyCellPosition, var Board) = Play.Move(board, Direction.Right, emptyCellPosition);
					this.Graph.Add(Board, EmptyCellPosition);
				}
			} while (this.SolutionPath.Peek() is Vertex vertex && vertex.UniqueId == Vertex.SolvedUniqueId);
		}
	}
}
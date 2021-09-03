﻿using System.Collections.Generic;

using EightPuzzleSolver.Puzzle;
using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
	#region Attributes
	protected IEnumerable<Vertex>? pendingVertices;
	protected List<Vertex> visitedVertices;
	#endregion
	#region Properties
	/// <summary>
	/// Counts how many nodes were used in the graph in the pathfinding process
	/// </summary>
	public int NodeCount {
		get; protected set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Abstract pathfinder
	/// </summary>
	/// <param name="board">Board to use</param>
	/// <param name="emptyCellPosition">Empty cell position</param>
	public PathFinder() {
		this.NodeCount++;
		this.visitedVertices = new();
	}
	#endregion
	#region Methods
	/// <summary>
	/// Solves the board
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="emptyCellPosition">Root empty cell position</param>
	public abstract void Solve(List<string> board, (int Row, int Column) emptyCellPosition);
	/// <summary>
	/// Generate as much movements as possible
	/// </summary>
	/// <param name="state">Board state</param>
	/// <returns>All possible board combinations generated by the valid moves</returns>
	protected List<Vertex> MakePossibleMovements(Vertex vertex) {
		List<Vertex> result = new();
		if (vertex.Position.Row > 0) { // Check up
			(var EmptyCellPosition, var Board) = Play.Move(vertex.State, Direction.Up, vertex.Position);
			if (Board is not null) {
				result.Add(new(Board, EmptyCellPosition));
				this.NodeCount++;
			}
		}
		if (vertex.Position.Row < 2) { // Check down
			(var EmptyCellPosition, var Board) = Play.Move(vertex.State, Direction.Down, vertex.Position);
			if (Board is not null) {
				result.Add(new(Board, EmptyCellPosition));
				this.NodeCount++;
			}
		}
		if (vertex.Position.Column > 0) { // Check left
			(var EmptyCellPosition, var Board) = Play.Move(vertex.State, Direction.Left, vertex.Position);
			if (Board is not null) {
				result.Add(new(Board, EmptyCellPosition));
				this.NodeCount++;
			}
		}
		if (vertex.Position.Column < 2) { // Check right
			(var EmptyCellPosition, var Board) = Play.Move(vertex.State, Direction.Right, vertex.Position);
			if (Board is not null) {
				result.Add(new(Board, EmptyCellPosition));
				this.NodeCount++;
			}
		}
		return result;
	}
	#endregion
}
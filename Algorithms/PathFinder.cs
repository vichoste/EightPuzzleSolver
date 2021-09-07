﻿using System.Collections.Generic;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
	#region Attributes
	protected IEnumerable<State>? pending;
	protected List<State> visited;
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a pathfinder
	/// </summary>
	public PathFinder() => this.visited = new();
	#endregion
	#region Methods
	/// <summary>
	/// Solves the board
	/// </summary>
	/// <param name="cellViewModel">Cell view model</param>
	public abstract void Solve(CellViewModel cellViewModel);
	/// <summary>
	/// Generate as much movements as possible
	/// </summary>
	/// <param name="state">Board state</param>
	/// <returns>All possible board combinations generated by the valid moves</returns>
	protected static List<State> MakePossibleMovements(State state) {
		List<State> states = new();
		if (state.Board is not null) {
			if (state.ZeroX > 0) { // Check up
				(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(state.Board, state.ZeroX, state.ZeroY, Direction.Up);
				if (board is not null) {
					states.Add(new State(board, zeroX, zeroY));
				}
			}
			if (state.ZeroX < 2) { // Check down
				(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(state.Board, state.ZeroX, state.ZeroY, Direction.Down);
				if (board is not null) {
					states.Add(new State(board, zeroX, zeroY));
				}
			}
			if (state.ZeroY > 0) { // Check left
				(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(state.Board, state.ZeroX, state.ZeroY, Direction.Left);
				if (board is not null) {
					states.Add(new State(board, zeroX, zeroY));
				}
			}
			if (state.ZeroY < 2) { // Check right
				(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(state.Board, state.ZeroX, state.ZeroY, Direction.Right);
				if (board is not null) {
					states.Add(new State(board, zeroX, zeroY));
				}
			}
		}
		return states;
	}
	#endregion
}
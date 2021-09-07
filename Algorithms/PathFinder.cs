using System.Collections.Generic;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
	#region Attributes
	protected IEnumerable<CellModel>? pendingVertices;
	protected List<CellModel> visitedVertices;
	#endregion
	#region Constructors
	public PathFinder() => this.visitedVertices = new();
	#endregion
	#region Methods
	public abstract List<CellModel> Solve(CellViewModel cellViewModel);
	protected static List<State> MakePossibleMovements(State state) {
		List<State> states = new();
		if (state.CellViewModel.ZeroX > 0) { // Check up
			if (cellViewModel.MoveZeroCell(Direction.Up) is List<CellModel> moved) {
				moved.Add(new State(moved));
			}
		}
		if (cellViewModel.ZeroX < 2) { // Check down
			if (cellViewModel.MoveZeroCell(Direction.Down) is List<CellModel> moved) {
				moved.Add(new(moved, EmptyCellPosition));
			}
		}
		if (cellViewModel.ZeroY > 0) { // Check left
			if (cellViewModel.MoveZeroCell(Direction.Left) is List<CellModel> moved) {
				moved.Add(new(moved, EmptyCellPosition));
			}
		}
		if (cellViewModel.ZeroY < 2) { // Check right
			if (cellViewModel.MoveZeroCell(Direction.Right) is List<CellModel> moved) {
				moved.Add(new(moved, EmptyCellPosition));
			}
		}
		return states;
	}
	#endregion
}
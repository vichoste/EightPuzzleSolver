using System.Collections.Generic;
using System.Threading.Tasks;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// DFS pathfinding algorithm
/// </summary>
internal class DepthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public DepthFirstSearch() : base() => this.pending = new Stack<State>();
	/// <summary>
	/// Solves the board with DFS
	/// </summary>
	/// <param name="cellViewModel">Cell view model</param>
	public async override Task Solve(CellViewModel cellViewModel) {
		Stack<State>? stack = this.pending as Stack<State>;
		State root = new(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY);
		stack.Push(root);
		this.visited.Add(root);
		while (stack.Count > 0) {
			var current = stack.Pop();
			if (current.Board is List<CellModel> list) {
				_ = await Task.Run(() => cellViewModel.Board = current.Board);
			}
			var children = MakePossibleMovements(current);
			for (int i = children.Count - 1; i >= 0; i--) {
				var currentChild = children[i];
				if (this.visited.Find(v => v.Combination == currentChild.Combination) is null) {
					stack.Push(currentChild);
					this.visited.Add(currentChild);
				}
			}
		}
	}
}
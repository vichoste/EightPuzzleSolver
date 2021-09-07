﻿using System.Collections.Generic;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// BFS pathfinding algorithm
/// </summary>
internal class BreadthFirstSearch : PathFinder {
	/// <summary>
	/// Starts a DFS pathfinding algorithm
	/// </summary>
	public BreadthFirstSearch() : base() => this.pending = new Queue<State>();
	/// <summary>
	/// Solves the board with BFS
	/// </summary>
	/// <param name="cellViewModel">Cell view model</param>
	public override void Solve(CellViewModel cellViewModel) {
		Queue<State>? queue = this.pending as Queue<State>;
		State root = new(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY);
		queue.Enqueue(root);
		this.visited.Add(root);
		while (queue.Count > 0) {
			var current = queue.Dequeue();
			var children = MakePossibleMovements(current);
			for (int i = children.Count - 1; i >= 0; i--) {
				var currentChild = children[i];
				if (this.visited.Find(v => v.Combination == currentChild.Combination) is null) {
					queue.Enqueue(currentChild);
					this.visited.Add(currentChild);
				}
			}
		}
	}
}
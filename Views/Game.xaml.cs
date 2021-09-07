using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

using EightPuzzleSolver.Algorithms;
using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver;
/// <summary>
/// Game
/// </summary>
public partial class Game : Window {
	#region Constructors
	/// <summary>
	/// Initializes the window
	/// </summary>
	public Game() => this.InitializeComponent();
	#endregion
	#region Event methods
	/// <summary>
	/// Moves the empty cell once the user presses an arrow key
	/// </summary>
	private void GameWindow_KeyDown(object sender, KeyEventArgs e) {
		var direction = Direction.Up;
		switch (e.Key) {
			case Key.Down:
				direction = Direction.Down;
				break;
			case Key.Left:
				direction = Direction.Left;
				break;
			case Key.Right:
				direction = Direction.Right;
				break;
		}
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY, direction);
		if (board is not null) {
			cellViewModel.Board = board;
			cellViewModel.ZeroX = zeroX;
			cellViewModel.ZeroY = zeroY;
			cellViewModel.IsSolved = CellModel.CalculateCombination(board) == CellModel.SolvedCombination;
		}
	}
	/// <summary>
	/// Trigger BFS (This will take forever)
	/// </summary>
	private void SolveWithBFS_Click(object sender, RoutedEventArgs e) {
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		if (!cellViewModel.IsSolved) {
			PathFinder pathFinder = new BreadthFirstSearch();
			(var board, int zeroX, int zeroY) = pathFinder.Solve(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY, direction);
			cellViewModel.Board = board;
			cellViewModel.ZeroX = zeroX;
			cellViewModel.ZeroY = zeroY;
			cellViewModel.IsSolved = CellModel.CalculateCombination(board) == CellModel.SolvedCombination;
		}
	}
	/// <summary>
	/// Trigger DFS (This will take forever)
	/// </summary>
	private void SolveWithDFS_Click(object sender, RoutedEventArgs e) {
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		if (!cellViewModel.IsSolved) {
			PathFinder pathFinder = new DepthFirstSearch();
			(var board, int zeroX, int zeroY) = pathFinder.Solve(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY, direction);
			cellViewModel.Board = board;
			cellViewModel.ZeroX = zeroX;
			cellViewModel.ZeroY = zeroY;
			cellViewModel.IsSolved = CellModel.CalculateCombination(board) == CellModel.SolvedCombination;
		}
	}
	#endregion
}
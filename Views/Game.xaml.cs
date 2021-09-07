using System.Windows;
using System.Windows.Input;

using EightPuzzleSolver.Algorithms;
using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver;
/// <summary>
/// Game
/// </summary>
public partial class Game : Window {
	#region Attributes
	private bool IsBeingSolved;
	#endregion
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
		if (!this.IsBeingSolved) {
			CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
			if (!cellViewModel.IsSolved) {
				this.DFS.IsEnabled = this.BFS.IsEnabled = false;
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
				(var board, int zeroX, int zeroY) = CellViewModel.MoveZeroCell(cellViewModel.Board, cellViewModel.ZeroX, cellViewModel.ZeroY, direction);
				if (board is not null) {
					cellViewModel.Board = board;
					cellViewModel.ZeroX = zeroX;
					cellViewModel.ZeroY = zeroY;
					cellViewModel.IsSolved = CellModel.CalculateCombination(board) == CellModel.SolvedCombination;
					if (cellViewModel.IsSolved) {
						this.DFS.IsEnabled = this.BFS.IsEnabled = false;
					} else {
						this.DFS.IsEnabled = this.BFS.IsEnabled = true;
					}
				}
			}
		}
	}
	/// <summary>
	/// Trigger BFS (This will take forever)
	/// </summary>
	private async void SolveWithBFS_Click(object sender, RoutedEventArgs e) {
		this.IsBeingSolved = true;
		this.DFS.IsEnabled = this.BFS.IsEnabled = false;
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		if (!cellViewModel.IsSolved) {
			PathFinder pathFinder = new BreadthFirstSearch();
			await pathFinder.Solve(cellViewModel);
		}
		this.DFS.IsEnabled = this.BFS.IsEnabled = true;
		this.IsBeingSolved = false;
	}
	/// <summary>
	/// Trigger DFS (This will take forever)
	/// </summary>
	private async void SolveWithDFS_Click(object sender, RoutedEventArgs e) {
		this.IsBeingSolved = false;
		this.DFS.IsEnabled = this.BFS.IsEnabled = false;
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		if (!cellViewModel.IsSolved) {
			PathFinder pathFinder = new DepthFirstSearch();
			await pathFinder.Solve(cellViewModel);
		}
		this.DFS.IsEnabled = this.BFS.IsEnabled = true;
		this.IsBeingSolved = true;
	}
	#endregion
}
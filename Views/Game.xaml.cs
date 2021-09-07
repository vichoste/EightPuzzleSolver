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
		if (cellViewModel.MoveZeroCell(direction) is List<CellModel> @new) {
			cellViewModel.Board = @new;
			cellViewModel.IsSolved = CellModel.CalculateCombination(@new) == CellModel.SolvedCombination;
		}
	}
	/// <summary>
	/// Trigger BFS (This will take forever)
	/// </summary>
	private void SolveWithBFS_Click(object sender, RoutedEventArgs e) {
		CellViewModel? cellViewModel = (CellViewModel) this.DataContext;
		if (!cellViewModel.IsSolved) {
			BreadthFirstSearch bfs = new();
			var solved = bfs.Solve(cellViewModel);
			this.Play.EmptyCellPosition = newPosition;
			this.Play.Board = newBoard;
			this.Play.IsSolved = Vertex.CalculateUniqueId(this.Play.Board) == Vertex.SolvedUniqueId;
			/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
			this.DataContext = null;
			this.DataContext = this.Play;
		}
	}
	/// <summary>
	/// Trigger DFS (This will take forever)
	/// </summary>
	private void SolveWithDFS_Click(object sender, RoutedEventArgs e) {
		if (!this.Play.IsSolved) {
			DepthFirstSearch dfs = new();
			(var newPosition, var newBoard) = dfs.Solve(this.Play.Board, this.Play.EmptyCellPosition);
			this.Play.EmptyCellPosition = newPosition;
			this.Play.Board = newBoard;
			this.Play.IsSolved = Vertex.CalculateUniqueId(this.Play.Board) == Vertex.SolvedUniqueId;
			/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
			this.DataContext = null;
			this.DataContext = this.Play;
		}
	}
	#endregion
}
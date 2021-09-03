using System.Windows;
using System.Windows.Input;

using EightPuzzleSolver.Algorithms;
using EightPuzzleSolver.Puzzle;
using EightPuzzleSolver.Structures;

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
		// Move
		(var EmptyCellPosition, var Board) = Play.Move(this.Play.Board, direction, this.Play.EmptyCellPosition);
		if (Board is not null) {
			this.Play.EmptyCellPosition = EmptyCellPosition;
			this.Play.Board = Board;
			this.Play.IsSolved = Vertex.CalculateUniqueId(this.Play.Board) == Vertex.SolvedUniqueId;
			/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
			this.DataContext = null;
			this.DataContext = this.Play;
		}
	}
	/// <summary>
	/// Trigger BFS (This will take forever)
	/// </summary>
	private void SolveWithBFS_Click(object sender, RoutedEventArgs e) {
		if (!this.Play.IsSolved) {
			BreadthFirstSearch bfs = new();
			(var newPosition, var newBoard) = bfs.Solve(this.Play.Board, this.Play.EmptyCellPosition);
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
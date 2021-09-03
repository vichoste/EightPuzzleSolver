using System.Windows;
using System.Windows.Input;

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
	/// Starts a new game
	/// </summary>
	private void NewGame_Click(object sender, RoutedEventArgs e) => this.DataContext = new Play(); // Effective but it gives bugs
	/// <summary>
	/// Moves the empty cell once the user presses an arrow key
	/// </summary>
	private void GameWindow_KeyDown(object sender, KeyEventArgs e) { // TODO Don't allow more than one key pressed
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
		(var emptyCellPosition, var board) = Play.Move(this.Play.Board, direction, this.Play.EmptyCellPosition);
		this.Play.EmptyCellPosition = emptyCellPosition;
		this.Play.Board = board;
		this.Play.IsSolved = Play.CalculateUniqueId(this.Play.Board) == Vertex.SolvedUniqueId;
		/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
		this.DataContext = null;
		this.DataContext = this.Play; // TODO This breaks the NEW board
	}
	#endregion
}
using System.Windows;
using System.Windows.Input;

using EightPuzzleSolver.Puzzle;

namespace EightPuzzleSolver;
/// <summary>
/// Game
/// </summary>
public partial class Game : Window {
	/// <summary>
	/// Initializes the window
	/// </summary>
	public Game() => this.InitializeComponent();
	/// <summary>
	/// Starts a new game
	/// </summary>
	private void NewGame_Click(object sender, RoutedEventArgs e) => this.DataContext = new Board();
	/// <summary>
	/// Moves the empty cell once the user presses an arrow key
	/// </summary>
	private void GameWindow_KeyDown(object sender, KeyEventArgs e) { // TODO Don't allow more than one key pressed
		switch (e.Key) {
			case Key.Up:
				this.Board.Move(Direction.Up);
				break;
			case Key.Down:
				this.Board.Move(Direction.Down);
				break;
			case Key.Left:
				this.Board.Move(Direction.Left);
				break;
			case Key.Right:
				this.Board.Move(Direction.Right);
				break;
		}
		/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
		this.DataContext = null;
		this.DataContext = this.Board;
	}
}
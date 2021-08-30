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
	private void GameWindow_KeyDown(object sender, KeyEventArgs e) {
		switch (e.Key) {
			case Key.Up:
				this.Board.Move(Direction.Up);
				break;
			case Key.Down:
				this.Board.Move(Direction.Up);
				break;
			case Key.Left:
				this.Board.Move(Direction.Up);
				break;
			case Key.Right:
				this.Board.Move(Direction.Up);
				break;
		}
	}
}
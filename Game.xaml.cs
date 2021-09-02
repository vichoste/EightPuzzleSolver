using System.Linq;
using System.Windows;
using System.Windows.Input;

using EightPuzzleSolver.Puzzle;

namespace EightPuzzleSolver;
/// <summary>
/// Game
/// </summary>
public partial class Game : Window {
	#region Attributes
	/// <summary>
	/// This is the winning combination. Source: https://www.geeksforgeeks.org/check-instance-8-puzzle-solvable/
	/// </summary>
	private readonly int[][] WinningCombination = new int[][] {
		new int[] {1, 2, 3},
		new int[] {4, 5, 6},
		new int[] {7, 8, 0}
	};
	#endregion
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
		switch (e.Key) {
			case Key.Up:
				this.Play.Move(Direction.Up);
				break;
			case Key.Down:
				this.Play.Move(Direction.Down);
				break;
			case Key.Left:
				this.Play.Move(Direction.Left);
				break;
			case Key.Right:
				this.Play.Move(Direction.Right);
				break;
		}

		/* I won't waste time by remembering and looking for how the fuck to proper databinding, just bruteforce this, holy fucking shit */
		this.DataContext = null;
		this.DataContext = this.Play; // TODO This breaks the NEW board
	}
	#endregion
	#region Methods
	/// <summary>
	/// Checks if the game is solved
	/// I am lazy to implement a more efficient way of doing this. The arrays will be always 3x3 anyways.
	/// </summary>
	/// <returns>If true, the player has won</returns>
	internal bool IsSolved() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (int.Parse(this.Play.Board.ElementAt(i * 3 + j)) != this.WinningCombination[i][j]) { // Assuming parse will always give an integer
					return false; // One number mismatch and the game will be considered not solved.
				}
			}
		}
		return true;
	} // TODO move this in another class
	#endregion
}
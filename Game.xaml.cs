using System.Windows;

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
}
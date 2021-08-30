using System.Windows;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver;
/// <summary>
/// Puzzle
/// </summary>
public partial class Puzzle : Window {
	/// <summary>
	/// Initializes the window
	/// </summary>
	public Puzzle() => this.InitializeComponent();
	/// <summary>
	/// Starts a new game
	/// </summary>
	private void NewGame_Click(object sender, RoutedEventArgs e) => this.DataContext = new Board();
}
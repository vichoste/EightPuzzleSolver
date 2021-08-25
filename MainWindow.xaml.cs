using System.Windows;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	/// <summary>
	/// Initializes the window
	/// </summary>
	public MainWindow() => this.InitializeComponent();
	/// <summary>
	/// Starts a new game
	/// </summary>
	private void NewGame_Click(object sender, RoutedEventArgs e) => this.DataContext = new Game();
}
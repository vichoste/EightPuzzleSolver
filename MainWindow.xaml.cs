using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		/// <summary>
		/// Initializes the window
		/// </summary>
		public MainWindow() {
			this.InitializeComponent();
			this.DataContext = new Game();
		}
		/// <summary>
		/// Starts a new game
		/// </summary>
		private void NewGame_Click(object sender, RoutedEventArgs e) => this.DataContext = new Game();
	}
}
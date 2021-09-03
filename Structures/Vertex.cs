using System;
using System.Collections.Generic;

using EightPuzzleSolver.Puzzle;

namespace EightPuzzleSolver.Structures;
/// <summary>
/// Joins two nodes which are board states
/// </summary>
internal class Vertex {
	#region Attributes
	private List<string> state;
	private HashSet<Vertex> connectedVertices;
	#endregion
	#region Properties
	/// <summary>
	/// Sets an unique ID for the vertex for comparison
	/// </summary>
	public int UniqueId {
		get; private set;
	}
	/// <summary>
	/// The board state
	/// </summary>
	public List<string> State {
		get => new(this.state);
		private set {
		}
	}
	/// <summary>
	/// States associated with the vertex
	/// </summary>
	public List<Vertex> ConnectedVertices {
		get => new(this.connectedVertices);
		private set {
		}
	}
	/// <summary>
	/// This value means how closer this state is to the winning combination
	/// Kudos to Thomas Hormazábal for giving me this idea. Source: https://www.youtube.com/watch?v=uJA0i90uCGE
	/// </summary>
	public int HeruisticValue {
		get; private set;
	}
	/// <summary>
	/// The position of the empty cell on the state
	/// </summary>
	public (int Row, int Col) Position {
		get; private set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a board state in a vertex
	/// </summary>
	/// <param name="state">Board state</param>
	public Vertex(List<string> state, (int, int) position) {
		this.state = state;
		this.Position = position;
		this.connectedVertices = new();
		// Get the heruistic value
		for (int i = 0; i < 9; i++) {
			int currentValue = int.Parse(state[i]);
			this.HeruisticValue = i < 8 && currentValue == i + 1 || i == 8 && currentValue == 0 ? this.HeruisticValue + 1 : this.HeruisticValue;
		}
	}
	#endregion
	#region Methods
	/// <summary>
	/// Adds a connection to the vertex
	/// </summary>
	/// <param name="vertex">Unique new vertex connection</param>
	public void AddConnection(Vertex vertex) {
		if (vertex.UniqueId != this.UniqueId && this.ConnectedVertices.Find(v => v.UniqueId == vertex.UniqueId) is Vertex @new) {
			_ = this.connectedVertices.Add(@new);
		}
	}
	#endregion
	#region Static methods
	/// <summary>
	/// Calculates an unique ID for a board.
	/// </summary>
	/// <param name="board">Board combination</param>
	/// <returns>Unique ID for a board combination</returns>
	public static int CalculateUniqueId(List<string> board) {
		int result = 0;
		/* How this works:
		 * There are 9 positions. So, in order to generate an ID that represents the board combination, that is comparable to others, the following will be done:
		 * ID = sum(
		 * state[0] * 1
		 * state[1] * 10
		 * state[2] * 100
		 * state[3] * 1000
		 * state[4] * 10000
		 * state[5] * 100000
		 * state[6] * 1000000
		 * state[7] * 10000000
		 * state[8] * 100000000
		 * state[9] * 1000000000)
		 */
		for (int i = 0; i < 9; i++) {
			result += int.Parse(board[i]) * (int) Math.Pow(10, i); // Assuming both parsing and result are integers
		}
		return result;
	}
	#endregion
}

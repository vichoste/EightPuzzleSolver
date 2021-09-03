using System;
using System.Collections.Generic;

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
	/// Gets the hash code from the board state for comparison
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
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a board state in a vertex
	/// </summary>
	/// <param name="state">Board state</param>
	public Vertex(List<string> state) {
		this.state = state;
		this.connectedVertices = new();
	}
	#endregion
	#region Methods
	/// <summary>
	/// Adds a connection to the vertex
	/// </summary>
	/// <param name="vertex">Destination vertex</param>
	public void AddConnection(Vertex @new) => this.connectedVertices.Add(@new);
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

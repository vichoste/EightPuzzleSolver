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
	public (int Row, int Column) Position {
		get; private set;
	}
	/// <summary>
	/// Depth of this vertex
	/// </summary>
	public int SearchDepth {
		get; internal set;
	}
	/// <summary>
	/// See if this vertex is visited
	/// </summary>
	public bool IsVisited {
		get; internal set;
	}
	#endregion
	#region Static properties
	/// <summary>
	/// This exact Unique ID is for identifying the solved combination for a board
	/// </summary>
	public static int SolvedUniqueId = 87654321;
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
}

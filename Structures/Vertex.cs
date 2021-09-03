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
	/// Gets the hash code from the board state for comparison
	/// </summary>
	public List<string> State {
		get => new(this.state);
		private set;
	}
	/// <summary>
	/// States associated with the vertex
	/// </summary>
	public List<Vertex> ConnectedVertices {
		get => new(this.connectedVertices);
		private set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a board state in a vertex
	/// </summary>
	/// <param name="state">Board state</param>
	public Vertex(List<string> state) {
		this.state = state;
		this.connectedEdges = new();
	}
	#endregion
	#region Methods
	/// <summary>
	/// Adds a connection to the vertex
	/// </summary>
	/// <param name="vertex">Destination vertex</param>
	public void AddConnection(Vertex vertex) => this.connectedVertices.Add(vertex);
	#endregion
}

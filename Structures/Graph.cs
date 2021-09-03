using System.Collections.Generic;
using System.Windows.Documents;

namespace EightPuzzleSolver.Structures;

/// <summary>
/// This is a helper structure for the pathfinding algorithms
/// </summary>
internal class Graph {
	#region Attributes
	private HashSet<Vertex> vertices;
	#endregion
	#region Properties
	/// <summary>
	/// All vertexes inside the graph
	/// </summary>
	public List<Vertex> Vertices {
		get => new(this.vertices);
		private set {
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a graph
	/// </summary>
	public Graph() => this.vertices = new();
	#endregion
	#region Methods
	/// <summary>
	/// Adds a vertex to the graph
	/// </summary>
	/// <param name="vertex">Destination vertex</param>
	public void Add(Vertex vertex) => this.vertices.Add(vertex);
	public void AddEdge(Vertex firstVertex, Vertex secondVertex) {
		// TODO this thing
	}
	#endregion
}
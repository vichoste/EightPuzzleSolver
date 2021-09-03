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
	/// Adds a vertex to the graph if it not exists
	/// </summary>
	/// <param name="vertex">Board state associated to the vertex</param>
	public void Add(List<string> state) {
		if (this.Vertices.Find(v => v.UniqueId == Vertex.CalculateUniqueId(state)) is Vertex @new) {
			_ = this.vertices.Add(@new);
		}
	}
	public void AddEdge(List<string> firstState, List<string> secondState) {
		if (this.Vertices.Find(v => v.UniqueId == Vertex.CalculateUniqueId(firstState)) is Vertex firstVertex && this.Vertices.Find(v => v.UniqueId == Vertex.CalculateUniqueId(secondState)) is Vertex secondVertex) {
			firstVertex.AddConnection(secondVertex);
			secondVertex.AddConnection(firstVertex);
		}
	}
	#endregion
}
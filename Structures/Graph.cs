using System.Collections.Generic;

using EightPuzzleSolver.Puzzle;

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
	/// <param name="state">Board state associated to the vertex</param>
	/// <param name="position">Position of the empty cell associated to the vertex</param>
	public void Add(List<string> state, (int, int) position) {
		if (this.Vertices.Find(v => v.UniqueId == Play.CalculateUniqueId(state)) is null) {
			_ = this.vertices.Add(new Vertex(state, position));
		}
	}
	/// <summary>
	/// Adds an edge to the graph
	/// </summary>
	/// <param name="firstState">State as the first vertex</param>
	/// <param name="secondState">State as the second vertex</param>
	public void AddEdge(List<string> firstState, List<string> secondState) {
		if (this.Vertices.Find(v => v.UniqueId == Play.CalculateUniqueId(firstState)) is Vertex firstVertex && this.Vertices.Find(v => v.UniqueId == Play.CalculateUniqueId(secondState)) is Vertex secondVertex) {
			firstVertex.AddConnection(secondVertex);
			secondVertex.AddConnection(firstVertex);
		}
	}
	#endregion
}
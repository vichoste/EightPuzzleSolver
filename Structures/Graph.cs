using System.Collections.Generic;
using System.Windows.Documents;

namespace EightPuzzleSolver.Structures;

/// <summary>
/// This is a helper structure for the pathfinding algorithms
/// </summary>
internal class Graph {
	/// <summary>
	/// All vertexes inside the graph
	/// </summary>
	public HashSet<Vertex> Vertexes {
		get; private set;
	}
	/// <summary>
	/// Creates a graph
	/// </summary>
	public Graph() {
		this.Vertexes = new();
	}
}
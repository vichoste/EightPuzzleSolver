using System.Collections.Generic;
using System.Windows.Documents;

namespace EightPuzzleSolver.Structures;

/// <summary>
/// This is a helper structure for the pathfinding algorithms
/// </summary>
internal class Graph {
	#region Attributes
	private HashSet<Vertex> vertexes;
	#endregion
	#region Properties
	/// <summary>
	/// All vertexes inside the graph
	/// </summary>
	public List<Vertex> Vertexes {
		get => new(this.vertexes);
		private set {
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates a graph
	/// </summary>
	public Graph() {
		this.vertexes = new();
	}
	#endregion
}
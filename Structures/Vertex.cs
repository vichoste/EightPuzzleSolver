using System.Collections.Generic;

namespace EightPuzzleSolver.Structures;
/// <summary>
/// Joins two nodes which are board states
/// </summary>
internal class Vertex {
	/// <summary>
	/// Board state
	/// </summary>
	public List<string> State {
		get; private set;
	}
	/// <summary>
	/// States associated with the vertex
	/// </summary>
	public List<Vertex> Edges {
		get; private set;
	}
	/// <summary>
	/// Creates a board state in a vertex
	/// </summary>
	/// <param name="state">Board state</param>
	public Vertex(List<string> state) {
		this.State = state;
		this.Edges = new();
	}
}

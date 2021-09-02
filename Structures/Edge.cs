using System.Collections.Generic;

namespace EightPuzzleSolver.Structures;
/// <summary>
/// Joins two nodes which are board states
/// </summary>
internal class Edge {

	public int ID {
		get; private set;
	}
	public Edge(List<string> firstVertex, List<string> secondVertex) => firstVertex.GetHashCode();
}

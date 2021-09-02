using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleSolver.Structures;
/// <summary>
/// Joins two nodes which are board states
/// </summary>
internal class Edge {

	public int ID {
		get; private set;
	}
	public Edge(List<string> firstVertex, List<string> secondVertex) {
		firstVertex.GetHashCode();
	}
}

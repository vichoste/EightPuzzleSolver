using System.Collections.Generic;

using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
	/// <summary>
	/// Graph used for pathfinding
	/// </summary>
	public Graph? Graph {
		get; private set;
	}
	/// <summary>
	/// This is the path that leads from the initial state to the solution
	/// </summary>
	public List<Vertex>? SolutionPath {
		get; protected set;
	}
	/// <summary>
	/// Counts how many nodes were used in the graph in the pathfinding process
	/// </summary>
	public int NodeCount {
		get; protected set;
	}
	public PathFinder(List<string> board, (int Row, int Column) emptyCellPosition) {
		this.Graph = new();
		this.Graph.Add(board, emptyCellPosition);
	}
}

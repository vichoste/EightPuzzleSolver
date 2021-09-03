using System.Collections.Generic;

using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
	#region Attributes
	protected IEnumerable<Vertex>? pendingVertices;
	#endregion
	#region Properties
	/// <summary>
	/// Graph used for pathfinding
	/// </summary>
	public Graph? Graph {
		get; private set;
	}
	/// <summary>
	/// This is the path that leads from the initial state to the solution
	/// </summary>
	public Stack<Vertex>? SolutionPath {
		get; protected set;
	}
	/// <summary>
	/// Counts how many nodes were used in the graph in the pathfinding process
	/// </summary>
	public int NodeCount {
		get; protected set;
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Abstract pathfinder
	/// </summary>
	/// <param name="board">Board to use</param>
	/// <param name="emptyCellPosition">Empty cell position</param>
	public PathFinder() {
		this.Graph = new();
		this.NodeCount++;
		this.SolutionPath = new();
	}
	#endregion
	#region Methods
	/// <summary>
	/// Solves the board
	/// </summary>
	/// <param name="board">Root board</param>
	/// <param name="emptyCellPosition">Root empty cell position</param>
	public abstract void Solve(List<string> board, (int Row, int Column) emptyCellPosition);
	#endregion
}
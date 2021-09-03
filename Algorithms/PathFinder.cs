using System.Collections.Generic;

using EightPuzzleSolver.Structures;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// Pathfinder 
/// </summary>
internal abstract class PathFinder {
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
	public PathFinder(List<string> board, (int Row, int Column) emptyCellPosition) {
		this.Graph = new();
		this.Graph.Add(board, emptyCellPosition);
		this.SolutionPath = new();
	}
	#endregion
	#region Methods
	/// <summary>
	/// Checks the current valid moves for the empty cell
	/// </summary>
	/// <param name="emptyCellPosition">Current position of the empty cell</param>
	/// <returns>(Up, Down, Left, Right) tuple; each one can be true if that movement is valid</returns>
	protected static (bool, bool, bool, bool) CheckMoveFreedom((int Row, int Column) emptyCellPosition) => (emptyCellPosition.Row > 0, emptyCellPosition.Row < 2, emptyCellPosition.Column > 0, emptyCellPosition.Column < 2);
	#endregion
}
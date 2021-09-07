using System.Collections.Generic;

using EightPuzzleSolver.Models;
using EightPuzzleSolver.ViewModels;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// This is one board state
/// </summary>
public class State {
	/// <summary>
	/// Cell combination
	/// </summary>
	public List<CellModel> CellModel {
		get; private set;
	}
	/// <summary>
	/// Row coordinate of the zero cell
	/// </summary>
	public int ZeroX {
		get; set;
	}
	/// <summary>
	/// Column coordinate of the zero cell
	/// </summary>
	public int ZeroY {
		get; set;
	}
	/// <summary>
	/// Creates a state
	/// </summary>
	/// <param name="cellModel">Cell combination</param>
	/// <param name="zeroX">Row coordinate of the zero cell</param>
	/// <param name="zeroY">Column coordinate of the zero cell</param>
	public State(CellModel cellModel, int zeroX, int zeroY) {
		this.CellModel = cellModel;
		this.ZeroX = zeroX;
		this.ZeroY = zeroY;
	}
}
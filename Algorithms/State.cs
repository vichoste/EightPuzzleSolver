using System.Collections.Generic;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver.Algorithms;
/// <summary>
/// This is one board state
/// </summary>
public class State {
	/// <summary>
	/// Board combination
	/// </summary>
	public int Combination {
		get; private set;
	}
	/// <summary>
	/// Board
	/// </summary>
	public List<CellModel>? Board {
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
	public State(List<CellModel> cellModel, int zeroX, int zeroY) {
		this.Board = cellModel;
		this.ZeroX = zeroX;
		this.ZeroY = zeroY;
		this.Combination = CellModel.CalculateCombination(cellModel);
	}
}
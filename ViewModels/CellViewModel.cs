using System;
using System.Collections.Generic;
using System.Linq;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver.ViewModels;
/// <summary>
/// This is the cell's view model
/// </summary>
public class CellViewModel {
	#region Attributes
	private CellModel[] _Board;
	#endregion
	#region Attributes
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
	/// Gets the board
	/// </summary>
	public List<CellModel> Board => new(this._Board);
	/// <summary>
	/// Checks if the board is solved
	/// </summary>
	public bool IsSolved {
		get; set;
	}
	/// <summary>
	/// Checks if the board is solvable
	/// </summary>
	public bool IsSolvable {
		get {
			int result = 0;
			for (int i = 0; i < 3 - 1; i++) {
				for (int j = i + 1; j < 3; j++) {
					if (this._Board[j * 3 + i].Value > 0 && this._Board[j * 3 + i].Value > this._Board[i * 3 + j].Value) {
						result++;
					}
				}
			}
			return result % 2 == 0;
		}
	}
	#endregion
	#region Constructors
	/// <summary>
	/// Creates the cell view model
	/// </summary>
	public CellViewModel() {
		this._Board = new CellModel[]{
			new() {
				Value = 0
			},
			new() {
				Value = 1
			},
			new() {
				Value = 2
			},
			new() {
				Value = 3
			},
			new() {
				Value = 4
			},
			new() {
				Value = 5
			},
			new() {
				Value = 6
			},
			new() {
				Value = 7
			},
			new() {
				Value = 8
			},
		};
		// Safely shuffle the board
		do {
			this.Shuffle();
		} while (!this.IsSolvable);
	}
	#endregion
	#region Methods
	/// <summary>
	/// Randomizes the values within the board
	/// Source: http://csharphelper.com/blog/2016/10/randomize-two-dimensional-arrays-in-c/
	/// </summary>
	private void Shuffle() {
		Random random = new();
		for (int i = 0; i < 8; i++) {
			int j = random.Next(i, 9);
			int rowI = i / 3;
			int columnI = i % 3;
			int rowJ = j / 3;
			int columnJ = j % 3;
			Swap(this._Board[rowI * 3 + columnI], this._Board[rowJ * 3 + columnJ]);
			this.ZeroX = this._Board[rowI * 3 + columnI].Value == 0 ? rowI : this._Board[rowJ * 3 + columnJ].Value == 0 ? rowJ : this.ZeroX;
			this.ZeroY = this._Board[rowI * 3 + columnI].Value == 0 ? columnI : this._Board[rowJ * 3 + columnJ].Value == 0 ? columnJ : this.ZeroX;
		}
	}
	#endregion
	#region Static methods
	/// <summary>
	/// Swaps two cell values
	/// </summary>
	/// <param name="firstCell">First cell</param>
	/// <param name="secondCell">Second cells</param>
	public static void Swap(CellModel firstCell, CellModel secondCell) {
		int temp = firstCell.Value;
		firstCell.Value = secondCell.Value;
		secondCell.Value = temp;
	}
	/// <summary>
	/// Moves the empty cell
	/// </summary>
	/// <param name="board">Board which we want to move the cell</param>
	/// <param name="direction">Direction of the movement</param>
	/// <returns>Tuple of new empty cell coordinates and the board with the new positions because of the movement operation. If the movement is invalid, return unchanged</returns>
	public List<CellModel>? MoveZeroCell(Direction direction) {
		if (direction == Direction.Up && this.ZeroX - 1 < 0 || direction == Direction.Down && this.ZeroX + 1 > 2 || direction == Direction.Left && this.ZeroY - 1 < 0 || direction == Direction.Right && this.ZeroY + 1 > 2) {
			return null;
		}
		List<CellModel>? @new = this._Board.ToList();
		switch (direction) {
			case Direction.Up:
				Swap(@new[this.ZeroX * 3 + this.ZeroY], @new[(this.ZeroX - 1 ) * 3 + this.ZeroY]);
				return @new;
			case Direction.Down:
				Swap(@new[this.ZeroX * 3 + this.ZeroY], @new[( this.ZeroX + 1 ) * 3 + this.ZeroY]);
				return @new;
			case Direction.Left:
				Swap(@new[this.ZeroX * 3 + this.ZeroY], @new[this.ZeroX * 3 + this.ZeroY - 1]);
				return @new;
			case Direction.Right:
				Swap(@new[this.ZeroX * 3 + this.ZeroY], @new[this.ZeroX * 3 + this.ZeroY + 1]);
				return @new;
		}
		return null;
	}
	#endregion
}

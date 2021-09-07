﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using EightPuzzleSolver.Models;

namespace EightPuzzleSolver.ViewModels;
/// <summary>
/// This is the cell's view model
/// </summary>
public class CellViewModel : INotifyPropertyChanged {
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
	public List<CellModel> Board {
		get; set;
	}
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
					if (this.Board[j * 3 + i].Value > 0 && this.Board[j * 3 + i].Value > this.Board[i * 3 + j].Value) {
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
		this.Board = new List<CellModel> {
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
	#region Indexers
	/// <summary>
	/// Gets or sets a value inside the cell
	/// </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Value at the position</returns>
	public CellModel this[int row, int column] {
		get {
			this.OnPropertyChanged("Board");
			return this.Board[row * 3 + column];
		}
		set {
			this.Board[row * 3 + column] = value;
			this.OnPropertyChanged("Board");
		}
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
			Swap(this.Board[rowI * 3 + columnI], this.Board[rowJ * 3 + columnJ]);
			this.ZeroX = this.Board[rowI * 3 + columnI].Value == 0 ? rowI : this.Board[rowJ * 3 + columnJ].Value == 0 ? rowJ : this.ZeroX;
			this.ZeroY = this.Board[rowI * 3 + columnI].Value == 0 ? columnI : this.Board[rowJ * 3 + columnJ].Value == 0 ? columnJ : this.ZeroX;
		}
		this.OnPropertyChanged("Board");
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
	/// <param name="board">Board to manipulate</param>
	/// <param name="direction">Direction of the movement</param>
	/// <param name="zeroX">Row zero cell position</param>
	/// <param name="zeroY">Row column cell position</param>
	/// <returns>Tuple of new empty cell coordinates and the board with the new positions because of the movement operation. If the movement is invalid, return unchanged</returns>
	public static List<CellModel>? MoveZeroCell(List<CellModel> board, Direction direction, int zeroX, int zeroY) {
		if (direction == Direction.Up && zeroX - 1 < 0 || direction == Direction.Down && zeroX + 1 > 2 || direction == Direction.Left && zeroY - 1 < 0 || direction == Direction.Right && zeroY + 1 > 2) {
			return null;
		}
		List<CellModel> manipulated = new(board);
		switch (direction) {
			case Direction.Up:
				Swap(manipulated[zeroX * 3 + zeroY], manipulated[( zeroX - 1 ) * 3 + zeroY]);
				return manipulated;
			case Direction.Down:
				Swap(manipulated[zeroX * 3 + zeroY], manipulated[( zeroX + 1 ) * 3 + zeroY]);
				return manipulated;
			case Direction.Left:
				Swap(manipulated[zeroX * 3 + zeroY], manipulated[zeroX * 3 + zeroY - 1]);
				return manipulated;
			case Direction.Right:
				Swap(manipulated[zeroX * 3 + zeroY], manipulated[zeroX * 3 + zeroY + 1]);
				return manipulated;
		}
		return null;
	}
	#endregion
	#region Events
	/// <summary>
	/// Property changed event handler
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;
	/// <summary>
	/// When property changes, call this function
	/// </summary>
	/// <param name="value">Property name</param>
	public void OnPropertyChanged(string value) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
	#endregion
}

namespace EightPuzzleSolver.Models;
/// <summary>
/// This is one cell
/// </summary>
internal class Cell {
	/// <summary>
	/// The cell position. This value cannot be changed.
	/// </summary>
	public int Position {
		get; private set;
	}
	/// <summary>
	/// The current value of the cell. This field can be interchanged.
	/// </summary>
	public string Number {
		get; internal set;
	}
	/// <summary>
	/// The status of this cell
	/// </summary>
	public bool IsActive {
		get; internal set;
	}
	/// <summary>
	/// Creates a new cell
	/// </summary>
	/// <param name="number">The initial cell value</param>
	public Cell(string number) {
		this.Number = number;
		this.Position = int.Parse(number);// Assuming they are created only once in the program
	}
	/// <summary>
	/// Returns the current value of the cell
	/// </summary>
	/// <returns>Value as string</returns>
	public override string ToString() => this.Number;
}
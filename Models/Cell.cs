namespace EightPuzzleSolver.Models;
/// <summary>
/// This is one cell
/// </summary>
internal class Cell {
	/// <summary>
	/// The current value of the cell
	/// </summary>
	public byte Number {
		get; set;
	}
	/// <summary>
	/// The status of this cell
	/// </summary>
	public bool IsActive {
		get; set;
	}
	/// <summary>
	/// Creates a new cell
	/// </summary>
	/// <param name="number">The initial cell value</param>
	public Cell(byte number) => this.Number = number;
	/// <summary>
	/// Returns the current value of the cell
	/// </summary>
	/// <returns>Value as string</returns>
	public override string ToString() => this.Number.ToString();
}
using EightPuzzleSolver.Puzzle;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightPuzzleSolver.Structures;
[TestClass]
public class VertexTests {
	[TestMethod]
	public void TestVertex() {
		Play play = new();
		Vertex vertex = new(play.Board, play.EmptyCellPosition);
		Assert.IsNotNull(vertex);
	}
}

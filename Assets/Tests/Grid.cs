using NUnit.Framework;
using NeonRacer;

public class Grid
{
    [Test]
    public void MoveUp()
    {
        Assert.AreEqual(1, NeonRacer.Grid.DirectionToIndex(1, Direction.up));
        Assert.AreEqual(0, NeonRacer.Grid.DirectionToIndex(3, Direction.up));
        Assert.AreEqual(5, NeonRacer.Grid.DirectionToIndex(8, Direction.up));
    }

    [Test]
    public void MoveDown()
    {
        Assert.AreEqual(4, NeonRacer.Grid.DirectionToIndex(1, Direction.down));
        Assert.AreEqual(6, NeonRacer.Grid.DirectionToIndex(3, Direction.down));
        Assert.AreEqual(8, NeonRacer.Grid.DirectionToIndex(8, Direction.down));
    }

    [Test]
    public void MoveLeft()
    {
        Assert.AreEqual(0, NeonRacer.Grid.DirectionToIndex(1, Direction.left));
        Assert.AreEqual(3, NeonRacer.Grid.DirectionToIndex(3, Direction.left));
        Assert.AreEqual(7, NeonRacer.Grid.DirectionToIndex(8, Direction.left));
    }

    [Test]
    public void MoveRight()
    {
        Assert.AreEqual(2, NeonRacer.Grid.DirectionToIndex(1, Direction.right));
        Assert.AreEqual(4, NeonRacer.Grid.DirectionToIndex(3, Direction.right));
        Assert.AreEqual(8, NeonRacer.Grid.DirectionToIndex(8, Direction.right));
    }
}
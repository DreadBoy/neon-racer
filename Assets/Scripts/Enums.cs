using UnityEngine;

namespace NeonRacer
{
    public enum Shape
    {
        Circle,
        Triangle,
        Square,
    }


    public class Piece
    {
        public Shape shape;
        public Color color;

        public static Shape[] shapes = new[] {Shape.Circle, Shape.Square, Shape.Triangle};
        public static Color[] colors = new[] {Color.blue, Color.green, Color.magenta, Color.yellow, Color.red};

        public Piece(Shape shape, Color color)
        {
            this.shape = shape;
            this.color = color;
        }

        public static Piece Random()
        {
            return new Piece(shapes[UnityEngine.Random.Range(0, shapes.Length)],
                colors[UnityEngine.Random.Range(0, colors.Length)]);
        }
    }

    public enum Direction
    {
        up,
        right,
        down,
        left,
    }
}
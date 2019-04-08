using System;

namespace DrawingTool
{
    public abstract class CanvasItem
    {
        public ICoordinate Coordinate { get; set; }
        public abstract void Draw(ref char[,] canvasBase, char fChar);

        public abstract bool ValidateCoordinates();

        public void SetCoordinates(ICoordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void DrawLine(ICoordinate coordinate, ref char[,] canvasBase, char fillChar)
        {
            for (int i = coordinate.Y1; i <= coordinate.Y2; i++)
            {
                for (int j = coordinate.X1; j <= coordinate.X2; j++)
                {
                    canvasBase[i, j] = fillChar;
                }
            }

        }
    }
}

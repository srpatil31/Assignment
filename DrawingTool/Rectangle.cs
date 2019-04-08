using System;

namespace DrawingTool
{
    public class Rectangle : CanvasItem
    {
        public Rectangle()
        {
        }
        public override void Draw(ref char[,] canvasBase, char fChar)
        {            
            base.DrawLine(new Coordinates(Coordinate.X1, Coordinate.Y1, Coordinate.X2, Coordinate.Y1), ref canvasBase, fChar);
            base.DrawLine(new Coordinates(Coordinate.X1, Coordinate.Y1, Coordinate.X1, Coordinate.Y2), ref canvasBase, fChar);
            base.DrawLine(new Coordinates(Coordinate.X2, Coordinate.Y1, Coordinate.X2, Coordinate.Y2), ref canvasBase, fChar);
            base.DrawLine(new Coordinates(Coordinate.X1, Coordinate.Y2, Coordinate.X2, Coordinate.Y2), ref canvasBase, fChar);            
        }

        public override bool ValidateCoordinates()
        {

            if (Coordinate.X1 > Coordinate.X2 || Coordinate.Y1 > Coordinate.Y2)
                return false;

            return true;
            
        }
    }
}

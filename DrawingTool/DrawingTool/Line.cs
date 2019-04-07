using System;

namespace DrawingTool
{
    public class Line : CanvasItem
    {
        public Line()
        {

        }
        public override void Draw(ref char[,] canvasBase, char fChar)
        {
            int x0 = Coordinate.X1;
            int x1 = Coordinate.X2;
            int y0 = Coordinate.Y1;
            int y1 = Coordinate.Y2;
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            for (; ; )
            {
                //bitmap.SetPixel(x0, y0, color);
                canvasBase[x0, y0] = fChar;
                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    public interface ICanvas
    {
        void Create();
        void Draw(ICoordinate coordinates, char mChar, char cmd);
        String Render();
        void BucketFill(int x, int y, char mchar);
    }


    public class Canvas : ICanvas
    {
        #region Members

        char[,] canvasArray;
        int width, height;

        #endregion

        #region Constructor

        public Canvas() { }
        public Canvas(int w, int h)
        {
            if (w < 1 || h < 1)
            {
                throw new CanvasException("Canvas width and height can't be 0");
            }
            h += 2;
            w += 2;
            this.width = w;
            this.height = h;
            Create();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Create canvas and array
        /// </summary>
        public void Create()
        {
            this.canvasArray = new char[height, width];
            DrawCanvasLine(new Coordinates(0, 0, this.width - 1, 0), '.');
            DrawCanvasLine(new Coordinates(0, this.height - 1, this.width - 1, this.height - 1), '.');
            DrawCanvasLine(new Coordinates(0, 1, 0, this.height - 2), '.');
            DrawCanvasLine(new Coordinates(this.width - 1, 1, this.width - 1, this.height - 2), '.');
        }

        public void DrawCanvasLine(ICoordinate coordinate,  char fillChar)
        {
            for (int i = coordinate.Y1; i <= coordinate.Y2; i++)
            {
                for (int j = coordinate.X1; j <= coordinate.X2; j++)
                {
                    canvasArray[i, j] = fillChar;
                }
            }
        }

        /// <summary>
        /// Render canvas
        /// </summary>
        /// <returns></returns>
        public String Render()
        {
            ValidateCanvas();
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    strBuilder.Append(this.canvasArray[i, j] == '\u0000' ? ' ' : this.canvasArray[i, j]);
                }
                strBuilder.Append("\n");
            }
            return strBuilder.ToString().Trim();
        }

        /// <summary>
        /// Draw shapes
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="mChar"></param>
        /// <param name="cmd"></param>
        public void Draw(ICoordinate coordinates, char mchar, char cmd)
        {
            try
            {
                ValidateCanvas();
                
                ShapeFactory shapeFactory = new ConcreteShapeFactory();
                CanvasItem canvasItem = shapeFactory.GetShape(cmd);
                canvasItem.Coordinate = coordinates;

                if(!canvasItem.ValidateCoordinates())
                {
                    throw new CanvasException("Coordinates are not correct or colinear. Please try Again!!");
                }
                canvasItem.Draw(ref canvasArray, mchar);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Bucket fill canvas
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="mchar"></param>
        public void BucketFill(int x, int y, char mchar)
        {
            try
            {
                ValidateCanvas();
                if ((int)this.canvasArray[y, x] != 0)
                {
                    return;
                }
                if (x > 0 || x < this.height || y > 0 || y < this.width)
                {
                    if ((int)this.canvasArray[y, x] == 0)
                        this.canvasArray[y, x] = mchar;
                    BucketFill(x + 1, y, mchar);
                    BucketFill(x - 1, y, mchar);
                    BucketFill(x, y - 1, mchar);
                    BucketFill(x, y + 1, mchar);
                }
            }
            catch
            {
                throw;
            }
        }

        private void ValidateCanvas()
        {
            if (this.canvasArray == null)
                throw new CanvasException("Draw a canvas first");
        }

        #endregion
    }

    
}

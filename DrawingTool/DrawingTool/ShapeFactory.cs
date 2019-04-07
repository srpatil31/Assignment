using System;

namespace DrawingTool
{
    public abstract class ShapeFactory
    {
        public abstract CanvasItem GetShape(char shapeCommand);

    }

    public class ConcreteShapeFactory : ShapeFactory
    {
        public override CanvasItem GetShape(char shapeCommand)
        {
            if (shapeCommand == 'L')
                return new Line();
            else if (shapeCommand == 'R')
            {
                return new Rectangle();
            }
            throw new NotImplementedException();
        }
    }
}

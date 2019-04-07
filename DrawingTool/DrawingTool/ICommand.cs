using System.Collections.Generic;

namespace DrawingTool
{
    public interface ICommand
    {
        ICoordinate Coordinates { get; set; }
        char CommandParameter { get; set; }
        Canvas Canvas { get; set; }
        string Execute();
    }

    public class CreateCommand : ICommand
    {
        public ICoordinate Coordinates { get; set; }
        public char CommandParameter { get; set; }
        public Canvas Canvas { get; set; }

        public string Execute()
        {
            Canvas.Create();
            return Canvas.Render();
        }
    }

    public class DrawShapeCommand : ICommand
    {

        public ICoordinate Coordinates { get; set; }
        public char CommandParameter { get; set; }
        public Canvas Canvas { get; set; }
        public string Execute()
        {
            Canvas.Draw(Coordinates, 'X', CommandParameter);
            return Canvas.Render();
        }
    }

    public class BucketFillCommand : ICommand
    {
        public ICoordinate Coordinates { get; set; }
        public char CommandParameter { get; set; }
        public Canvas Canvas { get; set; }

        public string Execute()
        {
            Canvas.BucketFill(Coordinates.X1, Coordinates.Y1, CommandParameter);

            return Canvas.Render();
        }
    }

    public class Invoker
    {
        private static Dictionary<char, ICommand> CommandDictionary = new Dictionary<char, ICommand>()
        {
            {'C', new CreateCommand() },
            {'D', new DrawShapeCommand() },
            {'B', new BucketFillCommand() }
        };

        public ICommand GetCommand(char cmd)
        {
            if (CommandDictionary.ContainsKey(cmd))
                return CommandDictionary[cmd];
            else
                return null;

        }
    }
}

using System;
using System.Linq;

namespace DrawingTool
{
    public class DrawingTool
    {
        Canvas canvas = null;

        public void Draw(string command)
        {
            
            char ch = command.ElementAt(0);
            String[] cmd;
            try
            {
                ICoordinate coordinate = null;
                char cmdChoice = char.ToUpper(ch);
                char commandParameter = char.MinValue;
                switch (char.ToUpper(ch))
                {
                    case 'C':
                        cmd = command.Split(' ');
                        canvas = new Canvas(int.Parse(cmd[1]), int.Parse(cmd[2]));
                        commandParameter = char.ToUpper(ch);
                        break;
                    case 'L':
                        cmd = command.Split(' ');
                        coordinate = new Coordinates(int.Parse(cmd[1]), int.Parse(cmd[2]), int.Parse(cmd[3]), int.Parse(cmd[4]));

                        commandParameter = char.ToUpper(ch);
                        cmdChoice = 'D';

                        break;
                    case 'R':
                        cmd = command.Split(' ');
                        coordinate = new Coordinates(int.Parse(cmd[1]), int.Parse(cmd[2]), int.Parse(cmd[3]), int.Parse(cmd[4]));

                        commandParameter = char.ToUpper(ch);
                        cmdChoice = 'D';
                        break;
                    case 'B':
                        cmd = command.Split(' ');
                        coordinate = new Coordinates(int.Parse(cmd[1]), int.Parse(cmd[2]), int.MinValue, int.MinValue);

                        commandParameter = 'C';

                        ColorCodes code;
                        Enum.TryParse(cmd[3].ElementAt(0).ToString().ToUpper(), out code);
                        ColourfulConsole.CurrentColorCode = code;


                        break;
                    default:
                        Console.WriteLine("Invalid Command..");
                        break;
                }

                Invoker commandInvoker = new Invoker();
                ICommand canvasCommand = commandInvoker.GetCommand(cmdChoice);
                if (canvasCommand != null)
                {
                    canvasCommand.Canvas = canvas;
                    canvasCommand.CommandParameter = commandParameter;
                    canvasCommand.Coordinates = coordinate;
                    var output = canvasCommand?.Execute();
                    ColourfulConsole.Write(output, 'C');
                }
                else
                {
                    Console.WriteLine("\nInvalid command. Try again!!\n");
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\nEntered coordinates are not in limit of canvas. Try again with correct coordinates!!\n");
            }
            catch (CanvasException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                if (canvas == null)
                {
                    Console.WriteLine("Canvas is not created. Please create Canvas first");
                }
                else
                    Console.WriteLine("\nError Occurred : " + e.Message + "\nPlease try again");
            }
        }
    }    
}

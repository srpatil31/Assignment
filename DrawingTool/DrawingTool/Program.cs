using System;

namespace DrawingTool
{
    partial class Program
    {
        static void Main(string[] args)
        {
            DrawingTool drawingTool = new DrawingTool();
            string command = string.Empty;
            while (!command.Equals("Q"))
            {
                Console.WriteLine("\nEnter command:");
                command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("No Command was entered.. please try again");
                    continue;
                }
                drawingTool.Draw(command);
            }
        }
         
    }
}

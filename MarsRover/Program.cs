using System;
using System.Drawing;
using static MarsRover.Rover;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assumption1: If the rover coordinate will go beyond the plateau boundary, an error will be thrown 
            //Assumption2: There are only 2 rovers in the robotic squad, thus accepting only 2 sets of input for rover
            //Assumption3: 2 rovers can overlap in same grid

            Console.Write("Upper-right coords: ");
            var upperRightCoords = Console.ReadLine();
            Console.Write("First Rover's Position: ");
            var firstRoverPosition = Console.ReadLine();
            Console.Write("First Rover's Instructions: ");
            var firstRoverMovements = Console.ReadLine();
            Console.Write("Second Rover's Position: ");
            var secondRoverPosition = Console.ReadLine();
            Console.Write("Second Rover's Instructions: ");
            var secondRoverMovements = Console.ReadLine();

            try
            {
                //get plateau area
                var areaSplit = upperRightCoords.Split(' ');
                var area = new Point(Convert.ToInt32(areaSplit[0]), Convert.ToInt32(areaSplit[1]));

                try
                {
                    //Initialize first rover
                    var roverCoords1 = firstRoverPosition.Split(' ');
                    var roverPoint1 = new Point(Convert.ToInt32(roverCoords1[0]), Convert.ToInt32(roverCoords1[1]));
                    var roverDirection1 = (Directions)Enum.Parse(typeof(Directions), roverCoords1[2]);
                    var firstRover = new Rover(1, roverPoint1, roverDirection1, firstRoverMovements, area);

                    firstRover.Start();
                    Console.WriteLine($"{firstRover.Position.X} {firstRover.Position.Y} {firstRover.Direction}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    //Initialize second rover
                    var roverCoords2 = secondRoverPosition.Split(' ');
                    var roverPoint2 = new Point(Convert.ToInt32(roverCoords2[0]), Convert.ToInt32(roverCoords2[1]));
                    var roverDirection2 = (Directions)Enum.Parse(typeof(Directions), roverCoords2[2]);
                    var secondRover = new Rover(2, roverPoint2, roverDirection2, secondRoverMovements, area);

                    secondRover.Start();
                    Console.WriteLine($"{secondRover.Position.X} {secondRover.Position.Y} {secondRover.Direction}");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}

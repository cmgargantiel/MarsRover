using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarsRover;
using System.Drawing;
using static MarsRover.Rover;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            int roverId = 1;
            Point area = new Point(5, 5);
            Point position = new Point(1, 2);
            Directions direction = Rover.Directions.N;
            string movement = "LMLMLMLMM";
            Rover rover = new Rover(roverId, position, direction, movement, area);

            int roverId2 = 2;
            Point position2 = new Point(3, 3);
            Directions direction2 = Rover.Directions.E;
            string movement2 = "MMRMMRMRRM";
            Rover rover2 = new Rover(roverId2, position2, direction2, movement2, area);

            string expected1 = "1 3 N";
            string expected2 = "5 1 E";

            //Act
            rover.Start();
            string actual1 = $"{rover.Position.X} {rover.Position.Y} {rover.Direction}";
            rover2.Start();
            string actual2 = $"{rover2.Position.X} {rover2.Position.Y} {rover2.Direction}";


            //Assert
            Assert.IsTrue(actual1 == expected1 && actual2 == expected2);

        }
    }
}

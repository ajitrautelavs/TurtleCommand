using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TurtleCommand;

namespace TurtleCommandUnitTest
{
    [TestClass]
    public class TurtleCommandTests
    {
        [TestMethod]
        public void Move_From_Start_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE 0,0,NORTH");
            commandsList.Add("MOVE");
            commandsList.Add("REPORT");
            string expectedReport = "0,1,NORTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Start_Move_Replace_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE");
            commandsList.Add("MOVE");
            commandsList.Add("PLACE");
            commandsList.Add("REPORT");
            string expectedReport = "0,0,NORTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void All_Valid_Moves_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE 1,2,EAST");
            commandsList.Add("MOVE");
            commandsList.Add("MOVE");
            commandsList.Add("LEFT");
            commandsList.Add("MOVE");
            commandsList.Add("REPORT");
            string expectedReport = "3,3,NORTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Invalid_Move_OutOfBounds_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE 0,0,SOUTH");
            commandsList.Add("MOVE");
            commandsList.Add("REPORT");
            string expectedReport = "0,0,SOUTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Invalid_Command_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE 0,0,NORTH");
            commandsList.Add("INVALIDCOMMAND");
            commandsList.Add("REPORT");
            string expectedReport = "0,0,NORTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Not_Placed_Yet_Ignore_Commands_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("MOVE");
            commandsList.Add("LEFT");
            commandsList.Add("MOVE");
            commandsList.Add("PLACE 2,3,EAST");
            commandsList.Add("RIGHT");
            commandsList.Add("REPORT");
            string expectedReport = "2,3,SOUTH";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Not_Placed_Yet_Ignore_All_Commands_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("MOVE");
            commandsList.Add("LEFT");
            commandsList.Add("MOVE");
            commandsList.Add("RIGHT");
            commandsList.Add("REPORT");
            string expectedReport = "";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }

        [TestMethod]
        public void Invalid_Place_Coordinates_Test()
        {
            ExecuteTurtle exe = new ExecuteTurtle();

            //Arrange
            List<string> commandsList = new List<string>();
            commandsList.Add("PLACE 8,9,EAST");
            commandsList.Add("REPORT");
            string expectedReport = "0,0,EAST";

            //Act
            string actualReport = exe.ExecuteCommands(commandsList);

            //Assert
            Assert.AreEqual(expectedReport, actualReport, "Turtle's correct position reported");
        }
    }
}

using System;
using System.Collections.Generic;

namespace TurtleCommand
{
    public class ExecuteTurtle
    {
        public string ExecuteCommands(List<string> commandsList)
        {
            Turtle turtle = new Turtle();

            string report = string.Empty;

            if (commandsList.Count > 0)
            {
                foreach (var commandString in commandsList)
                {
                    CommandEnum command = ParseCommand(commandString, out BoardPosition position);
                    if (command == CommandEnum.PLACE && turtle.IsPlacedOnBoard == false)
                    {
                        //Place on board (if not already on board) when PLACE command issued
                        turtle.PlaceOnBoard(position);
                    }
                    else
                    {
                        //Further commands only if already placed on board
                        if (turtle.IsPlacedOnBoard)
                        {
                            switch (command)
                            {
                                case CommandEnum.PLACE:
                                    //Re Place with new position
                                    turtle.PlaceOnBoard(position);
                                    break;
                                case CommandEnum.MOVE:
                                    //Move turtle one step
                                    turtle.MoveOnBoard();
                                    break;
                                case CommandEnum.LEFT:
                                case CommandEnum.RIGHT:
                                    //Turn on board depending on current position
                                    turtle.TurnOnBoard(command);
                                    break;
                                case CommandEnum.REPORT:
                                    //Report current position
                                    report = turtle.CurrentPosition.X + "," + turtle.CurrentPosition.Y + "," + turtle.CurrentPosition.F.ToString();
                                    break;
                                default:
                                    //Do Nothing
                                    break;
                            }
                        }
                    }
                }

            }
            return report;
        }

        private CommandEnum ParseCommand(string commandString, out BoardPosition position)
        {
            CommandEnum command = CommandEnum.INVALID;

            //Default position 0,0,North 
            position = new BoardPosition() { X = 0, Y = 0, F = DirectionEnum.NORTH };

            //Parse the first word as command
            string[] placeCommands = commandString.Split(' ');
            try
            {
                command = (CommandEnum)Enum.Parse(typeof(CommandEnum), placeCommands[0], true);     //Parse command

                if (command == CommandEnum.PLACE && placeCommands.Length > 1)
                {
                    BoardPosition pos = ParsePositionFromCommand(commandString.ToUpper().Replace("PLACE", ""));
                    if (pos != null)
                        position = pos;
                }
            }
            catch
            {
                // Invalid command
            }

            return command;
        }

        private BoardPosition ParsePositionFromCommand(string placeArgumemts)
        {
            BoardPosition position = new BoardPosition() { X = 0, Y = 0, F = DirectionEnum.NORTH };

            try
            {
                string[] placeCommands = placeArgumemts.Split(',');
                if (placeCommands.Length == 3)
                {
                    //If PLACE command has 4 arguments, then it is valid command with position, otherwise just place on default position
                    //placeCommands[0] is the PLACE command name
                    position.X = int.Parse(placeCommands[0].Trim());
                    position.Y = int.Parse(placeCommands[1].Trim());
                    position.F = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), placeCommands[2].Trim(), true);      //Parse direction
                }
            }
            catch
            {
                //Invalid position data
                return null;
            }

            return position;
        }
    }
}

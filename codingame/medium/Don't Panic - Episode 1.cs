using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators

        int[] elevatorFloor = new int[nbElevators];
        int[] elevatorPos = new int[nbElevators];

        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            elevatorFloor[i]  = int.Parse(inputs[0]); // floor on which this elevator is found
            elevatorPos[i]  = int.Parse(inputs[1]); // position of the elevator on its floor

        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            var goaldir = direction;

            int goalpos = exitPos;
            if (elevatorFloor.Contains(cloneFloor))
            {
                int i = Array.IndexOf(elevatorFloor, cloneFloor);
                if (direction == "RIGHT") goalpos = Math.Min(elevatorPos[i], clonePos);
                if (direction == "LEFT") goalpos = Math.Max(elevatorPos[i], clonePos);
            }

            if (((direction == "RIGHT") && clonePos > goalpos) || ((direction == "LEFT") && clonePos < goalpos))
            {
            Console.WriteLine("BLOCK");
            Console.Error.WriteLine($"blocked from {direction} at {cloneFloor}, {clonePos}");
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            else Console.WriteLine("WAIT"); // action: WAIT or BLOCK
            Console.Error.WriteLine($"leading at {cloneFloor}, {clonePos}");

        }
    }
}

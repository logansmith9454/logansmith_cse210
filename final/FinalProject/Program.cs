using System;

class Program
{
    static Dictionary<string, string> turnMap = new Dictionary<string, string>{
        {"U", "U'"}, {"U'", "U"}, {"U2", "U2"}, {"M", "M'"}, {"M'", "M"}, {"M2", "M2"}
    };
    static void Main(string[] args)
    {
        Console.Clear();
        // Cube scrambledCube = GetScramble();
        // List<string> solutionMoves = Solve(scrambledCube);
        // DisplaySolution(solutionMoves);



        Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> testDict = new Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>();
        Cube newCube = new Cube();
        newCube.UMoves(" ", testDict);
        Console.Clear();
        foreach ((int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) cubeState in testDict.Keys)
        {
            Cube testCube = TupleToCube(cubeState);
            Console.WriteLine($"Move: {testDict[cubeState]}");
            testCube.DisplayCube();
            Console.WriteLine();
        }
        Console.WriteLine(testDict.Count());
    }

    public static Cube GetScramble()
    {
        Cube scrambledCube = new Cube();
        Console.Clear();
        int cornerInt = 4;
        bool goodCorners = false;
        while (goodCorners == false)
        {
            Console.Write("What is the corner position? (solved = 0, U = 1, U2 = 2, U' = 3)> ");
            string cornerInput = Console.ReadLine();
            try
            {
                cornerInt = Convert.ToInt32(cornerInput);
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                continue;
            }
            if (cornerInt < 0 || cornerInt > 3)
            {
                Console.WriteLine("Invalid input. Please enter an integer between 0 and 3.");
                continue;
            }
            else
            {
                goodCorners = true;
            }
        }
        scrambledCube.MoveCorners(cornerInt);

        int centerInt = 0;
        bool goodCenters = false;
        while (goodCenters == false)
        {
            Console.Write("Are the centers oriented? (ori = 1, not ori = 0)> ");
            string centerInput = Console.ReadLine();
            try
            {
                centerInt = Convert.ToInt32(centerInput);
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter either 0 or 1.");
                continue;
            }
            if (centerInt < 0 || centerInt > 1)
            {
                Console.WriteLine("Invalid input. Please enter either 0 or 1.");
                continue;
            }
            else
            {
                goodCenters = true;
            }
        }
        if (centerInt == 0)
        {
            scrambledCube.MoveCenters(1);
        }
        Console.WriteLine("\nEnter the locations of the following pieces.");
        Console.WriteLine("Type the location first (locations are: a, b, c, d, u, w)");
        Console.WriteLine("Type the orientation second (1 for oriented, 0 for misoriented)");
        Console.WriteLine("Your input should look like this: d1");
        List<char> unclaimedEdges = new List<char> { 'a', 'b', 'c', 'd', 'u', 'w' };
        bool lrCheck;
        foreach (LR lrEdge in scrambledCube.GetLRList())
        {
            lrCheck = false;
            while (lrCheck == false)
            {
                Console.Write($"Where is {lrEdge.GetLocation()} located?> ");
                string lrInput = Console.ReadLine();
                if (lrInput.Length != 2)
                {
                    Console.WriteLine("Invalid input length. Input should be 2 characters.");
                    continue;
                }
                else
                {
                    char lrLocation = lrInput[0];
                    char lrOrientation = lrInput[1];
                    if (!unclaimedEdges.Contains(lrLocation))
                    {
                        Console.WriteLine("An edge is already there.");
                        continue;
                    }
                    else
                    {
                        int orientation = 0;
                        try
                        {
                            orientation = Convert.ToInt32(lrOrientation);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid orientation. Please enter either 0 or 1");
                        }
                        unclaimedEdges.Remove(lrLocation);
                        bool orientationBool = Convert.ToBoolean(orientation);
                        lrEdge.Move(lrLocation, orientationBool);
                        lrCheck = true;
                    }
                }
            }
        }

        bool oriCheck;
        for (int i = 0; i < 4; i++)
        {
            Ori oriEdge = scrambledCube.GetOriList()[i];

            char location = unclaimedEdges[i];
            oriCheck = false;
            while (oriCheck == false)
            {
                Console.Write($"What orientation is {unclaimedEdges[i]}?> ");
                string oriInput = Console.ReadLine();
                if (oriInput.Length != 1)
                {
                    Console.WriteLine("Invalid input length. Input should be 1 character.");
                    continue;
                }
                else
                {
                    int orientation = 0;
                    try
                    {
                        orientation = Convert.ToInt32(oriInput);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid orientation. Please enter either 0 or 1");
                    }
                    bool orientationBool = Convert.ToBoolean(orientation);
                    oriEdge.Move(location, orientationBool);
                    oriCheck = true;
                }
            }
        }
        scrambledCube.ValidateState();
        return scrambledCube;

    }

    public static List<string> Solve(Cube scrambledCube)
    {
        List<string> solutionMoves = new List<string>();
        var scrambledTuple = scrambledCube.CubeToTuple();
        (int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) solvedTuple = (0, true, (('b', true), ('d', true)), (true, true, true, true));

        List<Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>> scrambledSide = new List<Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>> { new Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> { { scrambledTuple, " " } } };

        List<Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>> solvedSide = new List<Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>> { new Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> { { solvedTuple, " " } } };

        if (scrambledTuple == solvedTuple)
        {
            Console.WriteLine("It's already solved");
            return new List<string> { "None" };
        }

        for (int layer = 0; layer < 15; layer++)
        {
            scrambledSide.Add(new Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>());

            foreach (KeyValuePair<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> cubeState in scrambledSide[layer])
            {
                TurnCube(cubeState, scrambledSide[layer + 1]);
            }
            solutionMoves = CheckSolved(solvedTuple, solvedSide[layer], scrambledSide[layer + 1]);
            if (solutionMoves[0].Length > 2)
            {
                return solutionMoves;
            }
            solvedSide.Add(new Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string>());
            foreach (KeyValuePair<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> currentState in solvedSide[layer])
            {
                TurnCube(currentState, solvedSide[layer + 1]);
            }
            solutionMoves = CheckSolved(solvedTuple, solvedSide[layer + 1], scrambledSide[layer + 1]);
            if (solutionMoves[0].Length > 2)
            {
                return solutionMoves;
            }

        }
        return solutionMoves;

    }

    public static void TurnCube(KeyValuePair<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> cubeState, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> location)
    {
        string moves = cubeState.Value;
        Cube newCube = TupleToCube(cubeState.Key);
        char lastMove = 'a';
        if (moves[moves.Length - 1] == 'M' | moves[moves.Length - 1] == 'U')
        {
            lastMove = moves[moves.Length - 1];
        }
        else if ((moves.Length > 1) && moves[moves.Length - 2] == 'M' | moves[moves.Length - 2] == 'U')
        {
            lastMove = moves[moves.Length - 2];
        }
        else if ((moves.Length > 2) && moves[moves.Length - 3] == 'M' | moves[moves.Length - 3] == 'U')
        {
            lastMove = moves[moves.Length - 3];
        }
        else
        {
            newCube.AllMoves(moves, location);
            lastMove = ' ';
        }
        if (lastMove == 'U')
        {
            newCube.MMoves(moves, location);
        }
        else if (lastMove == 'M')
        {
            newCube.UMoves(moves, location);
        }
    }

    public static List<string> CheckSolved((int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) solvedTuple, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> solvedSide, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> scrambledSide)
    {
        List<string> solutionMoves = new List<string>();
        // (int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) middleState;

        if (solvedSide.Count() == 1)
        {
            if (scrambledSide.Keys.Contains(solvedTuple))
            {
                solutionMoves.Add(scrambledSide[solvedTuple]);
                return solutionMoves;
            }
        }

        else
        {
            var testDuplicate = scrambledSide.Keys.Intersect(solvedSide.Keys);
            if (testDuplicate.Any())
            {
                (int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) middleState = scrambledSide.Keys.Intersect(solvedSide.Keys).FirstOrDefault();
                Console.WriteLine("Solution found!");
                string scrambledMoves = scrambledSide[middleState];
                string solvedMoves = solvedSide[middleState];
                solutionMoves.Add(scrambledMoves);
                if (!(solvedMoves == " "))
                {
                    solutionMoves.Add(solvedMoves);
                }
                else
                {
                    solutionMoves.Add(" ");
                }
            }
        }


        solutionMoves.Add(" ");

        return solutionMoves;
    }

    public static Cube TupleToCube((int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) tupledCube)
    {
        List<char> unclaimedEdges = new List<char> { 'a', 'b', 'c', 'd', 'u', 'w' };
        int cornerInt = tupledCube.Item1;
        bool centerBool = tupledCube.Item2;
        ((char, bool), (char, bool)) lrTuple = tupledCube.Item3;
        (bool, bool, bool, bool) oriTuple = tupledCube.Item4;
        (char, bool) bTuple = lrTuple.Item1;
        (char, bool) dTuple = lrTuple.Item2;

        Corners corners = new Corners(cornerInt);
        Centers centers = new Centers(centerBool);
        LR lrb = new LR(bTuple.Item1, bTuple.Item2, 'b');
        unclaimedEdges.Remove(bTuple.Item1);
        LR lrd = new LR(dTuple.Item1, dTuple.Item2, 'd');
        unclaimedEdges.Remove(dTuple.Item1);

        Ori ori1 = new Ori(unclaimedEdges[0], oriTuple.Item1);
        Ori ori2 = new Ori(unclaimedEdges[1], oriTuple.Item2);
        Ori ori3 = new Ori(unclaimedEdges[2], oriTuple.Item3);
        Ori ori4 = new Ori(unclaimedEdges[3], oriTuple.Item4);
        Cube _newCube = new Cube(corners, centers, lrb, lrd, ori1, ori2, ori3, ori4);

        return _newCube;
    }

    public static void DisplaySolution(List<string> solutionMoves)
    {
        int movecount;
        string finalSolution;
        if (solutionMoves[1] == "")
        {
            movecount = 1;
            Console.WriteLine($"Solution: {solutionMoves[1]}");
        }
        else
        {
            foreach (string item in solutionMoves)
            {
                Console.WriteLine(item);
            }
            string scrambledMoves = solutionMoves[0];
            string solvedMoves = solutionMoves[1];
            finalSolution = scrambledMoves.Trim() + " " + solvedMoves.Trim();
            string[] solutionList = finalSolution.Split(" ");
            movecount = solutionList.Count();
            Console.WriteLine($"Movecount: {movecount}");
            Console.WriteLine($"Solution: {finalSolution}");
        }
    }

    public static string InvertMoves(string moves)
    {
        List<string> invertedMoves = new List<string>();
        moves.Trim();
        string[] movesList = moves.Split(" ");
        foreach (string move in movesList)
        {
            invertedMoves.Add(turnMap[move]);
        }
        invertedMoves.Reverse();
        string invertedString = string.Join(" ", invertedMoves);
        return invertedString;
    }

}


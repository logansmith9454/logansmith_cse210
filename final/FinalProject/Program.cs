using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Cube _newCube = new Cube();
        _newCube.U();
        _newCube.U();
        _newCube.U();
        _newCube.U();
        _newCube.DisplayCube();
    }

    public static Cube GetScramble()
    {
        Cube scrambledCube = new Cube();
        Console.Clear();
        int cornerInt = 4;
        bool goodCorners = false;
        while (goodCorners == false)
        {
            Console.WriteLine("What is the corner position? (solved = 0, U = 1, U2 = 2, U' = 3)> ");
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

        int centerInt = 2;
        bool goodCenters = false;
        while (goodCenters == false)
        {
            Console.WriteLine("Are the centers oriented? (ori = 1, not ori = 0)> ");
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
        scrambledCube.MoveCenters(centerInt + 1);
        Console.WriteLine("Enter the locations of the following pieces.");
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
                Console.WriteLine($"Where is {lrEdge.GetLocation()} located?> ");
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

                    }
                }
            }
        }





        return scrambledCube;

    }
    public static string Solve(Cube scrambledCube)
    {
        return "solution";
    }

    public void TurnCube()
    {

    }

    public static List<string> CheckSolved()
    {
        List<string> _solutionMoves = new List<string>();
        return _solutionMoves;
    }

    public Cube TupleToCube()
    {
        Cube _convertedCube = new Cube();
        return _convertedCube;
    }

    public void DisplaySolution(List<string> solutionMoves)
    {

    }

    public List<string> InvertMoves(string moves)
    {
        List<string> invertedMoves = new List<string>();
        return invertedMoves;
    }

}


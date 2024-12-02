if (args.Length <= 0)
{
    Console.WriteLine("Please provide a path to input data");
    Console.WriteLine();
}

PuzzleRunner.Run(args);

public static class PuzzleRunner
{
    public static void Run(String[] args)
    {
        Console.Write("Please enter day number: ");
        String? day = Console.ReadLine()?.Trim();
        Console.Write("Please enter puzzle number for the day (1 or 2): ");
        String? puzzle = Console.ReadLine()?.Trim();

        switch (day)
        {
            case "1":
                if (puzzle == "1")
                {
                    Day01A day01A = new Day01A(args[0]);
                    day01A.Solve();
                }
                else if (puzzle == "2")
                {
                    Day01B day01B = new Day01B(args[0]);
                    day01B.Solve();
                }
                else
                {
                    PuzzleNotFound(day, puzzle);
                }
                break;
            default:
                PuzzleNotFound(day, puzzle);
                break;
        }
    }

    private static void PuzzleNotFound(String? day, String? puzzle)
    {
        Console.WriteLine("Puzzle #" + puzzle + " not created on day " + day);
    }
}

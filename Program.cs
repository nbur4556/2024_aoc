if (args.Length <= 0)
{
    Console.WriteLine("Please provide a path to input data");
    Console.WriteLine();
}

Day01A day01A = new Day01A(args[0]);
day01A.Solve();
